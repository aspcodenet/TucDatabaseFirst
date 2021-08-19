using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TucDatabaseFirst.Data;

namespace TucDatabaseFirst.Pages
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Id { get; set; }
        public string Namn { get; set; }
        public int JerseyNumber { get; set; }
        public string City { get; set; }

        public void OnGet(int id)
        {
            Id = id;
            var player = _context.Players.First(r => r.Id == Id);
            Namn = player.Namn;
            JerseyNumber = player.JerseyNumber;
            City = player.City;
        }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                var player = _context.Players.First(r => r.Id == id);
                player.Namn = Namn;
                player.City = City;
                player.JerseyNumber = JerseyNumber;
                _context.SaveChanges();
                return RedirectToPage("/Index");
            }

            return Page();
        }

    }
}
