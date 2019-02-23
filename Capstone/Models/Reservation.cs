using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    /// <summary>
    /// Represents a <see cref="Reservation"/> object.
    /// </summary>
    public class Reservation
    {
        /// <summary>
        /// Gets or sets A surrogate key for the <see cref="Reservation"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Site"/> the <see cref="Reservation"/> is for.
        /// </summary>
        public int SiteId { get; set; }

        /// <summary>
        /// Gets or sets the name for the <see cref="Reservation"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the start date of the <see cref="Reservation"/>.
        /// </summary>
        public DateTime FromDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the <see cref="Reservation"/>.
        /// </summary>
        public DateTime ToDate { get; set; }

        /// <summary>
        /// Gets or sets the date the <see cref="Reservation"/> was booked.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Returns a newly created <see cref="Reservation"/> object.
        /// </summary>
        /// <remarks>The Reservation Id will be <c>null</c> until either added to the database or asigned explicitly.</remarks>
        /// <param name="siteId">The <see cref="SiteId"/>.</param>
        /// <param name="arrivalDate">The <see cref="FromDate"/>.</param>
        /// <param name="departureDate">The <see cref="ToDate"/>.</param>
        /// <param name="reservationName">The <see cref="Name"/>.</param>
        /// <returns>A new <see cref="Reservation"/>.</returns>
        public static Reservation CreateReservation(int siteId, DateTime arrivalDate, DateTime departureDate, string reservationName)
        {
            Reservation newReservation = new Reservation();
            newReservation.SiteId = siteId;
            newReservation.Name = reservationName;
            newReservation.FromDate = arrivalDate;
            newReservation.ToDate = departureDate;
            newReservation.CreateDate = DateTime.Now;
            return newReservation;
        }
    }
}
