using Capstone.DAL;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capstone.CLIs
{
    /// <summary>
    /// Represent a main menu
    /// </summary>
    public class MainMenuCLI : CLI
    {
        const int padLength = 3;
        const int returnToInputLine = 2;

        /// <summary>
        /// 
        /// </summary>
        private IParkDAO parkDAO;
        private ICampgroundDAO campgroundDAO;
        private ISiteDAO siteDAO;
        private IReservationDAO reservationDAO;


        /// <summary>
        /// Creates a MainmenuCLI
        /// </summary>
        /// <param name="parkDAO"></param>
        public MainMenuCLI(IParkDAO parkDAO, ICampgroundDAO campgroundDAO, ISiteDAO siteDAO, IReservationDAO reservationDAO)
        {
            this.parkDAO = parkDAO;
            this.campgroundDAO = campgroundDAO;
            this.siteDAO = siteDAO;
            this.reservationDAO = reservationDAO;
        }
        
        /// <summary>
        /// Runs the main menu
        /// </summary>
        public override void Run()
        {
            IList<Park> parks = parkDAO.GetParks();
            MainMenuHeader(parks);

            while (true)
            {
                string input = GetString("Make selection here: ");
                bool isValidPark = false;


                if (int.TryParse(input, out int choice))
                {
                    choice--;

                    isValidPark = IsVaildPark(choice, parks);

                    if (isValidPark)
                    {
                        ParkCLI parkMenu = new ParkCLI(parks[choice], campgroundDAO, siteDAO, reservationDAO);
                        parkMenu.Run();
                        MainMenuHeader(parks);
                    }
                    else
                    {
                        // TODO write code for failed vaildation
                        Console.WriteLine($"{input} is Not a vaild park, please try again");
                        Console.CursorTop -= returnToInputLine;
                    }
                }
                else if (input.ToLower() == "q")
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
        /// Creates the header for the menu
        /// </summary>
        /// <param name="parks"></param>
        private static void MainMenuHeader(IList<Park> parks)
        {
            Console.Clear();
            Console.WriteLine("Select a Park for Further Details");

            int count = 1;
            foreach (Park park in parks)
            {
                Console.WriteLine($"{count}) {park.Name}".PadRight(padLength));
                count++;
            }
            Console.WriteLine("Q) Quit".PadRight(padLength));
        }

        /// <summary>
        /// Check if park is valid
        /// </summary>
        /// <param name="parkChoice"></param>
        /// <param name="parks"></param>
        /// <returns></returns>
        private bool IsVaildPark(int parkChoice, IList<Park> parks)
        {
            bool isValid = false;
            isValid = (parkChoice < parks.Count() && parkChoice >= 0) && (parks[parkChoice] != null);
            return isValid;
        }
    }
}
