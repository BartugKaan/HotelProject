using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _service;

        public ServiceController(IServiceService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetServices()
        {
            var values = _service.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddService(Service service)
        {
            _service.TInsert(service);
            return Ok("AddService works : " + service.ServiceId);
        }

        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var service = _service.TGetById(id);
            _service.TDelete(service);
            return Ok("DeleteService works");
        }

        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _service.TUpdate(service);
            return Ok("UpdateService works");
        }

        [HttpGet("{id}")]
        public IActionResult GetService(int id)
        {
            var service = _service.TGetById(id);
            return Ok($"GetService works for id: {service}");
        }
    }
}
