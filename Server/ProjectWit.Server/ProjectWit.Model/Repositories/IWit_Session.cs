﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWit.Model
{
    public interface IWit_Session : IRepository<Wit_Session>
    {
        string helloWorld(string msg);
        List<Wit_Session> GetSession(string userUID);

    }
}
