using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.Services;
using ProductManagementAPI.Models;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var product = _productService.GetById(id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Product product)
        {
            var createdProduct = _productService.Add(product);

            if (createdProduct == null)
            {
                return BadRequest();
            }

            return Created("api/products/" + createdProduct.Id, createdProduct);

        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Product product)
        {
            var updatedProduct = _productService.Update(id, product);

            if (updatedProduct == null)
            {
                return NotFound();
            }

            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            
            if (!_productService.Delete(id))
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}
