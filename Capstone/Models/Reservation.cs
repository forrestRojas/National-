using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    /// <summary>
    /// Represents a reservation
    /// </summary>
    public class Reservation
    {
        /// <summary>
        /// A surrogate key for the reservation
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The campsite the reservation is for
        /// </summary>
        public int SiteId { get; set; }

        /// <summary>
        /// the name for the reservation
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the start date of the reservation
        /// </summary>
        public DateTime FromDate { get; set; }

        /// <summary>
        /// The end date of the reservation
        /// </summary>
        public DateTime ToDate { get; set; }

        /// <summary>
        /// the date the reservation was booked
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
