using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TucDatabaseFirst.Data;

namespace TucDatabaseFirst.Pages
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public CreateModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string Namn { get; set; }
        public int JerseyNumber { get; set; }
        public string City { get; set; }
        

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var player = new HockeyPlayer();
                player.Namn = Namn;
                player.JerseyNumber = JerseyNumber;
                player.City = City;
                _dbContext.Players.Add(player);
                _dbContext.SaveChanges();
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}
