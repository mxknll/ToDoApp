using ToDoApp.DataAccess.GenericRepository;
using ToDoApp.DataAccess.Models;

namespace ToDoApp.DataAccess.Repository
{
    public class AssignmentRepository : GenericRepository<Assignment>, IAssignmentRepository
    {
        public AssignmentRepository(AssignmentDbContext dbContext) : base(dbContext)
        {
        }
    }
}
