using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    /// <summary>
    /// Represents a <see cref="Reservation"/> class.
    /// </summary>
    public class Reservation
    {
        /// <summary>
        /// Gets or sets A surrogate key for the <see cref="Reservation"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the campsite the <see cref="Reservation"/> is for.
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
    }
}
