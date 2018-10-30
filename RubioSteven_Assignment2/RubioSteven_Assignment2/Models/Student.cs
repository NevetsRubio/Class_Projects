using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RubioSteven_Assignment2.Models
{
    public class Student
    {
        public Student()
        {
        }

        [Display(Name = "Student ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentID { get; set; }

        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 1)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 1)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Range(minimum: 0, maximum: 4)]
        [Display(Name = "GPA")]
        public double GPA { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Graduation Date")]
        public DateTime GraduationDate { get; set; }

        [Display(Name = "Active")]
        public bool Active { get; set; }

        [BindNever]
        public string AdditionalValue { get; set; }
    }
}
