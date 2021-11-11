using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2MVC.Data;

namespace Task2MVC.Models
{
    public class EmployeeService:IEmployeeService
    {
        SysContext context;
        public EmployeeService(SysContext _SysContext)
        {
            context = _SysContext;
        }
        public void Insert(Employee emp)
        {
            /*SysContext context = new SysContext();*/
            context.employee.Add(emp);
            context.SaveChanges();
        }

        public List<Employee> LoadEmployee(string Name)
        {
            /*SysContext context = new SysContext();
            List<Employee> liEmployees = (from e in context.employee
                                          where e.FirstName == Name
                                          select e).ToList();*/
            List<Employee> liEmployees = (context.employee.Where(e => e.FirstName == Name)).ToList();
            return liEmployees;
        }

        public void Delete(int ID)
        {
            Employee emp1 = context.employee.Find(ID);
            context.employee.Remove(emp1);
            context.SaveChanges();
        }

        public Employee Edit(int ID)
        {
           Employee emp= context.employee.Find(ID);
           return emp;
        }

       
      public void Update(VmEmployee emp)
        {
            context.employee.Attach(emp.employee);
            context.Entry(emp.employee).State = EntityState.Modified;
            context.SaveChanges();
        }
        public List<Employee> LoadEmployeeOfDepartment(int ID)
        {
            List<Employee> liEmployees = (context.employee.Where(e => e.Dept_Id ==ID )).ToList();
            return liEmployees;
        }
    }

    
}
