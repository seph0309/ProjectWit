using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWit.Model
{
    public interface IRepository<T>
    {
        Task <T> GetByIdAsync(Guid? id);
        Task<T> FindByIdAsync(Guid? id);
        Task<List<T>> GetAllAsync();
        Task<T> CreateAsync(T entity, string modifiedBy);
        Task RemoveAsync(Guid? id);
        Task UpdateAsync(Wit_Session wit_Session, string modifiedBy);
    }
}
