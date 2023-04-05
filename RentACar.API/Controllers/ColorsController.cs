using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Entities.Concrete;

namespace RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _colorService.GetAll();

            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Color color)
        {
            var result = _colorService.Add(color);
            return result.Success ? Ok(result.Message) : BadRequest();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Color color)
        {
            var result = _colorService.Delete(color);
            return result.Success ? Ok(result.Message) : BadRequest();
        }

        [HttpPatch("update")]
        public IActionResult Update(Color color)
        {
            var result = _colorService.Update(color);
            return result.Success ? Ok(result.Message) : BadRequest();
        }
    }
}
