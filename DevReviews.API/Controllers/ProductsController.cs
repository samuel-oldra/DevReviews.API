using AutoMapper;
using DevReviews.API.Entities;
using DevReviews.API.Models;
using DevReviews.API.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevReviews.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IProductRepository _repository;

        public ProductsController(IMapper mapper, IProductRepository repository)
        {
            this._mapper = mapper;
            this._repository = repository;
        }

        // GET: api/products
        /// <summary>
        /// Listagem de Produtos
        /// </summary>
        /// <returns>Lista de Produtos</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            Log.Information("Endpoint - GET: api/products");

            var products = await _repository.GetAllAsync();

            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);

            return Ok(productsViewModel);
        }

        // GET: api/products/{id}
        /// <summary>
        /// Detalhes do Produto
        /// </summary>
        /// <param name="id">ID do Produto</param>
        /// <returns>Lista um Produto</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            Log.Information("Endpoint - GET: api/products/{id}");

            var product = await _repository.GetDetailsByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var productDetails = _mapper.Map<ProductDetailsViewModel>(product);

            return Ok(productDetails);
        }

        // POST: api/products
        /// <summary>
        /// Cadastro de Produto
        /// </summary>
        /// <remarks>
        /// Requisição:
        /// {
        ///     "title": "Chinelo",
        ///     "description": "Havaianas tam. 41",
        ///     "price": 45
        /// }
        /// </remarks>
        /// <param name="model">Dados do Produto</param>
        /// <returns>Objeto criado</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="400">Dados inválidos</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(AddProductInputModel model)
        {
            Log.Information("Endpoint - POST: api/products");

            if (model.Description.Length > 50)
            {
                return BadRequest();
            }

            var product = new Product(model.Title, model.Description, model.Price);

            Log.Information("Método POST chamado!");

            await _repository.AddAsync(product);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, model);
        }

        // PUT: api/products/{id}
        /// <summary>
        /// Atualiza um Produto
        /// </summary>
        /// <remarks>
        /// Requisição:
        /// {
        ///     "description": "Havaianas tam. 42",
        ///     "price": 46
        /// }
        /// </remarks>
        /// <param name="id">ID do Produto</param>
        /// <param name="model">Dados do Produto</param>
        /// <returns>Objeto atualizado</returns>
        /// <response code="204">Sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Não encontrado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, UpdateProductInputModel model)
        {
            Log.Information("Endpoint - PUT: api/products/{id}");

            if (model.Description.Length > 50)
            {
                return BadRequest();
            }

            var product = await _repository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            product.Update(model.Description, model.Price);

            await _repository.UpdateAsync(product);

            return NoContent();
        }
    }
}