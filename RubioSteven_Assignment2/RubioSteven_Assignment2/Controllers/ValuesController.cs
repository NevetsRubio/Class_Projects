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
            }
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
