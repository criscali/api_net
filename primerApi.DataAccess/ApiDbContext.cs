using Microsoft.EntityFrameworkCore;
using primerApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primerApi.DataAccess
{
    public class ApiDbContext : DbContext
    {
        public DbSet<FutbolTeam> futbolTeams { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

    }
}
