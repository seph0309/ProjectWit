using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWit.Model
{
    public interface IWit_Company : IReadable<Wit_Company>, IWritable<Wit_Company>, IDisposable
    {
    }
}
