using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using DevReviews.API.Models;

namespace DevReviews.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        // GET: api/products
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
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

            return CreatedAtAction(nameof(GetById), new { Id = 1 }, model);
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