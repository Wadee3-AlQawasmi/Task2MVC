using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2MVC.Data;

namespace Task2MVC.Models
{
    public class CityService:ICityService
    {
        SysContext context;
        public CityService(SysContext _SysContext)
        {
            context = _SysContext;
        }
        public List<City> LoadCity()
        {
            /* SysContext context = new SysContext();
            List<City> LiCity = (from ci in context.city
                                       select ci).ToList();*/
            List<City> liCity = (context.city).ToList();
            return liCity;
           
        }
    }
}
