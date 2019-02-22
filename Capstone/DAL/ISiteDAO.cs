using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISiteDAO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="campgroundId"></param>
        /// <param name="arrivalDate"></param>
        /// <param name="departureDate"></param>
        /// <returns></returns>
        IList<Site> GetSites(int campgroundId, DateTime arrivalDate, DateTime departureDate);
    }
}
