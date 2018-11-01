using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RubioSteven_Assignment2.Models;

namespace RubioSteven_Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly StudentDataContext _context;

        public ValuesController(StudentDataContext context)
        {
            _context = context;

            if(_context.StudentItems.Count() == 0)
            {
                _context.StudentItems.
                    Add(new Student
                    {
                        StudentID = 0,
                        LastName = "Rubio",
                        FirstName = "Steven",
                        GPA = 4.0,
                        GraduationDate = System.DateTime.Today,
                        Active = true,
                        AdditionalValue = "He's alright, I guess."
                    });
                _context.SaveChanges();
            }
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            return _context.StudentItems.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            var item = _context.StudentItems.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            return item;
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student item)
        {
            _context.StudentItems.Add(item);
            _context.SaveChanges();
            return item;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Student item)
        {
            var currentItem = _context.StudentItems.Find(id);
            if (currentItem == null)
            {
                return NotFound();
            }

            currentItem.LastName = item.LastName;
            currentItem.FirstName = item.FirstName;
            currentItem.GPA = item.GPA;
            currentItem.GraduationDate = item.GraduationDate;
            currentItem.Active = item.Active;
            currentItem.AdditionalValue = item.AdditionalValue;

            _context.StudentItems.Update(currentItem);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var currentItem = _context.StudentItems.Find(id);
            if (currentItem == null)
            {
                return NotFound();
            }

            _context.StudentItems.Remove(currentItem);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
