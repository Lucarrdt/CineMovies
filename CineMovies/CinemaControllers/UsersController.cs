﻿using CineMovies.CinemaData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CineMovies.CinemaControllers;

public class UsersController : ControllerBase
{
    private readonly CinemaDBContext _context;
    public UsersController(CinemaDBContext context) => _context = context;

    public bool UserExists(int id) => _context.Users.Any(e => e.Id == id);

    public bool IsAdmin(int id) => _context.Users.Any(e => e.Id == id && e.IsAdmin == true);
    /// <summary>
    /// GetUsers() returns a list of all users in the database. & GetUser() returns a user with the given id.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        
        if (user == null)
        {
            return NotFound();
        }
        
        return user;
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(int id, User user)
    {
        if (id != user.Id)
        {
            return BadRequest();
        }
        
        _context.Entry(user).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        
        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction("GetUser", new { id = user.Id }, user);
    }

    [HttpPost ("login")]
    public async Task<ActionResult<User>> LoginUser(User user)
    {
        var userToLogin = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email && u.Password == user.Password);
        
        if (userToLogin == null)
        {
            return NotFound();
        }
        
        return userToLogin;
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<User>> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        
        if (user == null)
        {
            return NotFound();
        }
        
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        
        return user;
    }
}