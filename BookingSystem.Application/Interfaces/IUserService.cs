using BookingSystem.Domain.Entities;

namespace BookingSystem.Application.Interfaces
{
    public interface IUserService
    {
        void Register(UserEntity user);
        string Login(UserEntity user);
    }
}
