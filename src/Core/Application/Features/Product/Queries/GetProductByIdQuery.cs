using System;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Product.Queries;

public class GetProductByIdQuery : IRequest<Domain.Entities.Product>
{
    public int Id { get; set; }
    internal class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Domain.Entities.Product>
    {

        private readonly IAppDbContext _context;
        public GetProductByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<Domain.Entities.Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.products.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            return res;
        }
    }
}
