using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2MVC.Data;

namespace Task2MVC.Models
{
    public class DepartmentService:IDepartmentService
    {
        SysContext context;
        public DepartmentService(SysContext _SysContext)
        {
            context = _SysContext;
        }

        public void Insert(Department dept)
        {
            /* SysContext context = new SysContext();*/
            context.department.Add(dept);
            context.SaveChanges();
            
        }

        public List<Department> LoadDepartments(string Name)
        {
            /* SysContext context = new SysContext();
            List<Department> lidepartments = (from d in context.department
                                              where d.Name == Name
                                              select d).ToList();*/
            List<Department> Lidepartments = (context.department.Where(d => d.Name == Name)).ToList();

            return Lidepartments;
        }

        public List<Department> LoadDepartments()
        {
            /* SysContext context = new SysContext();
            List<Department> Lidepartments =(from d in context.department
                                             select d).ToList();*/
            List<Department> Lidepartments = (context.department).ToList();

            return Lidepartments;

            
        }

        public Department LoadEmployee(int ID)
        {
            Department Dept = context.department.Find(ID);
            return Dept;
        }

    }
}
