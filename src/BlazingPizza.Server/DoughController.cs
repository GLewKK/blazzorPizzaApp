using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingPizza.Server
{
    [Route("doughs")]
    [ApiController]
    public class DoughController : Controller
    {
        private readonly PizzaStoreContext _context;

        public DoughController(PizzaStoreContext context)
        {
            _context = context;
        }

        [HttpGet("{doughId}")]
        public async Task<ActionResult<DbDough>> GetDough(int doughId)
        {
            var dough = await _context.Doughs.FindAsync(doughId);

            if (dough == null)
            {
                return NotFound();
            }

            return Ok(dough);
        }
    }
}
