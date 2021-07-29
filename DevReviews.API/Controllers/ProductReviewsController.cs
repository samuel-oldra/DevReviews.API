using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using AutoMapper;
using DevReviews.API.Entities;
using DevReviews.API.Models;
using DevReviews.API.Persistence;

namespace DevReviews.API.Controllers
{
    [ApiController]
    [Route("api/products/{productId}/productreviews")]
    public class ProductReviewsController : ControllerBase
    {
        private readonly DevReviewsDbContext _dbContext;

        private readonly IMapper _mapper;

        public ProductReviewsController(DevReviewsDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        // GET: api/products/1/productreviews/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int productId, int id)
        {
            // Se não existir com o id especificado, retornar NotFound()
            var productReview = await _dbContext.ProductReviews.SingleOrDefaultAsync(p => p.Id == id);

            if (productReview == null)
            {
                return NotFound();
            }

            var productDetails = _mapper.Map<ProductReviewDetailsViewModel>(productReview);

            return Ok(productDetails);
        }

        // POST: api/products/1/productreviews
        [HttpPost]
        public async Task<IActionResult> Post(int productId, AddProductReviewInputModel model)
        {
            // Se tiver com dados inválidos, retornar BadRequest()
            var productReview = new ProductReview(model.Author, model.Rating, model.Comments, productId);

            await _dbContext.ProductReviews.AddAsync(productReview);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = productReview.Id, productId = productId }, model);
        }
    }
}