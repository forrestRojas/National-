using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL
{
    public interface IReservationDAO
    {
        int MakeResrevation(int siteNumber, string reservationName, DateTime arrivalDate, DateTime departureDate);

         IList<ReservationDAO> GetReservations(int siteid);
    }
}
