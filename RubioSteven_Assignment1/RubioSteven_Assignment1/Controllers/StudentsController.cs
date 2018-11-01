using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RubioSteven_Assignment1.Models;

namespace RubioSteven_Assignment1.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentContext _context;

        public StudentsController(StudentContext context)
        {
            _context = context;

            if (_context.Student.Count() == 0)
            {
                _context.Student.
                    Add(new Student
                    {
                        StudentID = 0,
                        LastName = "Rubio",
                        FirstName = "Steven",
                        GPA = 4.0,
                        GraduationDate = System.DateTime.Today,
                        Active = true
                    });
                _context.SaveChanges();
            }
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var Stud_List = _context.Student.ToList();

            foreach (var Stud in Stud_List)
            {
                if (Stud.GPA <= 2.0)
                {
                    Stud.AdditionalValue = "Academic Probation";
                }
                else if (Stud.GPA >= 3.4)
                {
                    Stud.AdditionalValue = "Dean's List";
                }
            }

            return View(await _context.Student.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Stud_List = _context.Student.ToList();

            foreach (var Stud in Stud_List)
            {
                if (Stud.GPA <= 2.0)
                {
                    Stud.AdditionalValue = "Academic Probation";
                }
                else if (Stud.GPA >= 3.4)
                {
                    Stud.AdditionalValue = "Dean's List";
                }
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentID,LastName,FirstName,GPA,GraduationDate,Active,AdditionalValue")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentID,LastName,FirstName,GPA,GraduationDate,Active,AdditionalValue")] Student student)
        {
            if (id != student.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Stud_List = _context.Student.ToList();

            foreach (var Stud in Stud_List)
            {
                if (Stud.GPA <= 2.0)
                {
                    Stud.AdditionalValue = "Academic Probation";
                }
                else if (Stud.GPA >= 3.4)
                {
                    Stud.AdditionalValue = "Dean's List";
                }
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.FindAsync(id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.StudentID == id);
        }
    }
}
