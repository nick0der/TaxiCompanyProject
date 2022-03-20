using System;
using TaxiCompanyProject.Models;

namespace TaxiCompanyProject.DTO
{
    public class DriverDTO
    {
        public string fullName
        {
            get;
            set;
        }

        public int salary
        {
            get;
            set;
        }

        public int age
        {
            get;
            set;
        }

        public string email
        {
            get;
            set;
        }

        public string mobile
        {
            get;
            set;
        }

        public Taxi Taxi
        {
            get;
            set;
        }
        public DriverDTO()
        {
        }
    }
}
