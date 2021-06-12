using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    public class Exercise : IPrescriptionable
    {
        private string _name;

        public string Name { get => _name; }
        public string Type { get => this.GetType().Name; }
    }
}
