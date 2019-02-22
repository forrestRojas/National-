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
        }

        private void CampgroundMenuHeader(IList<Campground> campgrounds)
        {
            Console.Clear();
            Console.WriteLine($"{park.Name} National Park Campgrounds");
            Console.WriteLine();
            Console.WriteLine("" + "Name" + "Open" + "Close" + "Daily Fee");

            int count = 1;
            foreach (Campground campground in campgrounds)
            {
                Console.WriteLine($"{count}) {campground.Name}");
            }
        }
    }
}
