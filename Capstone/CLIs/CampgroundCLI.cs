using Capstone.DAL;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capstone.CLIs
{
    /// <summary>
    /// 
    /// </summary>
    public class CampgroundCLI : CLI
    {
        private const int sitePad = 15;

        private ICampgroundDAO campgroundDAO;
        private ISiteDAO siteDAO;
        private IReservationDAO reservationDAO;
        private Park park;

        /// <summary>
        /// /
        /// </summary>
        /// <param name="park"></param>
        /// <param name="campgroundDAO"></param>
        /// <param name="siteDAO"></param>
        /// <param name="reservationDAO"></param>
        public CampgroundCLI(Park park, ICampgroundDAO campgroundDAO, ISiteDAO siteDAO, IReservationDAO reservationDAO)
        {
            this.park = park;
            this.campgroundDAO = campgroundDAO;
            this.siteDAO = siteDAO;
            this.reservationDAO = reservationDAO;
        }

        /// <summary>
        /// Runs the menu
        /// </summary>
        public override void Run()
        {
            IList<Campground> campgrounds = campgroundDAO.GetCampgrounds(park.Id);
            CampgroundMenuHeader(campgrounds);
            DisplayCampgroundOptions();

            while (true)
            {
                int userInput = GetInteger("Pick One:", 0, campgrounds.Count);

                if (userInput == 1)
                {
                    CampgroundMenuHeader(campgrounds);

                    int selectedCampground = GetInteger("Which campground (enter 0 to cancel)?", -1, campgrounds.Count);
                    if (selectedCampground == 0)
                    {
                        break;
                    }


                    DateTime arrivalDate = GetDate("What is the arrival date (mm/dd/yyyy)?");
                    DateTime departureDate = GetDate("What is the departure date (mm/dd/yyyy)?");
                    Console.WriteLine();

                    // List of all Avaiable sites
                    IList<Site> sites = siteDAO.GetSites(campgrounds[selectedCampground - 1].Id, arrivalDate, departureDate);

                    // Displays site results
                    Console.WriteLine("Site No.".PadRight(sitePad) + "Max Occup.".PadRight(sitePad) + "Accessible?".PadRight(sitePad) + "Max RV Length".PadRight(sitePad) + "Utilty".PadRight(sitePad) + "Cost");
                    foreach (Site site in sites)
                    {
                        decimal cost = campgroundDAO.GetCampingCost(campgrounds[selectedCampground - 1].DailyFee, arrivalDate, departureDate);
                        Console.WriteLine($"{site.SiteNumber,-sitePad}{site.MaxOccupancy,-sitePad}{site.Accessible,-sitePad}{site.MaxRVLength,-sitePad}{site.Utilities,-sitePad}{cost:C2}");
                    }

                    // Book reservation
                    Console.WriteLine();
                    int siteNumber = GetInteger("Which site should be reserved (enter 0 to cancel)?");
                    string reservationName = GetString("What name should the reservation be made under?");

                    reservationDAO.GetReservations(sites[siteNumber - 1].SiteId);
                    Reservation newReservation = CreateReservation(sites[siteNumber - 1].SiteId, arrivalDate, departureDate, reservationName);
                    int reservationId = reservationDAO.BookResrevation(newReservation);

                    Console.Write($"The reservation has been made and the confirmation id is {reservationId}");
                    Console.ReadLine();
                    CampgroundMenuHeader(campgrounds);
                    DisplayCampgroundOptions();
                }
                else if (userInput == 2)
                {
                    break;
                }
                else
                {
                    InvalidInput();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="arrivalDate"></param>
        /// <param name="departureDate"></param>
        /// <param name="reservationName"></param>
        private static Reservation CreateReservation(int siteId, DateTime arrivalDate, DateTime departureDate, string reservationName)
        {
            Reservation newReservation = new Reservation();
            newReservation.SiteId = siteId;
            newReservation.Name = reservationName;
            newReservation.FromDate = arrivalDate;
            newReservation.ToDate = departureDate;
            newReservation.CreateDate = DateTime.Now;
            return newReservation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campgrounds"></param>
        private void CampgroundMenuHeader(IList<Campground> campgrounds)
        {
            Console.Clear();
            Console.WriteLine($"{park.Name} National Park Campgrounds");
            Console.WriteLine();
            Console.WriteLine("".PadRight(3) + "Name".PadRight(21) + "Open".PadRight(16) + "Close".PadRight(16) + "Daily Fee");

            int count = 1;
            foreach (Campground campground in campgrounds)
            {
                Console.WriteLine($"#{count} {campground.Name.PadRight(20)} {ReturnMonth(campground.OpenFrom).PadRight(15)} {ReturnMonth(campground.OpenTo).PadRight(15)} {campground.DailyFee:C2}");
                count++;
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void DisplayCampgroundOptions()
        {
            Console.WriteLine("Select a command");
            Console.WriteLine("1) Search for Available Reservation".PadLeft(3));
            Console.WriteLine("2) Return to Previous Screen".PadLeft(3));
        }
    }
}
