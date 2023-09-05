using Events.API.Models;
using Events.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Aula03.Pages.Events
{
    public class Index : PageModel
    {
        private readonly AppDbContext _context;
        public List<ClientModel> ClientList { get; set; } =new();
       
        public Index(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            ClientList = await _context.Clients!.ToListAsync();
            return Page();
        }
    }
}