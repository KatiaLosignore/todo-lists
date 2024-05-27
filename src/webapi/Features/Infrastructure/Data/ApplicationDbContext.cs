using Microsoft.EntityFrameworkCore;
using shared.Domain.Entities;

namespace webapi.Features.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Todolist> Lists => Set<Todolist>();

        public DbSet<Todoitem> Items => Set<Todoitem>();
    }


}