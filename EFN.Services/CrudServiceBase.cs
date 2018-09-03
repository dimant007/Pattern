using EFN.Database.Entity;
using EFN.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using System.Data.Entity;
using System.Data.Entity.Core;
using X.PagedList;
using System.Data.Entity.Infrastructure;

namespace EFN.Services
{
    public class CrudServiceBase<TService, TDatabaseEntity>
        : ICrudService<TDatabaseEntity>
        where TDatabaseEntity : BaseEntity
    {
        protected static readonly ILog Log = LogManager.GetLogger<TService>();
        protected readonly DatabaseContext Db;
        protected readonly string NameForDto;
        protected readonly Func<DatabaseContext, DbSet<TDatabaseEntity>> DatabaseTableFunc;

        protected CrudServiceBase(DatabaseContext db, string nameForDto, Func<DatabaseContext, DbSet<TDatabaseEntity>> databaseTableFunc)
        {
            Db = db;
            NameForDto = nameForDto;
            DatabaseTableFunc = databaseTableFunc;
        }

        public virtual async Task<List<TDatabaseEntity>> GetList()
        {
            try
            {
                return await DatabaseTableFunc(Db).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<TDatabaseEntity> GetItem(int? id)
        {
            return await GetDatabaseItem(id);
        }

        public virtual async Task Insert(TDatabaseEntity item)
        {
            DatabaseTableFunc(Db).Add(item);
            await Db.SaveChangesAsync();
        }

        public virtual async Task Update(TDatabaseEntity item)
        {
            try
            {
                Db.Entry(item).State = EntityState.Modified;
                await Db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public virtual async Task Delete(int id)
        {
            var dbItem = await GetDatabaseItem(id);
            DatabaseTableFunc(Db).Remove(dbItem);
            await Db.SaveChangesAsync();
        }

        public virtual async Task SaveDb()
        {
            await Db.SaveChangesAsync();
        }

        protected async Task<TDatabaseEntity> GetDatabaseItem(int? id)
        {
            var dbItem = await DatabaseTableFunc(Db).FirstOrDefaultAsync(x => x.ID == id);
            if (dbItem == null)
            {
                throw new ObjectNotFoundException($"Unable to find {NameForDto} with ID: " + id);
            }
            return dbItem;
        }
    }
}
