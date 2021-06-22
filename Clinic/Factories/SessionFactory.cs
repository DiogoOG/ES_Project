using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    public class SessionFactory
    {
        public Session GetSession(int idPrescription, string note)
        {
            Session session = new Session()
            {
                IdPrescription = idPrescription,
                Note = note
            };

            return session;
        }
    }
}
