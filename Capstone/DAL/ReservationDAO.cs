using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL
{
    public class ReservationDAO : IReservationDAO
    {
        public ReservationDAO(string connectionString)
        {
        }

        public void MakeResrevation(int siteNumber, string reservationName, DateTime arrivalDate, DateTime departureDate)
        {
            throw new NotImplementedException();
        }
    }
}
