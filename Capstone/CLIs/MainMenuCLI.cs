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

        private IParkDAO parkDAO;

        public MainMenuCLI(IParkDAO parkDAO)
        {
            this.parkDAO = parkDAO;
        }
        
        /// <summary>
        /// Runs the main menu
        /// </summary>
        public override void Run()
        {
            string error = "";
            IList<Park> parks = parkDAO.GetParks();
            while (true)
            {
                Console.Clear();
                Console.WriteLine(error);
                error = "";
                Console.WriteLine("Select a Park for Further Details");


                int count = 1;
                foreach (Park park in parks)
                {
                    Console.WriteLine($"{count}) {park.Name}".PadRight(padLength));
                    count++;
                }

                Console.WriteLine("Q) Quit".PadRight(padLength));

                string input = GetString("Make selection here: ");

                if (int.TryParse(input, out int choice))
                {
                    CampgroundCLI campground = new CampgroundCLI();
                    campground.Run(choice);
                }
                else if (input.ToLower() == "q")
                {
                    break;
                }
                else
                {
                    error = "Please select a correct input.";
                }
            }
        }
    }
}
