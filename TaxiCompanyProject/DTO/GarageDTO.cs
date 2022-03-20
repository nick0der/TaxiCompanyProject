using System;
using TaxiCompanyProject.Models;

namespace TaxiCompanyProject.DTO
{
    public class GarageDTO
    {

        public string number
        {
            get;
            set;
        }

        public int area
        {
            get;
            set;
        }

        public Department Department
        {
            get;
            set;
        }
        public GarageDTO()
        {
        }
    }
}
