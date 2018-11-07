using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMVC.ViewModel
{
    public class EmployeeViewModel
    {
        public string EmployeeName { get; set; }
        public string Salary { get; set; }
        public string SalaryColor { get; set; }
        //public string UserName { get; set; }

        public EmployeeViewModel(String EmployeeName, String Salary)
        {
            this.EmployeeName = EmployeeName;
            this.Salary = Salary;
        }


    }
}