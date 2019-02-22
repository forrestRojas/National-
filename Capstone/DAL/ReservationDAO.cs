using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class ReservationDAO : IReservationDAO
    {
        private readonly string connectionString;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public ReservationDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteNumber"></param>
        /// <param name="reservationName"></param>
        /// <param name="arrivalDate"></param>
        /// <param name="departureDate"></param>
        public int MakeResrevation(int siteId, string reservationName, DateTime arrivalDate, DateTime departureDate)
        {
            try
            {
                Reservation newReservation = new Reservation();
                newReservation.SiteId = siteId;
                newReservation.Name = reservationName;
                newReservation.FromDate = arrivalDate;
                newReservation.ToDate = departureDate;
                newReservation.CreateDate = DateTime.Now;

                using (SqlConnection conn = new SqlConnection(connectionString))
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
