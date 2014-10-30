﻿using System;
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
            //Turning them off for performance purposes. And since we don't track changes over service
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
    }
}