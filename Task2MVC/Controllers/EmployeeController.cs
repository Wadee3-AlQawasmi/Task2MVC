using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Task2MVC.Data;
using Task2MVC.Models;

namespace Task2MVC.Controllers
{

    public class EmployeeController : Controller
    {
        IEmployeeService employeeServices;
        IDepartmentService departmentService;
        ICountryService countryService;
        ICityService cityService;
        IConfiguration configuration;
        SysContext SysContext;


        public EmployeeController(IConfiguration _configuration, IEmployeeService _employeeService, IDepartmentService _departmentService, ICountryService _countryService, ICityService _cityService, SysContext _SysContext)
        {
            employeeServices = _employeeService;
            departmentService = _departmentService;
            countryService = _countryService;
            cityService = _cityService;
            configuration = _configuration;
            SysContext = _SysContext;
        }
        public IActionResult index()
        {

            /*  SysContext context = new SysContext();
             List<Country> LiCountry = (from cnt in context.country
                                          select cnt).ToList();

               List<City>LiCity=(from ci in context.city
                                select ci).ToList();

               List<Department> LiDept = (from d in context.department
                                          select d).ToList();*/

            List<Department> LiDept = departmentService.LoadDepartments();
            List<Country> LiCountry = countryService.LoadCountries();
            List<City> LiCity = cityService.LoadCity();

            VmEmployee vm = new VmEmployee();
            vm.LiCountry = LiCountry;
            vm.LiCity = LiCity;
            vm.LiDepartment = LiDept;

            return View("EmployeeView", vm);
        }
        public IActionResult index1()
        {
            List<Employee> List = new List<Employee>();
            return View("EmployeeListView", List);
        }

        

        public IActionResult SaveNewEmployee(VmEmployee emp)
        {
            string path = configuration["Path1"];

            if (ModelState.IsValid)
            {
                string FilePath = Path.Combine(Directory.GetCurrentDirectory(), path, emp.employee.Image.FileName);
                emp.employee.Image.CopyTo(new FileStream(FilePath, FileMode.Create));
                emp.employee.path = "http://localhost/Task2MVC/ImagesFile/" + emp.employee.Image.FileName;

                employeeServices.Insert(emp.employee);
            }

            /*  SysContext context = new SysContext();
             context.employee.Add(emp.employee);
              context.SaveChanges();
            */
            /*List<Country> LiCountry = (from cnt in context.country
                                       select cnt).ToList();

            List<City> LiCity = (from ci in context.city
                                 select ci).ToList();

            List<Department> LiDept = (from d in context.department
                                       select d).ToList();
            */
            List<Department> LiDept = departmentService.LoadDepartments();
            List<Country> LiCountry = countryService.LoadCountries();
            List<City> LiCity = cityService.LoadCity();

            VmEmployee vm = new VmEmployee();
            vm.LiCountry = LiCountry;
            vm.LiCity = LiCity;
            vm.LiDepartment = LiDept;

            return View("EmployeeView", vm);
        }

        public IActionResult SearchEmployee()
        {
            string Name = Request.Form["TxtNameEmployee"];

            /*  SysContext context = new SysContext();
              List<Employee> liEmployees = (from e in context/.employee
                                                where e.FirstName == Name
                                                select e).ToList();*/

            List<Employee> liEmployees = employeeServices.LoadEmployee(Name);
            TempData["Name"] = Name;
            return View("EmployeeListView", liEmployees);

        }

        public IActionResult Delete(int ID)
        {
            string Name = Convert.ToString(TempData["Name"]);
            employeeServices.Delete(ID);

            List<Employee> liEmployees = employeeServices.LoadEmployee(Name);

            return View("EmployeeListView", liEmployees);
        }

        public IActionResult Edit(int ID)
        {
            Employee emp1 = employeeServices.Edit(ID);
            VmEmployee vm = new VmEmployee();

            List<Department> LiDept = departmentService.LoadDepartments();
            List<Country> LiCountry = countryService.LoadCountries();
            List<City> LiCity = cityService.LoadCity();

            vm.employee = emp1;
            vm.LiCountry = LiCountry;
            vm.LiCity = LiCity;
            vm.LiDepartment = LiDept;
            ViewBag.x = false; 
            
            return View("EmployeeView", vm);

        }

        public IActionResult Update(VmEmployee emp)
        {
            
            employeeServices.Update(emp);

            VmEmployee vm = new VmEmployee();
            List<Department> LiDept = departmentService.LoadDepartments();
            List<Country> LiCountry = countryService.LoadCountries();
            List<City> LiCity = cityService.LoadCity();

            vm.LiCountry = LiCountry;
            vm.LiCity = LiCity;
            vm.LiDepartment = LiDept;
            return View("EmployeeView",vm);
        }

      
        public IActionResult DepartmentList()
        {
            int dept = Convert.ToInt32(TempData["Dept"]);
            List<Employee> liEmployees = employeeServices.LoadEmployeeOfDepartment(dept);
             
            return View("EmployeeListView", liEmployees);
        }


    }
}
