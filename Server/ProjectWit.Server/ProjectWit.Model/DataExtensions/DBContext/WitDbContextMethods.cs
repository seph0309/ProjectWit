namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Threading.Tasks;

    public partial class WitDbContext
    {
        public void SetTrackingAndProxy(bool value)
        {
            Configuration.ProxyCreationEnabled = value;
            Configuration.AutoDetectChangesEnabled = value;
        }
        public void SetLogMessage(List<string> _log)
        {
            errorLog.dbContextErrorLogMsg = _log;
        }
    }
}
