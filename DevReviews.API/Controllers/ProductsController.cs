using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using DevReviews.API.Entities;
using DevReviews.API.Models;
using DevReviews.API.Persistence;

namespace DevReviews.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly DevReviewsDbContext _dbContext;

        public ProductsController(DevReviewsDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        // GET: api/products
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _dbContext.Products;

            return Ok(products);
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public IActionResult GetById()
        {
            // Se não achar, retornar  NotFound()

            return Ok();
        }

        // POST: api/products
        [HttpPost]
        public IActionResult Post(AddProductInputModel model)
        {
            // Se tiver erros de validação, retornar BadRequest()

            var product = new Product(model.Title, model.Description, model.Price);

            _dbContext.Products.Add(product);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, model);
        }

        // PUT: api/products/{id}
        [HttpPut("{id}")]
        public IActionResult Put(UpdateProductInputModel model)
        {
            // Se tiver erros de validação, retornar BadRequest()
            // Se não existir produto com o id especificado, retornar NotFound()

            return NoContent();
        }
    }
}