using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    /// <summary>
    /// Represents a campsite
    /// </summary>
    public class Site
    {
        /// <summary>
        /// the id of the site
        /// </summary>
        public int SiteId { get; set; }

        /// <summary>
        /// the campground the site is associated with
        /// </summary>
        public int CampgroundId { get; set; }

        /// <summary>
        /// the arbitrary campsite number
        /// </summary>
        public int SiteNumber { get; set; }

        /// <summary>
        /// the maximum occupancy of the site
        /// </summary>
        public int MaxOccupancy { get; set; }

        /// <summary>
        /// indicates whether or not the campsite is handicap accessible
        /// </summary>
        public bool Accessible { get; set; }

        /// <summary>
        /// The maximum rv length that the campsite can fit. 0 indicates that no rv will fit at this campsite
        /// </summary>
        public int MaxRVLength { get; set; }

        /// <summary>
        /// Indicates whether or not the campsite provides access to utility hook up
        /// </summary>
        public bool Utilities { get; set; }
    }
}
