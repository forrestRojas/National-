using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    class CampgroundDAO : ICampgroundDAO
    {
        private string connectionString;

        public CampgroundDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Campground> GetCampgrounds()
        {
            throw new NotImplementedException();
        }
    }
}
