using Microsoft.AspNetCore.Mvc;
using Prova.Csharp.Data;
using Prova.Csharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.Csharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        readonly IBooksRepository _repository;

        public BooksController(IBooksRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var books = _repository.GetAll();

                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ex.Message
                });
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var book = _repository.GetById(id);

                if (book == null)
                    return NotFound();

                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ex.Message
                });
            }

        }

        [HttpPost]
        public IActionResult Post([FromServices] DataContext context, [FromBody] Book model)
        {
            try
            {
                var book = _repository.Create(model);

                return Created($"api/books/{book.Id}", book);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new
                {
                    ex.Message,
                    ex.ParamName
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ex.Message
                });
            }
        }
    }
}
