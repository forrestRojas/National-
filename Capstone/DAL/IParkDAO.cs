using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    /// <summary>
    /// Represents an <see cref="IParkDAO"/> interface.
    /// </summary>
    public interface IParkDAO
    {
        /// <summary>
        /// Returns a collection of all the <see cref="Park"/> objects in the database.
        /// </summary>
        /// <returns>An <see cref="IList{T}"/> collection of <see cref="Park"/> objects.</returns>
        IList<Park> GetParks();
    }
}
