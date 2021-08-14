using AutoMapper;
using DevReviews.API.Entities;
using DevReviews.API.Models;
using DevReviews.API.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Threading.Tasks;

namespace DevReviews.API.Controllers
{
    [ApiController]
    [Route("api/products/{productId}/productreviews")]
    public class ProductReviewsController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IProductRepository _repository;

        public ProductReviewsController(IMapper mapper, IProductRepository repository)
        {
            this._mapper = mapper;
            this._repository = repository;
        }

        // GET: api/products/{productId}/productreviews/{id}
        /// <summary>
        /// Detalhes do Review
        /// </summary>
        /// <param name="productId">ID do Produto</param>
        /// <param name="id">ID do Review</param>
        /// <returns>Mostra um Review</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int productId, int id)
        {
            Log.Information("Endpoint - GET: api/products/{productId}/productreviews/{id}");

            // TODO: productId não é usado para nada
            var productReview = await _repository.GetReviewByIdAsync(id);

            if (productReview == null)
            {
                return NotFound();
            }

            var productDetails = _mapper.Map<ProductReviewDetailsViewModel>(productReview);

            return Ok(productDetails);
        }

        // POST: api/products/{productId}/productreviews
        /// <summary>
        /// Cadastro de Review
        /// </summary>
        /// <remarks>
        /// Requisição:
        /// {
        ///     "rating": 5,
        ///     "author": "Joana",
        ///     "comments": "Confortável"
        /// }
        /// </remarks>
        /// <param name="productId">ID do Produto</param>
        /// <param name="model">Dados do Review</param>
        /// <returns>Objeto criado</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="400">Dados inválidos</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(int productId, AddProductReviewInputModel model)
        {
            Log.Information("Endpoint - POST: api/products/{productId}/productreviews");

            var productReview = new ProductReview(model.Author, model.Rating, model.Comments, productId);

            await _repository.AddReviewAsync(productReview);

            return CreatedAtAction(nameof(GetById), new { id = productReview.Id, productId = productId }, model);
        }
    }
}