using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWit.Service
{
    public interface IRequireParameter
    {
        List<string> RequireParameter(params object[] parameters);
    }
}