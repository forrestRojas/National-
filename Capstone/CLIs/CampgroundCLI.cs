using Capstone.DAL;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capstone.CLIs
{
    public class CampgroundCLI : CLI
    {
        //private int selectedPark;

        private ICampgroundDAO campgroundDAO;
        private ISiteDAO siteDAO;
        private IReservationDAO reservationDAO;
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
            CampgroundMenuHeader(campgrounds);
            DisplayCampgroundOptions();

            while (true)
            {
                int userInput = GetInteger("Pick One:");

                if(userInput == 1)
                {
                    CampgroundMenuHeader(campgrounds);
                    int selectedCampground;
                    while (true)
                    {
                        selectedCampground = GetInteger("Which campground (enter 0 to cancel)?");
                        if (selectedCampground == 0)
                        {
                            break;
                        }
                        else if ((selectedCampground < 0 && selectedCampground >= campgrounds.Count))
                        {
                            InvalidInput();
                        }

                    }
                    if (selectedCampground == 0)
                    {
                        break;
                    }

                    DateTime arrivalDate = GetDate("What is the arrival date (mm/dd/yyyy)?");
                    DateTime departureDate = GetDate("What is the departure date (mm/dd/yyyy)?");
                    IList<Site> sites = siteDAO.GetSites(selectedCampground, arrivalDate, departureDate);


                    // TODO print campsites
                    //int count = 1;
                    foreach (Site site in sites)
                    {
                        decimal cost = campgroundDAO.GetCampingCost(campgrounds[selectedCampground - 1], arrivalDate, departureDate);
                        Console.Write($"{site.SiteNumber, -5}{site.MaxOccupancy, -5}{site.Accessible, -5}{site.MaxRVLength, -5}{site.Utilities, -5}{cost:C2}");
                    }

                    Console.WriteLine();
                    int siteNumber = GetInteger("Which site should be reserved (enter 0 to cancel)?");
                    string reservationName = GetString("What name should the reservation be made under?");
                    // TODO build reservationbooking
                    reservationDAO.MakeResrevation(siteNumber, reservationName, arrivalDate, departureDate);
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
