using System;
using MediatR;
using Domain.Entities;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Product.Queries;

public class GetAllProductQuery : IRequest<IEnumerable<Domain.Entities.Product>>
{
    internal class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Domain.Entities.Product>>
    {

        private readonly IAppDbContext _context;
        public GetAllProductQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Domain.Entities.Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.products.ToListAsync(cancellationToken);
            return res;
        }
    }
}
