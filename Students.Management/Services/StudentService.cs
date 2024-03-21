using Students.Management.Library.Models;

public interface IStudentService
{
    List<Student> GetStudents();
    void AddStudent(Student student);
}

public class StudentService : IStudentService
{
    private IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        this._studentRepository = studentRepository;
    }

    public void AddStudent(Student student)
    {
        _studentRepository.AddStudent(student);
    }
    public List<Student> GetStudents()
    {
        return _studentRepository.GetStudents();
    }
}