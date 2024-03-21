using Students.Management.Library.Models;

public interface ICourseService
{
    List<Course> GetCourses();
    void AddCourse(Course course);
}

public class CourseService : ICourseService
{
    private ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        this._courseRepository = courseRepository;
    }

    public List<Course> GetCourses()
    {
        return _courseRepository.GetCourses();
    }

    public void AddCourse(Course course)
    {
        _courseRepository.AddCourse(course);
    }
}