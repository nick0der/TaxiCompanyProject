using System;

namespace TaxiCompanyProject.Models
{
    public class Taxi : BaseEntity
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

        public Taxi()
        {

        }


    }
}
