using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/pagamento")]
    public class PagamentoController : ControllerBase
    {
        private readonly DataContext _context;
        public PagamentoController(DataContext context)
        {
            _context = context;
        }

        //POST: api/pagamento/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Pagamento pagamento)
        {
            _context.FormasPagamento.Add(pagamento);
            _context.SaveChanges();
            return Created("", pagamento);
        }

        //GET: api/formapagamento/list
        [HttpGet]
        [Route("list")]
        public IActionResult List() => Ok(_context.FormasPagamento.ToList());

    }
}