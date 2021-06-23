using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    public class UserFactory
    {
        public User GetUser(string type, string username, string password)
        {
            User user;

            if (type == "Patient")
            {
                user = new Patient()
                {
                    Username = username,
                    Password = password
                };
            }
            else
            {
                user = new Therapist()
                {
                    Username = username,
                    Password = password
                };
            }

            return user;
        }
    }
}
