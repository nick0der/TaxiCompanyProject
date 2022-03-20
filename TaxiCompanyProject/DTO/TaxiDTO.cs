using System;
using TaxiCompanyProject.Models;

namespace TaxiCompanyProject.DTO
{
    public class TaxiDTO
    {

        public string color
        {
            get;
            set;
        }

        public string model
        {
            get;
            set;
        }

        public int seats
        {
            get;
            set;
        }

        public string trackNumber
        {
            get;
            set;
        }

        public Garage Garage
        {
            get;
            set;
        }

        public TaxiDTO()
        {

        }


    }
}
