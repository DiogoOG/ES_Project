using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    public class Treatment : IPrescriptionable, IAnotable
    {
        private string _name;
        private string _note;

        public string Name { get => _name; }
        public string Type { get => this.GetType().Name; }

        public string Note { get => _note; set => _note = value; }
    }
}
