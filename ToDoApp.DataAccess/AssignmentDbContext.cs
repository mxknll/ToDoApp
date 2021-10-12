using Microsoft.EntityFrameworkCore;
using ToDoApp.DataAccess.Models;

namespace ToDoApp.DataAccess
{
    public class AssignmentDbContext : DbContext
    {
        public AssignmentDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Assignment> Assignments { get; set; }
    }
}
