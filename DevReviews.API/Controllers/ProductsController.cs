using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevReviews.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController: ControllerBase
    {
        // GET: api/products
        public IActionResult GetAll() {
            return Ok();
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public IActionResult GetById() {
            // Se não achar, retornar  NotFound()

            return Ok();
        }

        // POST: api/products
        [HttpPost]
        public IActionResult Post(AddProductInputModel model) {
            // Se tiver erros de validação, retornar BadRequest()

            return CreatedAtAction(nameOf(GetById), new { Id = 1}, model);
        }

        // PUT: api/products/{id}
        [HttpPut("{id}")]
        public IActionResult Put(UpdateProductInputModel model) {
            // Se tiver erros de validação, retornar BadRequest()
            // Se não existir produto com o id especificado, retornar NotFound()

            return NoContent();
        }
    }
}