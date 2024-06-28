using BookingSystem.Application.Interfaces;
using BookingSystem.Domain.Entities;
using BookingSystem.Infrastructure.Data;
using Dapper;

namespace BookingSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(UserEntity user)
        {
            using (var connection = _context.CreateConnection())
            {
                var sql = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
                connection.Execute(sql, user);
            }
        }

        public UserEntity GetByUsername(string username)
        {
            using (var connection = _context.CreateConnection())
            {
                return connection.QuerySingleOrDefault<UserEntity>("SELECT * FROM Users WHERE Username = @Username", new { Username = username });
            }
        }
    }
}