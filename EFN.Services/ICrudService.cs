using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace EFN.Services
{
    public interface ICrudService<T>
    {
        Task<List<T>> GetList();

        Task<T> GetItem(int? id);

        Task Insert(T item);

        Task Update(T item);

        Task Delete(int id);

        Task SaveDb();
    }
}
