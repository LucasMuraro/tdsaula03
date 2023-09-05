using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.API.Models;
using Events.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Aula03.Pages.Events
{
    public class Delete : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public ClientModel Event { get; set; }
        public String ErrorMessage {get;set;}
       
        public Delete(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null || _context.Clients == null) {
                return NotFound();
            } 
            
            var eventModel =  await _context.Clients.FirstOrDefaultAsync(m => m.EventId == id);

            if (eventModel == null) {
                return NotFound();
            } 

            if (saveChangesError.GetValueOrDefault()){
                ErrorMessage = String.Format("Delete {ID} failed. Try again", id);
            }
            Event = eventModel;
            
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id) {
            var emptyEvent = await _context.Clients.FindAsync(id);

            if (emptyEvent == null) {
                return NotFound();
            } 

            try {
                _context.Clients.Remove(emptyEvent);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Events/Index");
            } catch(DbUpdateException ex) {
                return RedirectToAction("./Delete", new { id, saveChangesError = true});
            }
        }
    }
}