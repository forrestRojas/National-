using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    /// <summary>
    /// Represents a <see cref="CampgroundDAO"/> class.
    /// </summary>
    public class CampgroundDAO : ICampgroundDAO
    {
        /// <summary>
        /// The SQL connection string.
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="CampgroundDAO"/> class based on the SQL <paramref name="databaseConnectionString"/>.
        /// </summary>
        /// <param name="databaseConnectionString">The SQL Connection string.</param>
        public CampgroundDAO(string databaseConnectionString)
        {
            this.connectionString = databaseConnectionString;
        }

        /// <summary>
        /// Returns a list of <see cref="Campground"/>s from a SQL database based on the given <paramref name="parkId"/>.
        /// </summary>
        /// <param name="parkId">the <see cref="Park.Id"/> the list of <see cref="Campground"/>s refer to.</param>
        /// <returns><see cref="IList{T}"/></returns>
        public IList<Campground> GetCampgrounds(int parkId)
        {
            List<Campground> campgrounds = new List<Campground>();

            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM campground WHERE park_id = @parkId;", conn);
                    cmd.Parameters.AddWithValue("@parkId", parkId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Campground camp = this.ConvertReaderToCampground(reader);
                        campgrounds.Add(camp);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error has occured retrieving the campgrounds from the database.");
                Console.WriteLine(ex.Message);
                throw;
            }

            return campgrounds;
        }

        /// <summary>
        /// Returns the camping cost of the total time during the reseveration.
        /// </summary>
        /// <param name="dailyFee">The <see cref="Campground.DailyFee"/></param>
        /// <param name="arrivalDate">The <see cref="Campground.OpenFrom"/> date</param>
        /// <param name="departureDate">The <see cref="Campground.OpenTo"/> date</param>
        /// <returns>The total cost of the stay</returns>
        public decimal GetCampingCost(decimal dailyFee, DateTime arrivalDate, DateTime departureDate)
        {
            return (decimal)(departureDate - arrivalDate).TotalDays * dailyFee;
        }

        /// <summary>
        /// Converts the SQL data from the <see cref="SqlDataReader"/> into a <see cref="Campground"/> obj.
        /// </summary>
        /// <param name="reader">The <see cref="SqlDataReader"/></param>
        /// <returns>A new <see cref="Campground"/></returns>
        private Campground ConvertReaderToCampground(SqlDataReader reader)
        {
            Campground campground = new Campground();

            campground.Id = Convert.ToInt32(reader["campground_id"]);
            campground.ParkId = Convert.ToInt32(reader["park_id"]);
            campground.Name = Convert.ToString(reader["name"]);
            campground.OpenFrom = Convert.ToInt32(reader["open_from_mm"]);
            campground.OpenTo = Convert.ToInt32(reader["open_to_mm"]);
            campground.DailyFee = Convert.ToDecimal(reader["daily_fee"]);

            return campground;
        }
    }
}
