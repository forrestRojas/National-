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

        private IParksDAO parkDAO;
        
        /// <summary>
        /// Runs the main menu
        /// </summary>
        public override void Run()
        {
            IList<Park> parks = parkDAO.GetParks();

            Console.WriteLine("Select a Park for Further Details");


            int count = 1;
            foreach (Park park in parks)
            {
                Console.WriteLine($"{count}) {park.Name}".PadRight(padLength));
                count++;
            }

            Console.WriteLine("Q) quit".PadRight(padLength));
        }
    }
}
