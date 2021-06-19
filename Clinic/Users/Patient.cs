using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic {
    public class Patient : User
    { 
        private List<Prescription> _prescriptions;
    }
}