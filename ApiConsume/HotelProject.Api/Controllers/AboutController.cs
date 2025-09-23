using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult GetAbouts()
        {
            var values = _aboutService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddAbout(About about)
        {
            _aboutService.TInsert(about);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var values = _aboutService.TGetById(id);
            if (values == null)
            {
                return NotFound();
            }
            _aboutService.TDelete(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateAbout(About about)
        {
            _aboutService.TUpdate(about);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var values = _aboutService.TGetById(id);
            if (values == null)
            {
                return NotFound();
            }
            return Ok(values);
        }
    }
}
