using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    public interface ISubject
    {
        void AddObserver(IObserver observer);
        void Notify();
    }
}
