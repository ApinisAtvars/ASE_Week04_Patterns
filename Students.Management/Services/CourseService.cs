using Students.Management.Library.Models;

public interface ICourseService
{
    List<Course> GetCourses();
    void AddCourse(Course course);
}

public class CourseService : ICourseService
{
    private ICourseRepository _courseRepository;
    private IStudentCourses _studentCourses;
    private IStudentRepository _studentRepository;

    public CourseService(ICourseRepository courseRepository, IStudentCourses studentCourses, IStudentRepository studentRepository)
    {
        this._courseRepository = courseRepository;
        this._studentRepository = studentRepository;
        this._studentCourses = studentCourses;
    }

    public List<Course> GetCourses()
    {
        var allcourses = _courseRepository.GetCourses();
        var studentcourses = _studentCourses.GetStudentCourses();
        var allstudents = _studentRepository.GetStudents();

        foreach (Course course in allcourses)
        {
            var currentStudentCourses = studentcourses.Where(c => c.Value == course.Id).ToList();

            course.Students = new List<Student>();
            foreach (var cs in currentStudentCourses)
            {
                var student = allstudents.Where(c => c.Id == cs.Key).SingleOrDefault();
                if (student != null)
                {
                    course.Students.Add(student);
                }
            }

        }
        return allcourses;
    }

    public void AddCourse(Course course)
    {
        _courseRepository.AddCourse(course);
    }
}