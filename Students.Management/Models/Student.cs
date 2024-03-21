namespace Students.Management.Library.Models;

public class Student{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Class { get; set; }
    public DateOnly BirthDate { get; set; }
    public List<Course> Courses { get; set; }
}
