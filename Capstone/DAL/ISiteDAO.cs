using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    /// <summary>
    /// Represents an <see cref="ISiteDAO"/> interface.
    /// </summary>
    public interface ISiteDAO
    {
        /// <summary>
        /// Returns a collection of all the <see cref="Site"/> objects in the database that are associated with the <paramref name="campgroundId"/> and are available during the specified <paramref name="arrivalDate"/> and <paramref name="departureDate"/>.
        /// </summary>
        /// <param name="campgroundId">The <see cref="Campground.Id"/>.</param>
        /// <param name="arrivalDate">The <see cref="Reservation.FromDate"/></param>
        /// <param name="departureDate">The <see cref="Reservation.ToDate"/>.</param>
        /// <returns>An <see cref="IList{T}"/> of <see cref="Site"/> objects.</returns>
        IList<Site> GetSites(int campgroundId, DateTime arrivalDate, DateTime departureDate);
    }
}
