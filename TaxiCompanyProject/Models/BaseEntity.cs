using System;

namespace TaxiCompanyProject.Models
{
    public class BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int Id { get; set; }

    }
}