using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.models;
using ProductAPI.Repository;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository repository;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        //create action method 
        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await repository.GetAllProductsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal Server Error. Please Contact Support. " + ex.Message);
            }
            
        }

        //Get single product
        [HttpGet]
        [Route("GetProduct/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var product = await repository.GetProductByIdAsync(id);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal Server Error. Please Contact Support. " + ex.Message);
            }
        }

        // create a new product and insert it into the database
        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(ViewModel product)
        {
            try
            {
                //new project
                var query = new Product
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price
                };

                await repository.CreateProductAsync(query);

                return Ok("Product Successfully Created");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal Server Error. Please Contact Support. " + ex.Message);
            }

        }

        //edit product using id and replace values with the ones received in payload
        [HttpPut]
        [Route("EditProduct/{id}")]
        public async Task<IActionResult> EditProduct(int id, ViewModel product)
        {
            try
            {
                var newProduct = new Product
                {
                    Id = id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price

                };

                 newProduct = await repository.UpdateProductAsync(newProduct);

                if (newProduct == null)
                {
                    return BadRequest();
                }

                return Ok(newProduct);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal Server Error. Please Contact Support. " + ex.Message);
            }
        }

        //delete product using id endpoint
        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {

            try
            {
                var product = await repository.DeleteProductAsync(id);

                //check if returned product is null
                if (product == null)
                {
                    return BadRequest();
                }

                return Ok("Product Deleted Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal Server Error. Please Contact Support. " + ex.Message);
            }

        }

    }
}
