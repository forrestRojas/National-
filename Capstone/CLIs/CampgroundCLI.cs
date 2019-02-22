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

        public CampgroundCLI(Park park, ICampgroundDAO campgroundDAO, ISiteDAO siteDAO, IReservationDAO reservationDAO)
        {
            this.park = park;
            this.campgroundDAO = campgroundDAO;
            this.siteDAO = siteDAO;
            this.reservationDAO = reservationDAO;
        }

        public override void Run()
        {
            IList<Campground> campgrounds = campgroundDAO.GetCampgrounds(park.Id);
            CampgroundMenuHeader(campgrounds);
            Console.Read();
        }

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
            Console.WriteLine("");
            Console.WriteLine("Select a command");
            Console.WriteLine("1) Search for Available Reservation".PadLeft(3));
            Console.WriteLine("2) Return to Previous Screen".PadLeft(3));
        }
    }
}
