using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Task2MVC.helpers;

namespace Task2MVC.Data
{
    [Table("Employees")]
    public class Employee
    {
        public int ID { set; get; }

        [Required]
        public string FirstName { set; get; }
        
        [Required]
        public string LastName { set; get; }
        
        public int Phone { set; get; }
        
        [Required]
        public string Gender { set; get; }
        public string Address { set; get; }
        public string Email { set; get; }
        public double Salary { set; get; }
        public double ExpectedSalary { set; get; }

        [HireDateValidation]
        public DateTime? HireDate { set; get; }
        public string path { get; set; }
     
        [NotMapped]
        public IFormFile Image { set; get; }

        [ForeignKey("country")]
        public int Country_Id { set; get; }
        public Country country { set; get; }
        
        [ForeignKey("city")]
        public int city_Id { set; get; }
        public City city { set; get; }

        [ForeignKey("department")]
        public int Dept_Id { set; get; }
        public Department department { set; get; }

    }
}
