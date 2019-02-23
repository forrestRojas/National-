using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class SiteDAO : ISiteDAO
    {
        // TODO add documention
        /// <summary>
        /// 
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseConnectionString"></param>
        public SiteDAO(string databaseConnectionString)
        {
            this.connectionString = databaseConnectionString;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="campgroundId"></param>
        /// <param name="arrivalDate"></param>
        /// <param name="departureDate"></param>
        /// <returns></returns>
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
                        Site site = ConvertReaderToSite(reader);
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
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
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
