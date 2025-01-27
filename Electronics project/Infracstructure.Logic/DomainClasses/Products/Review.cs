using Electronics.Logic.DomainClasses.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Logic.DomainClasses.Products
{
    public class Review
    {
        public int Id { get; init; }
        public decimal Rating { get; init; }
        public string Comment { get; init; }
        public Customer Customer { get; init; }

        public Review (int id, string comment, Customer customer, decimal rating)
        {
            Id = id;
            Comment = comment;
            Customer = customer;
            Rating = rating;
        }
    }
}
