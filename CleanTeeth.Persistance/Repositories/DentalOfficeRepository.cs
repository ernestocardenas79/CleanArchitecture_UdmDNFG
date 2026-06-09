using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTeeth.Persistance.Repositories;

public class DentalOfficeRepository: Repository<DentalOffice>, IDentalOfficeRepository
{
    public DentalOfficeRepository(CleanTeethDbContext context):base(context)
    {
        
    }


}
