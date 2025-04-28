using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IAppDbContext
{
    DbSet<Product> products { get; set; }
    Task<int> saveChangesAsync();
}
