using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestMVC.Models;
using TestMVC.DAO;

namespace TestMVC.Service
{
    public class EmployeeService
    {
        public UserStatus GetUserValidity(UserDetails u)
        {
            if (u.UserName == "Admin" && u.Password == "Admin")
            {
                return UserStatus.AuthenticatedAdmin;
            }
            else if (u.UserName == "Sukesh" && u.Password == "Sukesh")
            {
                return UserStatus.AuthentucatedUser;
            }
            else
            {
                return UserStatus.NonAuthenticatedUser;
            }
        }

        public bool IsValidUser(UserDetails u)
        {
            if (u.UserName == "Admin" && u.Password == "Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Employee> getEmployees()
        {
            List<Employee> employees = new List<Employee>();
            Employee emp = new Employee();
            emp.FirstName = "Myo";
            emp.LastName = "Pa";
            emp.Salary = 150000;
            employees.Add(emp);

            emp = new Employee();
            emp.FirstName = "Aung";
            emp.LastName = "Aung";
            emp.Salary = 160000;
            employees.Add(emp);

            emp = new Employee();
            emp.FirstName = "Hay";
            emp.LastName = "Man";
            emp.Salary = 170000;
            employees.Add(emp);

            return employees;
        }

        public List<Employee> GetEmployeesByEntityFrameWork()
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            return salesDal.employees.ToList();
        }

        public Employee SaveEmployee(Employee e)
        {
            SalesERPDAL salesData = new SalesERPDAL();
            salesData.employees.Add(e);
            salesData.SaveChanges();
            return e;
        }
    }
}