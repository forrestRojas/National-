using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    /// <summary>
    /// Represents an <see cref="IReservationDAO"/> interface.
    /// </summary>
    public interface IReservationDAO
    {
        /// <summary>
        /// Returns the the <see cref="Reservation.Id"/> of the booked <see cref="Reservation"/>, and adds the <see cref="Reservation"/> to the database.
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        int BookResrevation(Reservation reservation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteid"></param>
        /// <returns></returns>
        IList<Reservation> GetReservations(int siteid);
    }
}
