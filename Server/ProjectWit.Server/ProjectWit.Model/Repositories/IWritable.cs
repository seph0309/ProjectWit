using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace ProjectWit.Model
{
    public interface IWritable<T>
    { 
        Task<T> CreateAsync(T entity, string modifiedBy);
        Task RemoveAsync(Guid? id);
        Task UpdateAsync(T entity, string modifiedBy);
        void SetDbContext(DbContext db, List<string> _logs);
    }
}
