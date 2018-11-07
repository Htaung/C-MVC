using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC.Filters;
using TestMVC.Models;
using TestMVC.ViewModel;
using TestMVC.Service;


namespace TestMVC.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        //
        // GET: /Student/
        public ActionResult Index()
        {
            Employee emp = new Employee();
            emp.FirstName = "Sukesh";
            emp.LastName = "Marla";
            emp.Salary = 20000;
            //ViewData["Employee"] = emp;
            //ViewBag.Employee = emp;

            return View("MyView1", emp);
        }

        public ActionResult GetView()
        {
            Employee emp = new Employee();
            emp.FirstName = "Sukesh";
            emp.LastName="Marla";
            emp.Salary = 20000;

            EmployeeViewModel vmEmp = new EmployeeViewModel(emp.FirstName + " " + emp.LastName, emp.Salary.ToString("C"));
            if(emp.Salary>15000)
            {
                vmEmp.SalaryColor="yellow";
            }
            else
            {
                vmEmp.SalaryColor = "green";
            }

            //vmEmp.UserName = "Admin";

            return View("ViewModel", vmEmp);
        }

        [Authorize]
        public ActionResult getEmployeeList()
        {
            EmployeeListViewModel empListViewModel = new EmployeeListViewModel();
            
            EmployeeService empService = new EmployeeService();
            List<EmployeeViewModel> empListViewModels = new List<EmployeeViewModel>();

            List<Employee> employees = empService.getEmployees();
            foreach(Employee emp in  employees){
                EmployeeViewModel empViewModel = new EmployeeViewModel(emp.FirstName + " " + emp.LastName, emp.Salary.ToString("C"));
                if (emp.Salary > 15000)
                {
                    empViewModel.SalaryColor = "yellow";
                }
                else
                {
                    empViewModel.SalaryColor = "green";
                }
                empListViewModels.Add(empViewModel);   
            }
            empListViewModel.Employees = empListViewModels;
            empListViewModel.UserName = "Admin";
            return View("StudentView", empListViewModel);
        }

        [Route("Employee/List")]
        [HeaderFooterFilter]
        public ActionResult getEmployeeListByEntity()
        {
            EmployeeListViewModel empListViewModel = new EmployeeListViewModel();

            EmployeeService empService = new EmployeeService();
            List<EmployeeViewModel> empListViewModels = new List<EmployeeViewModel>();

            List<Employee> employees = empService.GetEmployeesByEntityFrameWork();
            Console.WriteLine("dsfsdf");
            foreach (Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel(emp.FirstName + " " + emp.LastName, emp.Salary.ToString("C"));
                if (emp.Salary > 15000)
                {
                    empViewModel.SalaryColor = "yellow";
                }
                else
                {
                    empViewModel.SalaryColor = "green";
                }
                empListViewModels.Add(empViewModel);
            }
            empListViewModel.Employees = empListViewModels;
            //empListViewModel.UserName = User.Identity.Name;
            //empListViewModel.FooterData = new FooterViewModel();
            //empListViewModel.FooterData.CompanyName = "Step by Step Schools";
            //empListViewModel.FooterData.Year = DateTime.Now.Year.ToString();
            return View("EmployeeEntityView", empListViewModel);
        }

        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult AddNew()
        {
            //return View("CreateEmployee");
            CreateEmployeeViewModel employeeListViewModel = new CreateEmployeeViewModel();
            //employeeListViewModel.FooterData = new FooterViewModel();
            //employeeListViewModel.FooterData.CompanyName = "StepByStepSchools";//Can be set to dynamic value
            //employeeListViewModel.FooterData.Year = DateTime.Now.Year.ToString();
            //employeeListViewModel.UserName = User.Identity.Name; //New Line
            //employeeListViewModel.UserName = HttpContext.Current.User.Identity.Name;  //New Line
            return View("CreateEmployee", employeeListViewModel);
        }

        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult saveEmployee(Employee emp, string btnSubmit)
        {
            switch (btnSubmit)
            {
                case "Save Employee":
                    if (ModelState.IsValid)
                    {
                        EmployeeService empService = new EmployeeService();
                        empService.SaveEmployee(emp);
                        return RedirectToAction("getEmployeeListByEntity");
                    }
                    else
                    {
                        CreateEmployeeViewModel vm = new CreateEmployeeViewModel();
                        vm.FirstName = emp.FirstName;
                        vm.LastName = emp.LastName;
                        if (emp.Salary != 0)
                        {
                            vm.Salary = emp.Salary.ToString();
                        }
                        else
                        {
                            vm.Salary = ModelState["Salary"].Value.AttemptedValue;
                        }
                        //vm.FooterData = new FooterViewModel();
                        //vm.FooterData.CompanyName = "StepByStepSchools";//Can be set to dynamic value
                        //vm.FooterData.Year = DateTime.Now.Year.ToString();
                        //vm.UserName = User.Identity.Name; //New Line


                        return View("CreateEmployee", vm); // Day 4 Change - Passing e here
                        //return View("CreateEmployee");
                    }
                    //return Content(emp.FirstName + " | " + emp.LastName + " | " + emp.Salary);
                case "Cancel":
                    return RedirectToAction("getEmployeeListByEntity");
            }
            return new EmptyResult();

        }

        public ActionResult GetAddNewLink()
        {
            if (Convert.ToBoolean(Session["IsAdmin"]))
            {
                return PartialView("AddNewLink");
            }
            else
            {
                return new EmptyResult();
            }
        }

	}
}