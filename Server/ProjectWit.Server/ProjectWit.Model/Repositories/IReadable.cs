using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWit.Model
{
    public interface IReadable<T>
    {
        Task<T> GetByIdAsync(Guid? id);
        Task<T> FindByIdAsync(Guid? id);
        Task<List<T>> GetAllAsync();
    }
}
