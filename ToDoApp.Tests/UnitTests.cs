using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoApp.DataAccess;
using ToDoApp.DataAccess.Models;
using ToDoApp.DataAccess.Repository;
using Xunit;

namespace ToDoApp.Tests
{
    public class UnitTests : TestBase
    {
        [Fact]
        public void GetAll_ReturnsAllAssigments()
        {
            var result = repository.GetAll();

            Assert.Equal(5, result.ToList().Count());
        }

        [Fact]
        public void Insert_InsertsOneAssignmentWithStatusNew()
        {
            repository.Insert(new Assignment()
            {
                Text = "Lala",
            });
            repository.Save();

            var result = repository.GetAll();

            Assert.Equal(6, result.ToList().Count());
            Assert.Equal("new", result.Last().Status);
        }

        [Fact]
        public void DeleteAllFinishedAssignments_DeletesTwoAssignments()
        {
            repository.DeleteAllFinishedAssignments();
            repository.Save();

            var result = repository.GetAll();

            Assert.Equal(3, result.ToList().Count());
        }

    }
}
