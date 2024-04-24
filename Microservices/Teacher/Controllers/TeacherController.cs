using Microsoft.AspNetCore.Mvc;

namespace Teacher.Controllers;

[ApiController]
[Route("[controller]")]
public class TeachermeController : ControllerBase
{
    //create a list of Teachers
    private static List<Teacher> Teachers = new List<Teacher>
    {
        new Teacher { Id = 1, Name ="Ali", Age = 30 },
        new Teacher { Id = 2, Name ="Ahmed", Age = 35 },
        new Teacher { Id = 3, Name ="Sara", Age = 25 }
       
    };

    //get all Teachers
    [HttpGet]
    public IEnumerable<Teacher> GetAllTeacher()
    {
        return Teachers;
    }

    //get Teacher by id
    [HttpGet("{id}")]
    public Teacher GetTeacherById(int id)
    {
        return Teachers.FirstOrDefault(s => s.Id == id);
    }

    //add new Teacher
    [HttpPost]
    public void AddTeacher([FromBody] Teacher Teacher)
    {
        Teachers.Add(Teacher);
    }
    
}



//Teacher

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}
