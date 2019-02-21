using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    /// <summary>
    /// represents a campground
    /// </summary>
    public class Campground
    {
        /// <summary>
        /// the campground Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// the park the campground is associated with
        /// </summary>
        public int ParkId { get; set; }

        /// <summary>
        /// the campground name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the open date
        /// </summary>
        public int OpenFrom { get; set; }

        /// <summary>
        /// the closing date
        /// </summary>
        public int OpenTo { get; set; }

        /// <summary>
        /// the daily fee
        /// </summary>
        public decimal DailyFee { get; set; }
    }
}
