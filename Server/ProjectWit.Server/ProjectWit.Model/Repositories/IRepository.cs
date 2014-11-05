using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWit.Model
{
    public interface IRepository<T>
    {
        T GetById(Guid? id);
        T FindById(Guid? id);
        List<T> GetAll();
        bool Create(ref T entity);
        bool Delete(Guid? id);
        bool Update(Guid? id);
    }
}
