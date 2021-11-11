using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2MVC.Data;

namespace Task2MVC.Models
{
    public class VmEmployee
    {
        public Employee employee { set; get; }
        
        public List<Department> LiDepartment { set; get; }
        
        public List<Country>  LiCountry  { set; get; }
  
        public List<City> LiCity { set; get; }

    }
}
