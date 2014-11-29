using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWit.Model
{
    public interface ILogger
    {
        List<string> LogMessage { get; set; }

        void LogMsg(string message);
        void SaveLogToText(string message);
        void SaveLogToEvent(string message);
    }
}
