using BookingSystem.Application.Interfaces;
using BookingSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookingSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IDataRepository _dataRepository;

        public DataController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IEnumerable<DataEntity> Get()
        {
            return _dataRepository.GetAll();
        }

        [HttpGet("{id}")]
        public DataEntity Get(int id)
        {
            return _dataRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] DataEntity data)
        {
            _dataRepository.Add(data);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] DataEntity data)
        {
            _dataRepository.Update(id, data);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dataRepository.Delete(id);
        }
    }
}