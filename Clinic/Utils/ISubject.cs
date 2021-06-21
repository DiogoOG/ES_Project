﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Utils
{
    public interface ISubject
    {
        void addObserver(IObserver observer);
        void Notify();
    }
}
