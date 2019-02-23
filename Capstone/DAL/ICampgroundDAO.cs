using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL
{
    /// <summary>
    /// Represents an ICampgroundDAO Interface
    /// </summary>
    public interface ICampgroundDAO
    {
        /// <summary>
        /// Gets all campgrounds from a specified park.
        /// </summary>
        /// <param name="parkId">the park id that the list of campgrounds relate to.</param>
        /// <returns>An IList of campgrounds pretaining to the parkId</returns>
        IList<Campground> GetCampgrounds(int parkId);

        /// <summary>
        /// Gets the camping cost based on the total days spent there.
        /// </summary>
        /// <param name="dailyFee">The campground's daily fee.</param>
        /// <param name="arrivalDate">The arrival date of the revservation.</param>
        /// <param name="departureDate">The departure date of the revservation.</param>
        /// <returns>The cost of camping</returns>
        decimal GetCampingCost(decimal dailyFee, DateTime arrivalDate, DateTime departureDate);
    }
}
