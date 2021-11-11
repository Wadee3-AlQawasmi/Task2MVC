using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task2MVC.Data
{
    [Table("Cities")]
    public class City
    {
        public int ID { set; get; }
        public string Name { set; get; }

        [ForeignKey("country")]
        public int Country_Id { set; get; }
        public Country country { set; get; }
        public List<Employee> liEmployees { set; get; }
    }
}
