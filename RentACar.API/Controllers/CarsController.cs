using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Entities.Concrete;

namespace RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _carService.GetCarDetails();   
            return !result.Success ? BadRequest(result.Message) : Ok(result);
        }

        [HttpGet("getbybrand")]
        public IActionResult GetCarsByBrand(int id)
        {
            var result = _carService.GetCarsByBrandId(id);
            return !result.Success ? BadRequest(result.Message) : Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            return !result.Success ? BadRequest() : Ok(result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            return !result.Success ? BadRequest() : Ok(result.Message);
        }

        [HttpPatch("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            return !result.Success ? BadRequest() : Ok(result.Message);

        }
    }
}
