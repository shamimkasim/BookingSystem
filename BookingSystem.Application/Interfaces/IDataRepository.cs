using BookingSystem.Domain.Entities;
using System.Collections.Generic;

namespace BookingSystem.Application.Interfaces
{
    public interface IDataRepository
    {
        IEnumerable<DataEntity> GetAll();
        DataEntity GetById(int id);
        void Add(DataEntity entity);
        void Update(int id, DataEntity entity);
        void Delete(int id);
    }
}
