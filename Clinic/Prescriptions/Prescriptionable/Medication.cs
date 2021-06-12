using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAssets;

namespace Clinic
{
    public class Medication : IPrescriptionable
    {
        private string _name;

        public string Name { get => _name; }
        public string Type { get => this.GetType().Name; }

        public override string ToString() => Name;
    }
}
