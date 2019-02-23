using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    /// <summary>
    /// Represents a <see cref="SiteDAO"/> class.
    /// </summary>
    public class SiteDAO : ISiteDAO
    {
        /// <summary>
        /// The SQL connection string.
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="SiteDAO"/> class based on the SQL <paramref name="databaseConnectionString"/>.
        /// </summary>
        /// <param name="databaseConnectionString">The SQL Connection string.</param>
        public SiteDAO(string databaseConnectionString)
        {
            this.connectionString = databaseConnectionString;
        }

        /// <summary>
        /// Returns a collection of all the <see cref="Site"/> objects in the database that are associated with the <paramref name="campgroundId"/> and are available during the specified <paramref name="arrivalDate"/> and <paramref name="departureDate"/>.
        /// </summary>
        /// <param name="campgroundId">The <see cref="Campground.Id"/>.</param>
        /// <param name="arrivalDate">The <see cref="Reservation.FromDate"/>.</param>
        /// <param name="departureDate">The <see cref="Reservation.ToDate"/>.</param>
        /// <returns>An <see cref="IList{T}"/> of <see cref="Site"/> objects.</returns>
        public IList<Site> GetSites(int campgroundId, DateTime arrivalDate, DateTime departureDate)
        {
            List<Site> sites = new List<Site>();

            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM site WHERE campground_id = @campgroundid AND site_id NOT IN (SELECT site_id FROM reservation WHERE (@departureDate > from_date AND @departureDate < to_date) OR (@arrivalDate > from_date AND @arrivalDate < to_date) OR (@arrivalDate < from_date AND @departureDate > to_date));", conn);
                    cmd.Parameters.AddWithValue("@campgroundid", campgroundId);
                    cmd.Parameters.AddWithValue("@departureDate", departureDate);
                    cmd.Parameters.AddWithValue("@arrivalDate", arrivalDate);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Site site = this.ConvertReaderToSite(reader);
                        sites.Add(site);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error has occured retrieving the sites from the database.");
                Console.WriteLine(ex.Message);
                throw;
            }

            return sites;
        }

        /// <summary>
        /// Converts the Park Table data from the <see cref="SqlDataReader"/> into a <see cref="Site"/> object.
        /// </summary>
        /// <param name="reader">The <see cref="SqlDataReader"/>.</param>
        /// <returns>A new <see cref="Site"/>.</returns>
        private Site ConvertReaderToSite(SqlDataReader reader)
        {
            Site site = new Site();
            site.SiteId = Convert.ToInt32(reader["site_id"]);
            site.CampgroundId = Convert.ToInt32(reader["campground_id"]);
            site.SiteNumber = Convert.ToInt32(reader["site_number"]);
            site.MaxOccupancy = Convert.ToInt32(reader["max_occupancy"]);
            site.Accessible = Convert.ToBoolean(reader["accessible"]);
            site.MaxRVLength = Convert.ToInt32(reader["max_rv_length"]);
            site.Utilities = Convert.ToBoolean(reader["utilities"]);

            return site;
        }
    }
}
