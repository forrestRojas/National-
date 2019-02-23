using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    /// <summary>
    /// Represents a <see cref="Park"/> class.
    /// </summary>
    public class Park
    {
        /// <summary>
        /// Gets or sets the id of the <see cref="Park"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Park"/> name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the location of the <see cref="Park"/>.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the date in which the <see cref="Park"/> was established.
        /// </summary>
        public DateTime EstablishedDate { get; set; }

        /// <summary>
        /// Gets or sets the size of <see cref="Park"/> in square kilometers.
        /// </summary>
        public int Area { get; set; }

        /// <summary>
        /// Gets or sets the annual number of visitors at the <see cref="Park"/>.
        /// </summary>
        public int Visitors { get; set; }

        /// <summary>
        /// Gets or sets the discription of the <see cref="Park"/>.
        /// </summary>
        public string Description { get; set; }
    }
}
