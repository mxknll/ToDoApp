using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.DataAccess;
using ToDoApp.DataAccess.Models;
using ToDoApp.DataAccess.Repository;

namespace ToDoApp.Tests
{
    public abstract class TestBase : IDisposable
    {
        private AssignmentDbContext dbContext;
        protected AssignmentRepository repository;

        protected TestBase()
        {
            var options = new DbContextOptionsBuilder<AssignmentDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            dbContext = new AssignmentDbContext(options);

            SeedDb(dbContext);

            repository = new AssignmentRepository(dbContext);
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        private void SeedDb(AssignmentDbContext dbContext)
        {
            List<Assignment> assignments = new()
            {
                new Assignment() { Text = " Test Test Test", Status = "done" },
                new Assignment() { Text = " Test Test Test", Status = "active" },
                new Assignment() { Text = " Test Test Test" },
                new Assignment() { Text = " Test Test Test", Status = "done" },
                new Assignment() { Text = " Test Test Test" },
            };
            dbContext.Assignments.RemoveRange(dbContext.Assignments);

            dbContext.Assignments.AddRange(assignments);
            dbContext.SaveChanges();
        }
    }


}
