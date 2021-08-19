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
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _dbContext;

        public IndexModel(ILogger<IndexModel> logger,
            ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            Players = _dbContext.Players
                .Select(r => new PlayerListViewModel
                {
                    Id = r.Id,
                    JerseyNumber = r.JerseyNumber,
                    Name =  r.Namn

                }).ToList();

        }

        public List<PlayerListViewModel> Players { get; set; }

        public class PlayerListViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int JerseyNumber { get; set; }
        }
    }
}
