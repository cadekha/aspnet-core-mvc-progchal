namespace Assignment3.Models.Repository;

public interface IStudentRepository
{
    IEnumerable<Student> GetAll();
}
