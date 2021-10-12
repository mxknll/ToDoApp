using System;
using ToDoApp.DataAccess;
using ToDoApp.DataAccess.Models;

namespace ToDoApp.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new AssignmentDbContext())
            {
                var assignment = new Assignment() { 
                    Caption = "Test",
                    Text = "Test Test Test"
                };

                ctx.Assignments.Add(assignment);
                ctx.SaveChanges();
            }
        }
    }
}
