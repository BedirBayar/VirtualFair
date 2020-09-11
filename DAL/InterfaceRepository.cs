using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualFair.Data
{
    public interface InterfaceRepository
    {
        IQueryable<ApplicationIdentityDbContext> Context { get; }
    }
}
