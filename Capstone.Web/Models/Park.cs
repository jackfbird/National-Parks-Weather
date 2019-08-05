﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Park
    {
        public string ParkCode { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Climate { get; set; }
        public string Quote { get; set; }
        public string QuoteSource { get; set; }
        public string Description { get; set; }
        public int Acreage { get; set; }
        public int ElevationInFeet { get; set; }
        public int MilesOfTrail { get; set; }
        public int NumberOfCampsites { get; set; }
        public int AnnualVisitorCount { get; set; }
        public int YearFounded { get; set; }
        public int EntryFee { get; set; }
        public int NumberofAnimalSpecies { get; set; }
        public string ParkImageName
        {
            get
            {
                return ParkCode.ToLower() + ".jpg";
            }
        }
        public int Temperature { get; set; }



    }
}
