using ToDoApp.DataAccess.GenericRepository;
using ToDoApp.DataAccess.Models;

namespace ToDoApp.DataAccess.Repository
{
    public interface IAssignmentRepository : IGenericRepository<Assignment>
    {
        void DeleteAllFinishedAssignments();
    }
}
