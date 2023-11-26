using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookOrder_Test8.Data;
using BookOrder_Test8.Models;
using BookOrder_Test8.MatchMaker;
using System.Collections.Generic;
using System.Text.Json;

namespace BookOrder_Test8.Controllers
{
    [Route("api/BookOrdersController")]
    [ApiController]
    public class BookOrdersController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly IreadJson _readjson;
        private readonly ImatchAlgorithms _matchAlgorithms;

        public BookOrdersController(TodoContext context, IreadJson readJson, ImatchAlgorithms matchAlgorithms)
        {
            _context = context;
            _readjson = readJson;
            _matchAlgorithms = matchAlgorithms;

        }

        // GET: api/BookOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookOrder>>> GetBookOrders()
        {
            //readjson.ReadInput();

            var result= new JsonResult(_readjson.ReadInput(), new JsonSerializerOptions
            {
                ReferenceHandler = null,
                WriteIndented = true
            });

            var tstlist = _readjson.ReadInput();

           var tst= _matchAlgorithms.PriceTimePriority(tstlist);

            return new JsonResult(_readjson.ReadInput(), new JsonSerializerOptions
            {
                ReferenceHandler = null,
                WriteIndented = true
            }); 

            //return await readjson.ReadInput();

            //return await _context.BookOrders.ToListAsync();
        }

        // GET: api/BookOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookOrder>> GetBookOrder(string id)
        {
            var bookOrder = await _context.BookOrders.FindAsync(id);

            if (bookOrder == null)
            {
                return NotFound();
            }

            return bookOrder;
        }

        // PUT: api/BookOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookOrder(string id, BookOrder bookOrder)
        {
            if (id != bookOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookOrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookOrder>> PostBookOrder(BookOrder bookOrder)
        {
            _context.BookOrders.Add(bookOrder);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookOrderExists(bookOrder.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetBookOrder), new { id = bookOrder.Id }, bookOrder);
        }

        // DELETE: api/BookOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookOrder(string id)
        {
            var bookOrder = await _context.BookOrders.FindAsync(id);
            if (bookOrder == null)
            {
                return NotFound();
            }

            _context.BookOrders.Remove(bookOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookOrderExists(string id)
        {
            return _context.BookOrders.Any(e => e.Id == id);
        }
    }
}
