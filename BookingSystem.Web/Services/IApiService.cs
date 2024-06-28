using BookingSystem.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingSystem.Web.Services
{
    public interface IApiService
    {
        Task<IEnumerable<DataModel>> GetAllDataAsync();
        Task<DataModel> GetDataByIdAsync(int id);
        Task CreateDataAsync(DataModel data);
        Task UpdateDataAsync(int id, DataModel data);
        Task DeleteDataAsync(int id);

        Task RegisterUserAsync(UserModel user);
        Task<string> LoginUserAsync(UserModel user);
    }
}
