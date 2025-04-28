using System;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Product.Command;

public class UpdateProductCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Rate { get; set; }
    public int Id { get; set; }

    internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IAppDbContext _context;
        public UpdateProductCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.products.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            // var product = new Domain.Entities.Product();
            if (product != null)
            {
                product.Name = request.Name;
                product.Description = request.Description;
                product.Rate = request.Rate;

                await _context.saveChangesAsync();
            }

            return default;
        }
    }
}
