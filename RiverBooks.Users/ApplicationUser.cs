using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;

namespace RiverBooks.Users
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;

        private readonly List<CartItem> _cartItems = new();


        public IReadOnlyCollection<CartItem> CartItems => _cartItems.AsReadOnly();

        public void AddItemToCart(CartItem item)
        {
            Guard.Against.Null(item);

            var existingBook = CartItems.SingleOrDefault(c => c.BookId == item.BookId);

            if (existingBook != null)
            {   //if there is an existing quantity, then update that quantity by one.
                existingBook.UpdateQuantity(existingBook.Quantity + item.Quantity);

                // TODO : What do we do if other details of the item have been updated?
                return;
            }
            _cartItems.Add(item);
        }
    }


    public class CartItem
    {

        public CartItem(Guid bookId, string description, int quantity, decimal unitPrice)
        {
            BookId = Guard.Against.Default(bookId);
            Description = Guard.Against.Default(description);
            Quantity = Guard.Against.Negative(quantity);
            UnitPrice = Guard.Against.Negative(unitPrice);
        }

        public CartItem() 
        { 
            //EF

        }
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid BookId { get; set; }

        public string Description { get; set; } = string.Empty;

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        internal void UpdateQuantity(int quantity)
        {
            Quantity = Guard.Against.Negative(quantity);
        }

    }

}

