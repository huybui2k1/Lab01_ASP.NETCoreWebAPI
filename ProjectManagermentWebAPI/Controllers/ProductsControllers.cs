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

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = repository.GetProductById(id);
            if (product == null)
            {
                return NotFound(); // Trả về lỗi 404 nếu không tìm thấy sản phẩm
            }

            return product;
        }
        // POST api/<ProductsControllers>
        [HttpPost]
        public IActionResult PostProduct(Product p )
        {
            try
            {
                /*var context = new MyDbContext();
                context.Products.Add(p);
                context.SaveChanges();*/
                repository.SaveProduct(p);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        // PUT api/<ProductsControllers>/5
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product p)
        {
            var temp = repository.GetProductById(id);
            if(temp== null) return NotFound();
            repository.UpdateProduct(p);
            return NoContent();
        }

        // DELETE api/<ProductsControllers>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var temp = repository.GetProductById(id);
            if(temp== null) return NotFound();
            repository.DeleteProduct(temp);
            return NoContent();
        }
    }
}
