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
        private readonly int parkId;

        public CampgroundCLI(ICampgroundDAO campgroundDAO, int parkId)
        {
            this.campgroundDAO = campgroundDAO;
            this.parkId = parkId;
        }

        public override void Run()
        {
            //if (!IsVaildCamp(selectedCamp))
            //{
            //    throw new Exception();
            //}

        }


    }
}
