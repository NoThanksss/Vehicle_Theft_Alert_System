using System;
using System.Collections.Generic;
using System.Text;
using Vehicle_Theft_Alert_System_BLL.Models;

namespace Vehicle_Theft_Alert_System_BLL.Interfaces
{
    public interface ICountryService
    {
        IEnumerable<Country> GetAllCountrys();
        Country AddNewCountry(Country country);
        void DeleteCountry(Guid id);
        Country UpdateCountry(Country updatedCountry);
        Country GetCountryById(Guid id);

    }
}
