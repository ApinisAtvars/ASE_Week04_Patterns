using Students.Management.Library.Models;

public interface IStudentRepository
{
    List<Student> GetStudents();
    void AddStudent(Student student);
}

public class StudentRepository : IStudentRepository
{
    public void AddStudent(Student student)
    {
        var allstudents = GetStudents();
        int maxid = allstudents.Max(s => s.Id);
        maxid++;
        student.Id = maxid;

        string[] studentdetails = new string[]
        {
            student.Id.ToString(),
            student.Name,
            student.Email,
            student.Class,
            student.BirthDate.ToString()
        };

        using (StreamWriter sw = new StreamWriter("./Files/students.csv", true))
        {
            sw.WriteLine(string.Join(",", studentdetails));
        }
    }

    public List<Student> GetStudents()
    {
        List<Student> students = new List<Student>();
        string[] lines = File.ReadAllLines("./Files/students.csv");
        foreach (var line in lines)
        {
            var columns = line.Split(",");
            Student student = new Student();
            student.Id = int.Parse(columns[0]);
            student.Name = columns[1];
            student.Email = columns[2];
            student.Class = columns[3];
            student.BirthDate = DateOnly.Parse(columns[4]);
        }
        return students;
    }
}