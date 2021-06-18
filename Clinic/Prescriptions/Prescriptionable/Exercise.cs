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

        public string Name { get => _name; set => _name = value; }
        public string Type { get => GetType().Name; }

        public override string ToString() => Name;
    }
}
