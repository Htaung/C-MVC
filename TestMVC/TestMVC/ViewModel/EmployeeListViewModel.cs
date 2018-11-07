using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMVC.ViewModel
{
    public class EmployeeListViewModel:BaseViewModel
    {
        public List<EmployeeViewModel> Employees{ get; set; }
        //public String UserName { get; set; }

        //public FooterViewModel FooterData { get; set; }//New Property

    }
}