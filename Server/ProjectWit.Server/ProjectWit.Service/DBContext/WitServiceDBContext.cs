using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectWit.Model;

namespace ProjectWit.Service
{
    public class WitServiceDBContext : WITEntities
    {
        public WitServiceDBContext() :base()
        {
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
    }
}