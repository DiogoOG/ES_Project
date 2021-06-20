using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    public class Medication : IPrescriptionable
    {
        private string _name;

        public Medication(string name)
        {
            _name = name;
        }

        public string Name { get => _name; set => _name = value; }
        public string Type { get => "Medication"; }

        public override string ToString() => Name;
    }
}
