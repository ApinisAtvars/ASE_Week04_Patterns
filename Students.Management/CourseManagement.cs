using System.Globalization;
using Students.Management.Library.Models;

namespace Students.Management;

public class CourseManagement
{
    public StudentService studentService1;
    public CourseService courseService1;
    public StudentCoursesService studentCoursesService1;
    public CourseManagement()
    {

        StudentCoursesRepository studentCoursesRepository = new StudentCoursesRepository();
        StudentCoursesService studentCoursesService = new StudentCoursesService(studentCoursesRepository);
        studentCoursesService1 = studentCoursesService;

        CourseRepository courseRepository = new CourseRepository();
        StudentRepository studentRepository = new StudentRepository();

        CourseService courseService = new CourseService(courseRepository, studentCoursesRepository, studentRepository);
        courseService1 = courseService;

        StudentService studentService = new StudentService(studentRepository, studentCoursesRepository, courseRepository);
        studentService1 = studentService;
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
    {
        courseService1.GetCourses().ForEach(c => Console.WriteLine($"Id: {c.Id}, Name: {c.Name}, Price: {c.Price}"));
        Console.WriteLine("Enter Course Id");
        int desired_course = int.Parse(Console.ReadLine());

        foreach (Course course in courseService1.GetCourses())
        {
            if (course.Id == desired_course)
            {
                foreach (Student student in course.Students)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Student: {student.Name}");
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
            if (student.Courses != null)
            {
                foreach (Course course in student.Courses)
                {
                    Console.WriteLine($"Course: {course.Name}");
                }
            }
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
        string birthdate = Console.ReadLine();
        DateOnly dateOnly = DateOnly.Parse(birthdate, new CultureInfo("lv-LV"));
        Student newstudent = new Student()
        {
            Name = name,
            Email = email,
            Class = studentclass,
            BirthDate = dateOnly,
        };
        studentService1.AddStudent(newstudent);
    }

    #endregion

}