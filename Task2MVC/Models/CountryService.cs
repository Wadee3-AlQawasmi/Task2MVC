using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2MVC.Data;

namespace Task2MVC.Models
{
    public class CountryService:ICountryService
    {
        SysContext context;
        public CountryService(SysContext _SysContext)
        {
            context = _SysContext;
        }
        public List<Country> LoadCountries()
        {
           /* SysContext context = new SysContext();
            List<Country> LiCountry = (from cnt in context.country
                                       select cnt).ToList();*/
           List<Country> LiCountry = (context.country).ToList();
            return LiCountry;
        }
    }
}
