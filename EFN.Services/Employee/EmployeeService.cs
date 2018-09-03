using EFN.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFN.Services.Employee
{
    public class EmployeeService
        : CrudServiceBase<EmployeeService, Database.Entity.Employee>, 
        IEmployeeService
    {
        public EmployeeService(DatabaseContext db)
            : base(db, "Employee", x => x.Employees)
        { }
    }
}
