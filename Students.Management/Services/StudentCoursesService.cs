using Students.Management.Library.Models;

public interface IStudentCoursesService
{
    List<KeyValuePair<int, int>> GetStudentCourse();
    void AddStudentToCourse(int studentId, int courseId);
}

public class StudentCoursesService : IStudentCoursesService
{

    private IStudentCourses _studentCoursesRepository;

    public StudentCoursesService(IStudentCourses studentCourses)
    {
        this._studentCoursesRepository = studentCourses;
    }
    public void AddStudentToCourse(int studentId, int courseId)
    {
        _studentCoursesRepository.AddStudentToCourse(studentId, courseId);
    }

    public List<KeyValuePair<int, int>> GetStudentCourse()
    {
        return _studentCoursesRepository.GetStudentCourses();
    }
}
