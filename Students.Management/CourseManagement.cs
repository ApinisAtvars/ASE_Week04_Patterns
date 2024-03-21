using Students.Management.Library.Models;

namespace Students.Management;

public class CourseManagement
{
    public StudentService studentService1;
    public CourseService courseService1;
    public StudentCoursesService studentCoursesService1;
    public CourseManagement()
    {
        StudentRepository studentRepository = new StudentRepository();
        StudentService studentService = new StudentService(studentRepository);
        studentService1 = studentService;

        CourseRepository courseRepository = new CourseRepository();
        CourseService courseService = new CourseService(courseRepository);
        courseService1 = courseService;

        StudentCoursesRepository studentCoursesRepository = new StudentCoursesRepository();
        StudentCoursesService studentCoursesService = new StudentCoursesService(studentCoursesRepository);
        studentCoursesService1 = studentCoursesService;

    }


    #region Public

    public void Menu()
    {
        int choice = 0;
        Console.WriteLine("Course Management System");

        while (choice != 99)
        {
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Course");
            Console.WriteLine("3. Add Student to Course");
            Console.WriteLine("4. List Students");
            Console.WriteLine("5. List Courses");
            Console.WriteLine("6. List Students in Course");
            Console.WriteLine("7. Total course price student is enrolled in");
            Console.WriteLine("99. Exit");
            choice = Convert.ToInt32(Console.ReadLine());
            ChooseAction(choice);
        }
    }

    #endregion

    #region Private

    private void ChooseAction(int choice)
    {

        switch (choice)
        {
            case 1:
                AddStudent();
                break;
            case 2:
                AddCourse();
                break;
            case 3:
                AddStudentToCourse();
                break;
            case 4:
                ListStudents();
                break;
            case 5:
                ListCourses();
                break;
            case 6:
                ListStudentsInCourse();
                break;
            case 7:
                TotalPriceStudentIsEnrolledIn();
                break;
            case 99:
                Console.WriteLine("Exiting");
                Environment.Exit(0);
                break;
            default:
                break;

        }
    }

    private void TotalPriceStudentIsEnrolledIn()
    {
        Console.WriteLine("Choose a student from the list by it's Id");
        studentService1.GetStudents().ForEach(s => Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Email: {s.Email}"));
        int studentId = Convert.ToInt32(Console.ReadLine());
        Student student = studentService1.GetStudents().Where(s => s.Id == studentId).FirstOrDefault();
        decimal totalPrice = 0;
        student.Courses.ForEach(c => totalPrice += c.Price);
        Console.WriteLine($"Total price of courses: €{totalPrice}");
    }

    private void ListStudentsInCourse()
    //TODO
    //PRINT EVERY STUDENT OUT
    {
        courseService1.GetCourses().ForEach(c => Console.WriteLine($"Id: {c.Id}, Name: {c.Name}, Price: {c.Price}"));
        Console.WriteLine("Enter Course Id");
        int desired_course = int.Parse(Console.ReadLine());
        List<int> students_in_course = new List<int>();
        foreach (KeyValuePair<int, int> keyValuePair in studentCoursesService1.GetStudentCourse())
        {
            if (keyValuePair.Value == desired_course)
            {
                students_in_course.Add(keyValuePair.Key);
            }
        }
        foreach (Student student in studentService1.GetStudents())
        {
            foreach (int id in students_in_course)
            {
                if (student.Id == id)
                {
                    Console.WriteLine($"Student: {student.Id}   Name: {student.Name}");
                }
            }
        }


    }

    private void ListCourses()
    {
        foreach (Course course in courseService1.GetCourses())
        {
            Console.WriteLine($"Id: {course.Id}, Name: {course.Name}, Price: €{course.Price}");
        }
    }

    private void ListStudents()
    {
        foreach (Student student in studentService1.GetStudents())
        {
            Console.WriteLine($"Student; {student.Id}   Name: {student.Name}");
        }
    }

    private void AddStudentToCourse()
    {

        Console.WriteLine("Choose a student from the list by it's Id");
        studentService1.GetStudents().ForEach(s => Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Email: {s.Email}"));
        int studentId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Choose a course from the list by it's Id");
        courseService1.GetCourses().ForEach(c => Console.WriteLine($"Id: {c.Id}, Name: {c.Name}, Price: €{c.Price}"));
        int courseId = Convert.ToInt32(Console.ReadLine());

        studentCoursesService1.AddStudentToCourse(studentId, courseId);


    }

    private void AddCourse()
    {
        Course course_to_add = new Course();
        Console.WriteLine("Enter course name:");
        course_to_add.Name = Console.ReadLine();
        Console.WriteLine("Enter the price:");
        course_to_add.Price = decimal.Parse(Console.ReadLine());
        courseService1.AddCourse(course_to_add);


    }

    private void AddStudent()
    {
        Console.WriteLine("Enter Student Name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Student Email");
        string email = Console.ReadLine();
        Console.WriteLine("Enter Student Class:");
        string studentclass = Console.ReadLine();
        Console.WriteLine("Enter Student Birthdate (d/m/YYYY)");
        DateOnly birthdate = DateOnly.Parse(Console.ReadLine());
        Student newstudent = new Student()
        {
            Name = name,
            Email = email,
            Class = studentclass,
            BirthDate = birthdate
        };
        studentService1.AddStudent(newstudent);
    }

    // private void Init()
    // {

    //     _students = new List<Student>(){
    //         new Student(){Id = 1, Name = "John", Email = "john@doe.com", Class = "A1", BirthDate = new DateOnly(2000,1,1), Courses = new List<Course>()},
    //         new Student(){Id = 2, Name = "Jane", Email = "jane@doe.com", Class = "B1", BirthDate = new DateOnly(2000,5,4),  Courses = new List<Course>()},
    //     };

    //     _courses = new List<Course>(){
    //         new Course(){Id = 1, Name = "C#", Price =  350M, Students = new List<Student>()},
    //         new Course(){Id = 2, Name = "Java", Price =  350M,   Students = new List<Student>()},
    //         new Course(){Id = 3, Name = "Python",  Price =  350M, Students = new List<Student>()},
    //         new Course(){Id = 4, Name = "JavaScript",  Price =  350M,  Students = new List<Student>()},
    //         new Course(){Id = 5, Name = "C++", Price =  350M,  Students = new List<Student>()},
    //         new Course(){Id = 6, Name = "PHP", Price =  350M,  Students = new List<Student>()},
    //         new Course(){Id = 7, Name = "Ruby",  Price =  150M, Students = new List<Student>()},
    //         new Course(){Id = 8, Name = "Swift", Price =  250M, Students = new List<Student>()},
    //     };

    //     _students[0].Courses.Add(_courses[0]);
    //     _students[0].Courses.Add(_courses[1]);
    //     _students[0].Courses.Add(_courses[2]);

    // }

    #endregion

}