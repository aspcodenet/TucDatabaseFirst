using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TucDatabaseFirst.Data;

namespace TucDatabaseFirst.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _dbContext;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
            _dbContext.Database.Migrate();
            //var player = new HockeyPlayer
            //{
            //    JerseyNumber = 13,
            //    Namn = "Mats Sundin"
            //};
            //_dbContext.Players.Add(player);
            //_dbContext.SaveChanges();
        }

        public void OnGet()
        {

        }
    }
}
