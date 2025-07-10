namespace RiverBooks.Users.CartEndpoints
{
    //to add an item to cart, all user information can be obtained from the token. We will need to pass details of the book like the BookId and the quantity of books. This information can be found in the request"AddCartItemRequest"
    public record AddCartItemRequest(Guid BookId, int Quantity);
}
