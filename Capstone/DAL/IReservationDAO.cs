using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL
{
    public interface IReservationDAO
    {
        void MakeResrevation(int siteNumber, string reservationName, DateTime arrivalDate, DateTime departureDate);
    }
}
