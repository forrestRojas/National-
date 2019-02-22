using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public class SiteDAO : ISiteDAO
    {
        public SiteDAO(string connectionString)
        {
        }

        public IList<Site> GetSites(int selectedCampground, DateTime arrivalDate, DateTime departureDate)
        {
            throw new NotImplementedException();
        }
    }
}
