using eShopLegacy.Utilities;
using eShopPorted.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace eShopPorted.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilesController : Controller
    {
        private readonly ICatalogService _service;

        public FilesController(ICatalogService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var brands = _service.GetCatalogBrands()
                .Select(b => new BrandDTO
                {
                    Id = b.Id,
                    Brand = b.Brand
                }).ToList();
            var serializer = new Serializing();

            var data = serializer.SerializeBinary(brands);

            return Ok(data);
        }

        [Serializable]
        public class BrandDTO
        {
            public int Id { get; set; }
            public string Brand { get; set; }
        }
    }
}
