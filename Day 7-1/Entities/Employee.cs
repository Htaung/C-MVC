using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestMVC.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        
        //[Required(ErrorMessage="Enter First Name")]
        [FirstNameValidation]
        public String FirstName { get; set; }

        [StringLength(5, ErrorMessage="Last Name Length should not be greater than 5")]
        public String LastName { get; set; }

        public int Salary { get; set; }

        public bool hasValue()
        {
            return Salary !=0;
        }
    }
}