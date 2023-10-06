using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagermentWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsControllers : ControllerBase
    {
        private IProductRepository repository = new ProductRepository();
        // GET: api/<ProductsControllers>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts() =>repository.GetProducts();
       

        // POST api/<ProductsControllers>
        [HttpPost]
        public IActionResult PostProduct (Product p )
        {
            repository.SaveProduct(p);
            return NoContent();
        }

        // PUT api/<ProductsControllers>/5
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product p)
        {
            var tmp = repository.GetProductById(id);
            if(p== null) return NotFound();
            repository.UpdateProduct(p);
            return NoContent();
        }

        // DELETE api/<ProductsControllers>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var p = repository.GetProductById(id);
            if(p== null) return NotFound();
            repository.DeleteProduct(p);
            return NoContent();
        }
    }
}
