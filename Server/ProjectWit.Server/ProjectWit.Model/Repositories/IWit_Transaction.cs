﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWit.Model
{
    public interface IWit_Transaction : IReadable<Wit_Transaction>, IWritable<Wit_Transaction>, IDisposable
    {
    }
}
