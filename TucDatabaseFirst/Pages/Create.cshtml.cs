using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TucDatabaseFirst.Data;

namespace TucDatabaseFirst.Pages
{
    [Authorize(Roles="Admin, Coach")]
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public CreateModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Required(ErrorMessage = "Måste mata in dummer!")]
        public string Namn { get; set; }
        
        
        [Range(0,100)]
        public int JerseyNumber { get; set; }

        public string City { get; set; }

        [MaxLength(6)]
        public string Regno { get; set; }

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
