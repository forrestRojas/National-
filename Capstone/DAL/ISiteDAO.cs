using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public interface ISiteDAO
    {
        IList<Site> GetSites(int selectedCampground, DateTime arrivalDate, DateTime departureDate);
    }
}
