using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    /// <summary>
    /// Represents a <see cref="Campground"/> class.
    /// </summary>
    public class Campground
    {
        /// <summary>
        /// Gets or sets the <see cref="Campground"/> Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the park the <see cref="Campground"/> is associated with.
        /// </summary>
        public int ParkId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Campground"/> name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the open date of the <see cref="Campground"/>.
        /// </summary>
        public int OpenFrom { get; set; }

        /// <summary>
        /// Gets or sets the closing date of the <see cref="Campground"/>.
        /// </summary>
        public int OpenTo { get; set; }

        /// <summary>
        /// Gets or sets the daily fee of the <see cref="Campground"/>.
        /// </summary>
        public decimal DailyFee { get; set; }
    }
}
