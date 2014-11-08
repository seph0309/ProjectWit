using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWit.Model
{
    public interface IWit_Order : IReadable<Wit_Order>, IWritable<Wit_Order>, IDisposable
    {
    }
}
