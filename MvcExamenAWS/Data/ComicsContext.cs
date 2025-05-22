using Microsoft.EntityFrameworkCore;
using MvcExamenAWS.Models;

namespace MvcExamenAWS.Data
{
    public class ComicsContext: DbContext
    {
        public ComicsContext(DbContextOptions<ComicsContext> options): base(options) { }
        public DbSet<Comic> Comics { get; set; }
    }
}
