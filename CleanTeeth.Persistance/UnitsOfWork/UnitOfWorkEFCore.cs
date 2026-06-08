using CleanTeeth.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTeeth.Persistance.UnitsOfWork;

public class UnitOfWorkEFCore : IUnitOfWork
{
    private readonly CleanTeethDbContext context;

    public UnitOfWorkEFCore(CleanTeethDbContext context)
    {
        this.context = context;
    }

    public async Task Commit()
    {
        await context.SaveChangesAsync();
    }

    public Task Rollback()
    {
        return Task.CompletedTask;
    }
}
