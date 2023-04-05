using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;

namespace RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Brand brand)
        {
            var result = _brandService.Add(brand);
            return result.Success ? Ok(result.Message) : BadRequest();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(Brand brand)
        {
            var result = _brandService.Delete(brand);
            return result.Success ? Ok(result.Message) : BadRequest();

        }

        [HttpPatch("update")]
        public IActionResult Update(Brand brand)
        {
            var result = _brandService.Update(brand);
            return result.Success ? Ok(result.Message) : BadRequest();
        }

    }
}
