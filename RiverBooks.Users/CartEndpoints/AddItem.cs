﻿using Ardalis.Result;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using RiverBooks.Users.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RiverBooks.Users.CartEndpoints
{

    internal class AddItem : Endpoint<AddCartItemRequest>
    {
        private readonly IMediator _mediator;

        public AddItem(IMediator mediator) {
            _mediator = mediator;
        }
        public override void Configure()
        {
            Post("/cart");
            Claims("EmailAddress");
        }

        public override async Task HandleAsync(AddCartItemRequest request, CancellationToken cancellationToken)
        {
            var emailAddress = User.FindFirstValue("EmailAddress");

            var command = new AddItemToCartCommand(request.BookId, request.Quantity, emailAddress);

            var result = await _mediator!.Send(command, cancellationToken);

            if (result.Status == ResultStatus.Unauthorized)
            {
                await SendUnauthorizedAsync();
            }
            else
            {
                await SendOkAsync();
            }
        }
    }
}
