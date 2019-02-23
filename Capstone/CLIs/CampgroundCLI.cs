using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capstone.DAL;
using Capstone.Models;

namespace Capstone.CLIs
{
    /// <summary>
    /// 
    /// </summary>
    public class CampgroundCLI : CLI
    {
        private const int SitePad = 15;

        private readonly ICampgroundDAO campgroundDAO;
        private readonly ISiteDAO siteDAO;
        private readonly IReservationDAO reservationDAO;
        private readonly Park park;

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
            this.CampgroundMenuHeader(campgrounds);
            DisplayCampgroundOptions();

            while (true)
            {
                int userInput = GetInteger("Pick One:", 0, campgrounds.Count);

                if (userInput == 1)
                {
                    this.CampgroundMenuHeader(campgrounds);

                    int selectedCampground = GetInteger("Which campground (enter 0 to cancel)?", -1, campgrounds.Count);
                    if (selectedCampground == 0)
                    {
                        break;
                    }

                    DateTime arrivalDate = GetDate("What is the arrival date (mm/dd/yyyy)?");
                    DateTime departureDate = GetDate("What is the departure date (mm/dd/yyyy)?");
                    Console.WriteLine();

                    // List of all Avaiable sites
                    IList<Site> sites = this.siteDAO.GetSites(campgrounds[selectedCampground - 1].Id, arrivalDate, departureDate);

                    // Displays site results
                    Console.WriteLine("Site No.".PadRight(SitePad) + "Max Occup.".PadRight(SitePad) + "Accessible?".PadRight(SitePad) + "Max RV Length".PadRight(SitePad) + "Utilty".PadRight(SitePad) + "Cost");
                    foreach (Site site in sites)
                    {
                        decimal cost = campgroundDAO.GetCampingCost(campgrounds[selectedCampground - 1].DailyFee, arrivalDate, departureDate);
                        Console.WriteLine($"{site.SiteNumber, -SitePad}{site.MaxOccupancy, -SitePad}{site.Accessible, -SitePad}{site.MaxRVLength, -SitePad}{site.Utilities, -SitePad}{cost:C2}");
                    }

                    // Book reservation
                    Console.WriteLine();
                    int siteNumber = GetInteger("Which site should be reserved (enter 0 to cancel)?");
                    string reservationName = GetString("What name should the reservation be made under?");

                    reservationDAO.GetReservations(sites[siteNumber - 1].SiteId);
                    Reservation newReservation = Reservation.CreateReservation(sites[siteNumber - 1].SiteId, arrivalDate, departureDate, reservationName);
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
        /// <param name="campgrounds"></param>
        private void CampgroundMenuHeader(IList<Campground> campgrounds)
        {
            Console.Clear();
            Console.WriteLine($"{this.park.Name} National Park Campgrounds");
            Console.WriteLine();
            Console.WriteLine(string.Empty.PadRight(3) + "Name".PadRight(21) + "Open".PadRight(16) + "Close".PadRight(16) + "Daily Fee");

            int count = 1;
            foreach (Campground campground in campgrounds)
            {
                Console.WriteLine($"#{count} {campground.Name.PadRight(20)} {this.ReturnMonth(campground.OpenFrom).PadRight(15)} {this.ReturnMonth(campground.OpenTo).PadRight(15)} {campground.DailyFee:C2}");
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
