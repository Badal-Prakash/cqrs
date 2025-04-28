using System;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Product.Command;

public class CreateProductCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Rate { get; set; }

    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IAppDbContext _context;
        public CreateProductCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Domain.Entities.Product();
            product.Name = request.Name;
            product.Description = request.Description;
            product.Rate = request.Rate;

            await _context.products.AddAsync(product);
            await _context.saveChangesAsync();
            return product.Id;
        }
    }
}
