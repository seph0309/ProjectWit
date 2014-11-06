using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWit.Model
{
    public class WitDbContextBase
    {
        private WitDbContext _db;
        protected WitDbContext db
        {
            get
            {
                if (_db == null)
                    _db = new WitDbContext();

                return _db;
            }
        }
    }
}
