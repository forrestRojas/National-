using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    /// <summary>
    /// Represents a campsite.
    /// </summary>
    public class Site
    {
        /// <summary>
        /// Gets or sets the id of the site.
        /// </summary>
        public int SiteId { get; set; }

        /// <summary>
        /// Gets or sets the campground the site is associated with.
        /// </summary>
        public int CampgroundId { get; set; }

        /// <summary>
        /// Gets or sets the arbitrary campsite number.
        /// </summary>
        public int SiteNumber { get; set; }

        /// <summary>
        /// Gets or sets the maximum occupancy of the site.
        /// </summary>
        public int MaxOccupancy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the campsite is handicap accessible.
        /// </summary>
        public bool Accessible { get; set; }

        /// <summary>
        /// Gets or sets the maximum rv length that the campsite can fit. 0 indicates that no rv will fit at this campsite.
        /// </summary>
        public int MaxRVLength { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the campsite provides access to utility hook up.
        /// </summary>
        public bool Utilities { get; set; }
    }
}
