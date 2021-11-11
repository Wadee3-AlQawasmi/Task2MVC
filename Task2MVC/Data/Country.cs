using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task2MVC.Data
{
    [Table("Countries")]
    public class Country
    {
        public int ID { set; get; }
        public string Name { set; get; }

        public List<City> liCities { set; get; }
        public List<Employee> liEmployees { set; get; }


    }
}
