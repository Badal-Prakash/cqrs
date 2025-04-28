using System;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Product.Command;

public class DeleteProductCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Rate { get; set; }
    public int Id { get; set; }

    internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IAppDbContext _context;
        public DeleteProductCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.products.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (product != null)
            {
                _context.products.Remove(product);
                await _context.saveChangesAsync();
            }
            return default;
        }
    }
}
