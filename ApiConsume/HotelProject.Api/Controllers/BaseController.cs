using HotelProject.Api.Models;
using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity, TService> : ControllerBase
        where TEntity : class
        where TService : IGenericService<TEntity>
    {
        protected readonly TService _service;

        protected BaseController(TService service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual IActionResult GetAll()
        {
            try
            {
                var values = _service.TGetAll();
                var response = ApiResponse<List<TEntity>>.SuccessResult(values);
                return Ok(response.Data);
            }
            catch (Exception ex)
            {
                var response = ApiResponse<List<TEntity>>.ErrorResult($"An error occurred while retrieving data: {ex.Message}");
                return StatusCode((int)response.StatusCode, response);
            }
        }

        [HttpGet("{id}")]
        public virtual IActionResult GetById(int id)
        {
            try
            {
                var entity = _service.TGetById(id);
                if (entity == null)
                {
                    var notFoundResponse = ApiResponse<TEntity>.NotFoundResult();
                    return NotFound(notFoundResponse);
                }

                var response = ApiResponse<TEntity>.SuccessResult(entity);
                return Ok(response.Data);
            }
            catch (Exception ex)
            {
                var response = ApiResponse<TEntity>.ErrorResult($"An error occurred while retrieving data: {ex.Message}");
                return StatusCode((int)response.StatusCode, response);
            }
        }

        [HttpPost]
        public virtual IActionResult Add([FromBody] TEntity entity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var validationResponse = ApiResponse<TEntity>.ErrorResult("Invalid model state");
                    return BadRequest(validationResponse);
                }

                _service.TInsert(entity);
                var response = ApiResponse<TEntity>.SuccessResult("Entity created successfully");
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = ApiResponse<TEntity>.ErrorResult($"An error occurred while creating entity: {ex.Message}");
                return StatusCode((int)response.StatusCode, response);
            }
        }

        [HttpPut]
        public virtual IActionResult Update([FromBody] TEntity entity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var validationResponse = ApiResponse<TEntity>.ErrorResult("Invalid model state");
                    return BadRequest(validationResponse);
                }

                _service.TUpdate(entity);
                var response = ApiResponse<TEntity>.SuccessResult("Entity updated successfully");
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = ApiResponse<TEntity>.ErrorResult($"An error occurred while updating entity: {ex.Message}");
                return StatusCode((int)response.StatusCode, response);
            }
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            try
            {
                var entity = _service.TGetById(id);
                if (entity == null)
                {
                    var notFoundResponse = ApiResponse<TEntity>.NotFoundResult();
                    return NotFound(notFoundResponse);
                }

                _service.TDelete(entity);
                var response = ApiResponse<TEntity>.SuccessResult("Entity deleted successfully");
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = ApiResponse<TEntity>.ErrorResult($"An error occurred while deleting entity: {ex.Message}");
                return StatusCode((int)response.StatusCode, response);
            }
        }
    }
}