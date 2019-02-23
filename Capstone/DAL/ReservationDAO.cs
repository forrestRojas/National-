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
    public class ReservationDAO : IReservationDAO
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseConnectionString"></param>
        public ReservationDAO(string databaseConnectionString)
        {
            this.connectionString = databaseConnectionString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteid"></param>
        /// <returns></returns>
        public IList<Reservation> GetReservations(int siteid)
        {
            List<Reservation> res = new List<Reservation>();

            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM reservation WHERE site_id = @siteid ORDER BY from_date", conn);
                    cmd.Parameters.AddWithValue("@siteid", siteid);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Reservation reservation = this.ConvertReaderToRes(reader);
                        res.Add(reservation);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error retrieving reservation information.");
                Console.WriteLine(ex.Message);
                throw;
            }

            return res;
        }

        /// <summary>
        /// Creates a new reservation
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Reservation ConvertReaderToRes(SqlDataReader reader)
        {
            Reservation res = new Reservation();

            res.Id = Convert.ToInt32(reader["reservation_id"]);
            res.SiteId = Convert.ToInt32(reader["site_id"]);
            res.Name = Convert.ToString(reader["name"]);
            res.FromDate = Convert.ToDateTime(reader["from_date"]);
            res.ToDate = Convert.ToDateTime(reader["to_date"]);
            res.CreateDate = Convert.ToDateTime(reader["create_date"]);

            return res;
        }

        /// <summary>
        /// Books a reservation
        /// </summary>
        /// <param name="siteNumber"></param>
        /// <param name="reservationName"></param>
        /// <param name="arrivalDate"></param>
        /// <param name="departureDate"></param>
        public int BookResrevation(Reservation newReservation)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO reservation VALUES ((@site_id), (@name), (@from_date), (@to_date), (@create_date));", conn);
                    cmd.Parameters.AddWithValue("@site_id", newReservation.SiteId);
                    cmd.Parameters.AddWithValue("@name", newReservation.Name);
                    cmd.Parameters.AddWithValue("@from_date", newReservation.FromDate);
                    cmd.Parameters.AddWithValue("@to_date", newReservation.ToDate);
                    cmd.Parameters.AddWithValue("@create_date", newReservation.CreateDate);

                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("SELECT MAX(reservation_id) FROM reservation;", conn);
                    int id = Convert.ToInt32(cmd.ExecuteScalar());

                    return id;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Something went wrong...");
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
