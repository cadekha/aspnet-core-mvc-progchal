using Assignment3.Data;
using Assignment3.Models;
using Assignment3.Models.Repository;

namespace Assignment3.Models.DataManager;

public class StudentManager : IStudentRepository
{
    private readonly AssignmentDbContext _context;

    public StudentManager(AssignmentDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Student> GetAll()
    {
        return _context.Students.ToList();
    }

}
