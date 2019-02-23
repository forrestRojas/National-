using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    /// <summary>
    /// Represents a campsite <see cref="Site"/> object.
    /// </summary>
    public class Site
    {
        /// <summary>
        /// Gets or sets the id of the <see cref="Site"/>.
        /// </summary>
        public int SiteId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Campground"/> the <see cref="Site"/> is associated with.
        /// </summary>
        public int CampgroundId { get; set; }

        /// <summary>
        /// Gets or sets the arbitrary <see cref="Site"/> number.
        /// </summary>
        public int SiteNumber { get; set; }

        /// <summary>
        /// Gets or sets the maximum occupancy of the <see cref="Site"/>.
        /// </summary>
        public int MaxOccupancy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the <see cref="Site"/> is handicap accessible.
        /// </summary>
        public bool Accessible { get; set; }

        /// <summary>
        /// Gets or sets the maximum rv length that the <see cref="Site"/> can fit. 0 indicates that no RV will fit at this <see cref="Site"/>.
        /// </summary>
        public int MaxRVLength { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the <see cref="Site"/> provides access to utility hook up.
        /// </summary>
        public bool Utilities { get; set; }
    }
}
