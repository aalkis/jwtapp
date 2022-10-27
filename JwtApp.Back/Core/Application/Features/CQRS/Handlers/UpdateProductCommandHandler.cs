﻿using JwtApp.Back.Core.Application.Features.CQRS.Commands;
using JwtApp.Back.Core.Application.Interfaces;
using JwtApp.Back.Core.Domain;
using MediatR;

namespace JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;

        public UpdateProductCommandHandler(IRepository<Product> context)
        {
            _repository = context;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedProduct = await _repository.GetByIdAsync(request.Id);
            if (updatedProduct != null)
            {
            updatedProduct.Name = request.Name; 
            updatedProduct.Price = request.Price;
            updatedProduct.Stock = request.Stock;
            updatedProduct.CategoryId = request.CategoryId;
            await _repository.UpdateAsync(updatedProduct);
            }
            return Unit.Value;

        }
    }
}
