using APIDAY_1.Entity;
using APIDAY_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDAY_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class studentController : ControllerBase
    {
        UniverstyDb db;
        public studentController(UniverstyDb _db)
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {


            return Ok(db.Students.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(db.Students.Where(f => f.Id == id).ToList());
        }
        [HttpGet("{name:alpha}")]
        public IActionResult GetByName(string name)
        {
            return Ok(db.Students.Where(f => f.Name == name).ToList());
        }



        [HttpPost]
        public IActionResult Addstudent(Student stu)
        {
            db.Students.Add(stu);
            db.SaveChanges();
            
            return Ok( new {  message = "Student Added Succefully" });
        }


        [HttpDelete]
        public IActionResult deletestudent(int id)
        {
            var s = db.Students.Where(t => t.Id == id).FirstOrDefault();
            if (s != null)
            {
               
                db.Students.Remove(s);
                db.SaveChanges();
                return Ok(new
                {
                    message = $"Student with id  = {s.Id} deleted !"

                });
            }
            return NotFound();
        }
        [HttpPut("{id:int}")]
        public IActionResult updatestudent(int id, Student stud)
        {

            var s = db.Students.FirstOrDefault(t => t.Id == id);
            if (s != null)
            {
                s.Name=stud.Name;
                s.Address=stud.Address;
                s.Phone=stud.Phone;
                s.Age=stud.Age;
                db.SaveChanges();
                return Ok(new { message = "update successed" });
            }


            return BadRequest(ModelState);
        }


    }
}
