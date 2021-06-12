using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    public class SingletonClinic
    {
        private SingletonClinic _instance = new SingletonClinic();
        public SingletonClinic Clinic => _instance;
    }
}
