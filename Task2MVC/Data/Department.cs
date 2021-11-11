using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task2MVC.Data
{
    [Table("Departments")]
    public class Department
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public List<Employee> liEmployees { set; get; }
    }
}
