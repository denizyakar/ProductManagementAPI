using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.Services;
using ProductManagementAPI.Models;
using ProductManagementAPI.Validators;
using FluentValidation;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IValidator<Product> _productValidator;

        public ProductsController(IProductService productService, IValidator<Product> productValidator)
        {
            _productService = productService; // DI
            _productValidator = productValidator;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            //throw new Exception("Test exception, is it working?");
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
            //validation
            var validationResult = _productValidator.Validate(product);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors); //bad request dondur
            }

            var createdProduct = _productService.Add(product);

            //if (createdProduct == null)
            //{
            //    return BadRequest();
            //}

            return Created("api/products/" + createdProduct.Id, createdProduct);

        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Product product)
        {
            //validation
            var validationResult = _productValidator.Validate(product);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

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
