using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2MVC.Data;

namespace Task2MVC.Models
{
  public interface IEmployeeService
    {
        void Insert(Employee emp);
        List<Employee> LoadEmployee(string Name);
        void Delete(int ID);

        Employee Edit(int ID);

        void Update(VmEmployee emp);

        List<Employee> LoadEmployeeOfDepartment(int ID);
    }
}
