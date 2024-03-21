using Students.Management.Library.Models;

public interface ICourseRepository
{
    List<Course> GetCourses();
    void AddCourse(Course course);
}

public class CourseRepository : ICourseRepository
{
    public List<Course> GetCourses()
    {
        List<Course> courses = new List<Course>();
        string[] lines = File.ReadAllLines("./Files/courses.csv");

        foreach (var line in lines)
        {
            var columns = line.Split(",");
            Course course = new Course();
            course.Id = int.Parse(columns[0]);
            course.Name = columns[1];
            course.Price = decimal.Parse(columns[2]);

            courses.Add(course);
        }

        return courses;
    }

    public void AddCourse(Course course)
    {
        var allcourses = GetCourses();
        int maxid = allcourses.Max(s => s.Id);
        maxid++;
        course.Id = maxid;

        string[] coursedetails = new string[]
        {
            course.Id.ToString(),
            course.Name,
            course.Price.ToString()
        };

        using (StreamWriter sw = new StreamWriter("./Files/courses.csv", true))
        {
            sw.WriteLine(string.Join(",", coursedetails));
        }
    }

}