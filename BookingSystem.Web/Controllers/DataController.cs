using BookingSystem.Web.Models;
using BookingSystem.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookingSystem.Web.Controllers
{
    public class DataController : Controller
    {
        private readonly IApiService _apiService;

        public DataController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _apiService.GetAllDataAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DataModel data)
        {
            if (ModelState.IsValid)
            {
                await _apiService.CreateDataAsync(data);
                return RedirectToAction(nameof(Index));
            }
            return View(data);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var data = await _apiService.GetDataByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, DataModel data)
        {
            if (ModelState.IsValid)
            {
                await _apiService.UpdateDataAsync(id, data);
                return RedirectToAction(nameof(Index));
            }
            return View(data);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _apiService.GetDataByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteDataAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}