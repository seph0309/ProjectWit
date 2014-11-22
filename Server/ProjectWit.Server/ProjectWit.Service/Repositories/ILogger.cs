using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWit.Service
{
    public interface ILogger
    {
        void LogMsg(string message);
        void SaveLogToText(string message);
        void SaveLogToEvent(string message);
    }
}
