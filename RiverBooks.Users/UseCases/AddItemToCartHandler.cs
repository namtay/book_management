﻿using Ardalis.Result;
using MediatR;

namespace RiverBooks.Users.UseCases
{
    public class AddItemToCartHandler : IRequestHandler<AddItemToCartCommand, Result>
    {
        private readonly IApplicationUserRepository _userRepository;
        public AddItemToCartHandler(IApplicationUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result> Handle(AddItemToCartCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserWithCartByEmailAsync(request.emailAddress);

            if (user == null)
            {
                return Result.Unauthorized();
            }
            //TODO: Get description and price from Books Module
            var newCartItem = new CartItem(request.BookId,
                "description",
                request.Quantity,
                1.00m);
            user.AddItemToCart(newCartItem);
            await _userRepository.SaveChangesAsync();
            return Result.Success();
        }
    }
}
