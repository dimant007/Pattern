using EFN.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFN.Services.City
{
    public class CityService 
        : CrudServiceBase<CityService, Database.Entity.City>, 
        ICityService
    {
        public CityService(DatabaseContext db)
            : base(db, "City", x => x.Cities)
        { }
    }
}
