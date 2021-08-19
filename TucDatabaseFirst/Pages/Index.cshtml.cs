using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TucDatabaseFirst.Data;

namespace TucDatabaseFirst.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        public string Query { get; set; }

        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _dbContext;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
            //var player = new HockeyPlayer
            //{
            //    JerseyNumber = 13,
            //    Namn = "Mats Sundin"
            //};
            //_dbContext.Players.Add(player);
            //_dbContext.SaveChanges();
        }

        public void OnGet(string query)
        {
            Query = query;
        }
        
    }
}
