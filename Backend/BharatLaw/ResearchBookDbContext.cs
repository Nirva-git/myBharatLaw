using BharatLaw.Models;
using Microsoft.EntityFrameworkCore;

namespace BharatLaw
{
    public class ResearchBookDbContext: DbContext
    {
        public ResearchBookDbContext(DbContextOptions<ResearchBookDbContext> options)
           : base(options)
        {
        }
        public DbSet<ResearchBook> ResearchBooks { get; set; }
    }
}
   