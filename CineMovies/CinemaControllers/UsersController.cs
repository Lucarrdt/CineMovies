﻿using CineMovies.CinemaData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CineMovies.CinemaControllers;

public class UsersController : ControllerBase
{
  
    private readonly CinemaDBContext _context;

    public bool UserExists(int id) => _context.Users.Any(e => e.Id == id);
    public bool IsAdmin(int id) => _context.Users.Any(e => e.Id == id && e.IsAdmin == true);
    
    public UsersController(CinemaDBContext context)
    {
        _context = context;
    }
    
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
}