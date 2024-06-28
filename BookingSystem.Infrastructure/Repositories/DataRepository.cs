using BookingSystem.Application.Interfaces;
using BookingSystem.Domain.Entities;
using BookingSystem.Infrastructure.Data;
using System.Collections.Generic;
using Dapper;

namespace BookingSystem.Infrastructure.Repositories
{
    public class DataRepository : IDataRepository
    {
        private readonly DatabaseContext _context;

        public DataRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<DataEntity> GetAll()
        {
            using (var connection = _context.CreateConnection())
            {
                return connection.Query<DataEntity>("SELECT * FROM Data");
            }
        }

        public DataEntity GetById(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                return connection.QuerySingleOrDefault<DataEntity>("SELECT * FROM Data WHERE Id = @Id", new { Id = id });
            }
        }

        public void Add(DataEntity entity)
        {
            using (var connection = _context.CreateConnection())
            {
                var sql = "INSERT INTO Data (Name, Value) VALUES (@Name, @Value)";
                connection.Execute(sql, entity);
            }
        }

        public void Update(int id, DataEntity entity)
        {
            using (var connection = _context.CreateConnection())
            {
                var sql = "UPDATE Data SET Name = @Name, Value = @Value WHERE Id = @Id";
                connection.Execute(sql, new { entity.Name, entity.Value, Id = id });
            }
        }

        public void Delete(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var sql = "DELETE FROM Data WHERE Id = @Id";
                connection.Execute(sql, new { Id = id });
            }
        }
    }
}