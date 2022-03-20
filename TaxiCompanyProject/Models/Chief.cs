using System;

namespace TaxiCompanyProject.Models
{
    public class Chief : BaseEntity
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

        public Chief()
        {
        }
    }
}
