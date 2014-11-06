﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWit.Model
{
    public interface IWit_Session : IReadable<Wit_Session>, IWritable<Wit_Session>, IDisposable
    {
        List<Wit_Session> GetSession(string userUID);
    }
}
