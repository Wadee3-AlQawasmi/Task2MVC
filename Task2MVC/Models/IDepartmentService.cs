using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2MVC.Data;

namespace Task2MVC.Models
{
   public interface IDepartmentService
    {
        void Insert(Department dept);

        List<Department> LoadDepartments(string Name);

        List<Department> LoadDepartments();

        Department LoadEmployee(int ID);
    }
}
