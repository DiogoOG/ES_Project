using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    /// <summary> Represents anyone that can login into the app. </summary>
    public abstract class User : Entity<int>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public override string ToString() => Username + "," + Password;
    }
}