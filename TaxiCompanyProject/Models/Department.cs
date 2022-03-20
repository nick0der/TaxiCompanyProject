using System;

namespace TaxiCompanyProject.Models
{
    public class Department : BaseEntity
    {

        public string address
        {
            get;
            set;
        }

        public Chief Chief
        {
            get;
            set;
        }

        public Department()
        {
        }
    }
}
