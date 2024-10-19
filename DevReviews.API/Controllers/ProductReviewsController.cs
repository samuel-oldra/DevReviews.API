using AutoMapper;
using DevReviews.API.Models;
using DevReviews.API.Services;
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
        private readonly IMapper mapper;

        private readonly IProductService productService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="productService"></param>
        public ProductReviewsController(
            IMapper mapper,
            IProductService productService)
        {
            this.mapper = mapper;
            this.productService = productService;
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

            var productReview = await productService.GetReviewByIdAsync(id);

            if (productReview == null)
                return NotFound();

            var productDetails = mapper.Map<ProductReviewDetailsViewModel>(productReview);

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

            var productReview = await productService.AddReviewAsync(productId, model);

            return CreatedAtAction(nameof(GetById), new { id = productReview.Id, productId = productId }, model);
        }
    }
}