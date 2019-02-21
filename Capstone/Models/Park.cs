using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    /// <summary>
    /// Represents a park
    /// </summary>
    public class Park
    {
        /// <summary>
        /// the id of the park
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// the park name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the location of the park
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// the date in which the park was established
        /// </summary>
        public DateTime EstablishedDate { get; set; }

        /// <summary>
        /// the size of park in square kilometers
        /// </summary>
        public int Area { get; set; }

        /// <summary>
        ///  the annual number of visitors
        /// </summary>
        public int Visitors { get; set; }
        
        /// <summary>
        /// the discription of the park
        /// </summary>
        public string Description { get; set; }
    }
}
