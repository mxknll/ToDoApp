using Microsoft.EntityFrameworkCore;
using System.Linq;
using ToDoApp.DataAccess.GenericRepository;
using ToDoApp.DataAccess.Models;

namespace ToDoApp.DataAccess.Repository
{
    public class AssignmentRepository : GenericRepository<Assignment>, IAssignmentRepository
    {
        public AssignmentRepository(AssignmentDbContext dbContext) : base(dbContext)
        {
        }

        public void DeleteAllFinishedAssignments()
        {
            _dbContext.RemoveRange(_dbContext.Assignments.Where(x => x.Status == "done"));
        }
    }
}
