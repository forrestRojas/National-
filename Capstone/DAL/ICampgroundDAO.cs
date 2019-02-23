using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL
{
    /// <summary>
    /// Represents an <see cref="ICampgroundDAO"/> Interface.
    /// </summary>
    public interface ICampgroundDAO
    {
        /// <summary>
        /// Returns all the campgrounds from a specified <see cref="Park"/>.
        /// </summary>
        /// <param name="parkId">the <see cref="Park.Id"/> that the list of campgrounds relate to.</param>
        /// <returns>An <see cref="IList{T}"/> of campgrounds pretaining to the <paramref name="parkId"/>.</returns>
        IList<Campground> GetCampgrounds(int parkId);

        /// <summary>
        /// Returns the camping cost based on the total days spent there.
        /// </summary>
        /// <param name="dailyFee">The <see cref="Campground.DailyFee"/>.</param>
        /// <param name="arrivalDate">The <see cref="Reservation.FromDate"/>.</param>
        /// <param name="departureDate">The <see cref="Reservation.ToDate"/>.</param>
        /// <returns>The cost of camping.</returns>
        decimal GetCampingCost(decimal dailyFee, DateTime arrivalDate, DateTime departureDate);
    }
}
