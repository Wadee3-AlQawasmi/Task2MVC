using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2MVC.Data;
using Task2MVC.Models;
namespace Task2MVC.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentService departmentServices;
        public DepartmentController (IDepartmentService _departmentService)
        {
            departmentServices = _departmentService;
        }
        public IActionResult Index()
        {
            return View("DepartmentView");
        }

        public IActionResult Index1()
        {
            List<Department> list = new List<Department>();
            return View("DepratmentListView",list);
        }

        public IActionResult SaveNewDepartment(Department department)
        {
            /* SysContext context = new SysContext();
             context.department.Add(department);
             context.SaveChanges();*/
            departmentServices.Insert(department);
            return View("DepartmentView");
        }

        public IActionResult SearchDepartment()
        {
            string Name= Request.Form["TxtNameDepartment"];
            /* SysContext context = new SysContext();
             List<Department> lidepartments = (from d in context.department
                                                where d.Name == Name
                                                select d).ToList();*/
            List<Department> lidepartments = departmentServices.LoadDepartments(Name);
            return View("DepratmentListView",lidepartments);
        }

          public IActionResult SelectEmployee(int ID)
          {
              TempData["Dept"] = ID;
              return RedirectToAction("DepartmentList", "Employee");
                
          }
    }


}
