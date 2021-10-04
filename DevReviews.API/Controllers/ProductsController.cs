using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;
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

        private readonly IMapper _mapper;

        public ProductsController(DevReviewsDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        // GET: api/products
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _dbContext.Products;

            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);

            return Ok(productsViewModel);
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Se não achar, retornar  NotFound()

            var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            var productDetails = _mapper.Map<ProductDetailsViewModel>(product);

            return Ok(productDetails);
        }

        // POST: api/products
        [HttpPost]
        public IActionResult Post(AddProductInputModel model)
        {
            // Se tiver erros de validação, retornar BadRequest()

            if (model.Description.Length > 50)
            {
                return BadRequest();
            }

            var product = new Product(model.Title, model.Description, model.Price);

            _dbContext.Products.Add(product);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, model);
        }

        // PUT: api/products/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateProductInputModel model)
        {
            // Se tiver erros de validação, retornar BadRequest()
            // Se não existir produto com o id especificado, retornar NotFound()

            if (model.Description.Length > 50)
            {
                return BadRequest();
            }

            var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            product.Update(model.Description, model.Price);

            return NoContent();
        }
    }
}