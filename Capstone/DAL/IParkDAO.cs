using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL
{
    /// <summary>
    /// park interface
    /// </summary>
    public interface IParkDAO
    {
        /// <summary>
        /// Gets all parks
        /// </summary>
        /// <returns></returns>
        IList<Park> GetParks();
    }
}
