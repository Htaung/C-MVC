using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestMVC.DAO;
using TestMVC.Filters;
using TestMVC.Models;
using TestMVC.Service;
using TestMVC.ViewModel;

namespace TestMVC.Content
{
    public class BulkUploadController : AsyncController
    {
        // GET: BulkUpload
        [HeaderFooterFilter]
        [AdminFilter]
        public ActionResult Index()
        {
            return View(new FileUploadViewModel());
        }


        public void UploadEmployees(List<Employee> employees)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.employees.AddRange(employees);
            salesDal.SaveChanges();
        }

        
        [AdminFilter]
        [HandleError]
        public async Task<ActionResult> Upload(FileUploadViewModel model)
        {
            int t1 = Thread.CurrentThread.ManagedThreadId;

            List<Employee> employees = await Task.Factory.StartNew<List<Employee>>(() => GetEmployees(model));

            int t2 = Thread.CurrentThread.ManagedThreadId;

            EmployeeService bal = new EmployeeService();
            bal.UploadEmployees(employees);
            return RedirectToAction("getEmployeeListByEntity", "Employee");
        }

        private List<Employee> GetEmployees(FileUploadViewModel model)
        {
            List<Employee> employees = new List<Employee>();
            StreamReader csvreader = new StreamReader(model.fileUpload.InputStream);
            csvreader.ReadLine(); // Assuming first line is header
            while (!csvreader.EndOfStream)
            {
                var line = csvreader.ReadLine();
                var values = line.Split(',');//Values are comma separated
                Employee e = new Employee();
                e.FirstName = values[0];
                e.LastName = values[1];
                e.Salary = int.Parse(values[2]);
                employees.Add(e);
            }
            return employees;
        }
    }
}