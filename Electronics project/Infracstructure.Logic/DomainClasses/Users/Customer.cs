using Electronics.Logic.DomainClasses.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Logic.DomainClasses.Users
{
    public class Customer : User
    {
        public string Country { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string CardInfo { get; set; } = string.Empty;
        public List<Electronic> Favorites { get; private set; }
        public List<Cart> Carts { get; set; }

        public Customer(int id, string email, string userName, string password)
            : base(id, email, userName, password)
        {
            this.Country = Country;
            this.PostalCode = PostalCode;
            this.CardInfo = CardInfo;
            Favorites = new List<Electronic>();
            Carts = new List<Cart>();
        }

        public void AddToCart(Cart cart)
        {
            Carts.Add(cart);
        }

        public void LoadFavorites(List<Electronic> favorites)
        {
            Favorites = favorites;
        }

        public bool AddToFavorite(Electronic electronic)
        {
            if (Favorites.Contains(electronic))
            {
                return false;
            }
            Favorites.Add(electronic);
            return true;
        }

        public void RemoveFromFavorites(Electronic electronic)
        {
            foreach (var favorite in Favorites)
            {
                if (electronic == favorite)
                {
                    Favorites.Remove(favorite);
                }
            }
        }
    }
}
