using CineMovies.CinemaData;

namespace CineMovies.RepositoryPattern;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> GetUser(int id);
    Task<User> UpdateUser(int id, User user);
    Task<User> DeleteUser(int id);
    Task<User> AddUser(User user);
    Task<User> LoginUser(User user);
}