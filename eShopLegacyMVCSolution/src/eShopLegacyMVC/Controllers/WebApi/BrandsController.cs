using eShopLegacyMVC.Services;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eShopLegacyMVC.Controllers.WebApi
{
    public class BrandsController : ApiController
    {
        private ICatalogService service;

        public BrandsController(ICatalogService service)
        {
            this.service = service;
        }

        // GET api/<controller>
        public IEnumerable<Models.CatalogBrand> Get()
        {
            var brands = service.GetCatalogBrands();
            return brands;
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var brands = service.GetCatalogBrands();
            var brand = brands.FirstOrDefault(x => x.Id == id);
            if (brand == null) return NotFound();

            return Ok(brand);
        }

        [HttpDelete]
        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            var brandToDelete = service.GetCatalogBrands().FirstOrDefault(x => x.Id == id);
            if (brandToDelete == null)
            {
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            // demo only - don't actually delete
            return ResponseMessage(new HttpResponseMessage(HttpStatusCode.OK));
        }
    }
}