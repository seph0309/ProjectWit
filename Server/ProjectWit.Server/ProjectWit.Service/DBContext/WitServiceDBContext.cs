using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectWit.Model;

namespace ProjectWit.Service
{
    public class WitServiceDBContext : WitDbContext
    {
        public WitServiceDBContext()
        {
            //Turning them off for performance purposes. And since we don't track changes over service
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
    }
}