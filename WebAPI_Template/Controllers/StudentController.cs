using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Template.Models;

namespace WebAPI_Template.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // Tạo danh sách Student
        List<Students> data = new List<Students>()
        {
            new Students("SV01","Nguyen To Anh", 20),
            new Students("SV02","Nguyen To Xinh", 20),
            new Students("SV03","Nguyen Minh Anh", 20),
            new Students("SV04","Min Min", 20),

        };
        //GET: api/Student
        [HttpGet]
        public IActionResult GetAllStudent()
        {
            return Ok(data);
        }
        [HttpGet("search")]
        public IActionResult GetAllStudentById(string Id)
        {
            Students student = new Students();
            if (Id == null)
            {
                return BadRequest();
            }
            else
            {
                student = data.FirstOrDefault(student => student.Code == Id);
                return Ok(student);

            }
        }
        [HttpPost("insert")]
        public IActionResult InsertStudent(Students student)
        {
            if (student == null)
            {
                return BadRequest(string.Empty);
            }
            else
            {
              //  Students s = data.FirstOrDefault(st => st.Code == student.Code);
                var s = data.SingleOrDefault(data => data.Code.Equals(student.Code));
                if(s != null)
                {
                    return BadRequest();
                }
                else
                {
                    data.Add(student);
                    return Ok(data);
                }

             
            }
           
        }
        [HttpPut]
        public IActionResult UpdateStudent(Students st)
        {
            Students s = data.FirstOrDefault(student => student.Code == st.Code);
            if (s == null)
            {
                return BadRequest();
            }
            else
            {
                s.Name = st.Name;
                s.Age = st.Age;

                return Ok(data);
            }
           
        }
        [HttpPost("delete")]
        public IActionResult DeleteStudent(string Id)
        {
            Students s = data.FirstOrDefault(student => student.Code == Id);
            if (s == null)
            {
                return NotFound();
            }
            else
            {
                data.Remove(s);

                return Ok(data);

            }
          
        }
    }
}
