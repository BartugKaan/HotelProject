using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpGet]
        public IActionResult GetSubscribes()
        {
            var values = _subscribeService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddSubscribe(Subscribe subscribe)
        {
            _subscribeService.TInsert(subscribe);
            return Ok("AddSubscribe works : " + subscribe.SubscribeId);
        }

        [HttpDelete]
        public IActionResult DeleteSubscribe(int id)
        {
            var subscribe = _subscribeService.TGetById(id);
            _subscribeService.TDelete(subscribe);
            return Ok("DeleteSubscribe works");
        }

        [HttpPut]
        public IActionResult UpdateSubscribe(Subscribe subscribe)
        {
            _subscribeService.TUpdate(subscribe);
            return Ok("UpdateSubscribe works");
        }

        [HttpGet("{id}")]
        public IActionResult GetSubscribe(int id)
        {
            var subscribe = _subscribeService.TGetById(id);
            return Ok($"GetSubscribe works for id: {subscribe}");
        }
    }
}
