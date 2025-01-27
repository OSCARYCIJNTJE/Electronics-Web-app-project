using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Domain.Users
{
    public class Customer : User
    {
        private Country country {  get; set; }
        private string postalCode { get; set; }
        private string cardInfo { get; set; }

        public Customer() { }

        public Customer (int id, string firstName, string lastName, string email, string userName, string password, Country country, string postalCode, string cardInfo)
            : base(id, firstName, lastName, email, userName, password)
        {
            this.country = country;
            this.postalCode = postalCode;
            this.cardInfo = cardInfo;
        }

        public Customer(string firstName, string lastName, string email, string userName, string password, Country country, string postalCode, string cardInfo)
            : base(firstName, lastName, email, userName, password)
        {
            this.country = country;
            this.postalCode = postalCode;
            this.cardInfo = cardInfo;
        }
    }
}
