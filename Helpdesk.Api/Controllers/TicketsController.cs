using Helpdesk.Api.Data;
using Helpdesk.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public TicketsController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Tickets (Read all)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
        {
            return await _context.Tickets.ToListAsync();
        }

        // POST: api/Tickets (Create new)
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(TicketDTO ticketDTO)
        {
            var ticket = new Ticket
            {
                Title = ticketDTO.Title,
                Description = ticketDTO.Description
                // Status, Priority, CreatedAt will use default values
            };
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTicket), new { id = ticket.Id }, ticket);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null) return NotFound();
            return ticket;
        }
    }
}