using BookingSystem.Domain.Entities;

namespace BookingSystem.Application.Interfaces
{
    public interface IUserRepository
    {
        void Add(UserEntity user);
        UserEntity GetByUsername(string username);
    }
}
