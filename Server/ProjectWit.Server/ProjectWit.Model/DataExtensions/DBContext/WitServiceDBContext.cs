using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWit.Model
{
    /// <summary>
    /// DBContext used for ProjectWit Web Service
    /// </summary>
    public class WitServiceDBContext : WitDbContext
    {
        public WitServiceDBContext()
        {
            //Turning them off for performance purposes. And since we don't track changes over service
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.ModifiedBy = "Wit_Service";
        }

        public WitServiceDBContext(string modifiedBy) : this()
        {
            this.ModifiedBy = modifiedBy;
        }
    }
}