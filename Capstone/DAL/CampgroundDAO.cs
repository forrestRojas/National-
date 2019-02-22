using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    class CampgroundDAO : ICampgroundDAO
    {
        private string connectionString;

        public CampgroundDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Campground> GetCampgrounds(int id)
        {
            List<Campground> campgrounds = new List<Campground>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM campground WHERE park_id = @parkid;", conn);
                    cmd.Parameters.AddWithValue("@parkid", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Campground camp = ConvertReaderToCampground(reader);
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
