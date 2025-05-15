using server.Contracts;
using server.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [ApiController]
    [Route("api/crops")]
    public class CropController : ControllerBase
    {
        private readonly ICropRepository _cropRepository;
        public CropController(ICropRepository cropRepository)
        {
            _cropRepository = cropRepository;
        }
        [HttpGet]
        public IActionResult GetAllCrops()
        {
            var crops = _cropRepository.GetAllCrops(trackChanges: false);
            return Ok(crops);
        }
    }
}
