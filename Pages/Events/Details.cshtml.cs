using Events.API.Models;
using Events.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Aula03.Pages.Events
{
    public class Details : PageModel
    {
        private readonly AppDbContext _context;
        public ClientModel? Event { get; set; }
       
        public Details(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Clients == null) {
                return NotFound();
            } 
            
            var eventModel =  await _context.Clients.FirstOrDefaultAsync(m => m.EventId == id);

            if (eventModel == null) {
                return NotFound();
            } 
            Event = eventModel;
            
            return Page();
        }

    }
}