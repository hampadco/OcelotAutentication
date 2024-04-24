using Microsoft.AspNetCore.Mvc;

namespace Student.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentmeController : ControllerBase
{
    //create a list of students
    private static List<Student> students = new List<Student>
    {
        new Student { Id = 1, Name = "John Doe", Age = 18 },
        new Student { Id = 2, Name = "sara jesika", Age = 19 },
        new Student { Id = 3, Name = "james bond", Age = 20 }
    };

    //get all students
    [HttpGet]
    public IEnumerable<Student> GetAllStudent()
    {
        return students;
    }

    //get student by id
    [HttpGet("{id}")]
    public Student GetStudentById(int id)
    {
        return students.FirstOrDefault(s => s.Id == id);
    }

    //add new student
    [HttpPost]
    public void AddStudent([FromBody] Student student)
    {
        students.Add(student);
    }
    
}



//Student

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}
