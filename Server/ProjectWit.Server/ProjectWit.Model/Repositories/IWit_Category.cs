using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWit.Model
{
    public interface IWit_Category : IReadable<Wit_Category>, IWritable<Wit_Category>, IDisposable
    {
        string hello();
    }
}
