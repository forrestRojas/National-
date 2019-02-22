using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public interface IReservationDAO
    {
        /// <summary>
        /// 
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
