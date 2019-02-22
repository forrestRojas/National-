using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class ReservationDAO : IReservationDAO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public ReservationDAO(string connectionString)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteNumber"></param>
        /// <param name="reservationName"></param>
        /// <param name="arrivalDate"></param>
        /// <param name="departureDate"></param>
        public void MakeResrevation(int siteNumber, string reservationName, DateTime arrivalDate, DateTime departureDate)
        {
            throw new NotImplementedException();
        }
    }
}
