using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFN.Services.City
{
    public interface ICityService
        : ICrudService<Database.Entity.City>
    {
    }
}
