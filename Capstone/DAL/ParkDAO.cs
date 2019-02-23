using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    /// <summary>
    /// Represents a <see cref="ParkDAO"/> class.
    /// </summary>
    public class ParkDAO : IParkDAO
    {
        /// <summary>
        /// The SQL connection string.
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParkDAO"/> class based on the SQL <paramref name="databaseConnectionString"/>.
        /// </summary>
        /// <param name="databaseConnectionString">The SQL Connection string.</param>
        public ParkDAO(string databaseConnectionString)
        {
            this.connectionString = databaseConnectionString;
        }

        /// <summary>
        /// Returns a collection of <see cref="Park"/> objects.
        /// </summary>
        /// <returns>An <see cref="IList{T}"/> of <see cref="Park"/> objects.</returns>
        public IList<Park> GetParks()
        {
            List<Park> parks = new List<Park>();

            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM park ORDER BY name;", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Park park = ConvertReaderToPark(reader);
                        parks.Add(park);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occured retrieving parks from the database.");
                Console.WriteLine(ex.Message);
                throw;
            }

            return parks;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Park ConvertReaderToPark(SqlDataReader reader)
        {
            Park park = new Park();

            park.Id = Convert.ToInt32(reader["park_id"]);
            park.Name = Convert.ToString(reader["name"]);
            park.Location = Convert.ToString(reader["location"]);
            park.EstablishedDate = Convert.ToDateTime(reader["establish_date"]);
            park.Area = Convert.ToInt32(reader["area"]);
            park.Visitors = Convert.ToInt32(reader["visitors"]);
            park.Description = Convert.ToString(reader["description"]);

            return park;
        }
    }
}
