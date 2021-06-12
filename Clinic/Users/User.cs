using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    public abstract class User
    {
        private string _name;
        private string _password;
        public string Name { get => _name; }

        public override string ToString() => Name;
    }
}