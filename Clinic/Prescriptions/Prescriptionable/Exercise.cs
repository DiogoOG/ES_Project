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

        public Exercise(string name)
        {
            _name = name;
        }
        public string Name { get => _name; set => _name = value; }
        public string Type { get => "Exercise"; }

        public override string ToString() => Name;
    }
}
