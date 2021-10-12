using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoApp.DataAccess;
using ToDoApp.DataAccess.Models;
using ToDoApp.DataAccess.Repository;
using Xunit;

namespace ToDoApp.UnitTests
{
    public class UnitTests
    {
        [Fact]
        public void GetAll_ShouldReturnAllAssigments()
        {
            var options = new DbContextOptionsBuilder<AssignmentDbContext>()
                .UseInMemoryDatabase(databaseName: "Assignment")
                .Options;

            var dbContext = new AssignmentDbContext(options);

            SeedDb(dbContext);

            var repository = new AssignmentRepository(dbContext);

            var result = repository.GetAll();

            Assert.Equal(3, result.ToList().Count());
        }

        private void SeedDb(AssignmentDbContext dbContext)
        {
            List<Assignment> assignments = new()
            {
                new Assignment() { Caption = "Test", Text = " Test Test Test" },
                new Assignment() { Caption = "Test", Text = " Test Test Test" },
                new Assignment() { Caption = "Test", Text = " Test Test Test" },
                new Assignment() { Caption = "Test", Text = " Test Test Test" },
                new Assignment() { Caption = "Test", Text = " Test Test Test" },
            };
            dbContext.Assignments.AddRange(assignments);
            dbContext.SaveChanges();
        }
    }
}
