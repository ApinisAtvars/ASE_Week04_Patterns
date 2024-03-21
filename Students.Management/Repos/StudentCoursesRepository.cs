public interface IStudentCourses
{
    List<KeyValuePair<int, int>> GetStudentCourses();
    void AddStudentToCourse(int studentId, int courseId);
}

public class StudentCoursesRepository : IStudentCourses
{
    public List<KeyValuePair<int, int>> GetStudentCourses()
    {
        List<KeyValuePair<int, int>> studentCourseList = new List<KeyValuePair<int, int>>();
        string[] lines = File.ReadAllLines("./Files/studentcourses.csv");

        foreach (var line in lines)
        {
            var columns = line.Split(",");
            KeyValuePair<int, int> keyValuePair = new KeyValuePair<int, int>(int.Parse(columns[0]), int.Parse(columns[1]));
            studentCourseList.Add(keyValuePair);
        }

        return studentCourseList;
    }

    public void AddStudentToCourse(int studentId, int courseId)
    {
        string[] studentcoursedetails = new string[]
        {
            studentId.ToString(),
            courseId.ToString()
        };

        using (StreamWriter sw = new StreamWriter("./Files/studentcourses.csv", true))
        {
            sw.WriteLine(string.Join(",", studentcoursedetails));
        }
    }
}