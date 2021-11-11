using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2MVC.Data;

namespace Task2MVC.Models
{
   public interface ICountryService
    {
        List<Country> LoadCountries();
    }
}
