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
        bool Create(ref T entity, string modifiedBy);
        bool Remove(Guid? id);
        bool Update(Wit_Session wit_Session, string modifiedBy);
    }
}
