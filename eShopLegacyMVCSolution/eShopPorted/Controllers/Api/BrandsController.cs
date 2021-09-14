using eShopPorted.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace eShopPorted.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandsController : Controller
    {
        private readonly ICatalogService _service;

        public BrandsController(ICatalogService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var brands = _service.GetCatalogBrands();
            return Ok(brands);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var brandToDelete = _service.GetCatalogBrands().FirstOrDefault(x => x.Id == id);
            if (brandToDelete == null)
            {
                return NotFound();
            }

            // demo only - don't actually delete
            return Ok();
        }
    }
}
