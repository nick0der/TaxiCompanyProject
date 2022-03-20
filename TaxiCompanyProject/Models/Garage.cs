using System;

namespace TaxiCompanyProject.Models
{
    public class Garage : BaseEntity
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
        public Garage()
        {
        }
    }
}
