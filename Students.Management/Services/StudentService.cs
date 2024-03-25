using Students.Management.Library.Models;

public interface IStudentService
{
    List<Student> GetStudents();
    void AddStudent(Student student);
}

public class StudentService : IStudentService
{
    private IStudentRepository _studentRepository;
    private IStudentCourses _studentCourseRepository;
    private ICourseRepository _courseRepository;

    public StudentService(IStudentRepository studentRepository, IStudentCourses studentCourses, ICourseRepository courseRepository)
    {
        this._studentRepository = studentRepository;
        this._courseRepository = courseRepository;
        this._studentCourseRepository = studentCourses;
    }

    public void AddStudent(Student student)
    {
        _studentRepository.AddStudent(student);
    }
    public List<Student> GetStudents()
    {
        var allstudents = _studentRepository.GetStudents();
        var studentCourses = _studentCourseRepository.GetStudentCourses();
        var allcourses = _courseRepository.GetCourses();

        foreach (Student student in allstudents)
        {
            var currentStudentCourses = studentCourses.Where(c => c.Key == student.Id).ToList();

            student.Courses = new List<Course>();
            foreach (var cs in currentStudentCourses)
            {
                var course = allcourses.Where(c => c.Id == cs.Value).SingleOrDefault();
                if (course != null)
                {
                    student.Courses.Add(course);
                }
            }
        }
        return allstudents;
    }
}