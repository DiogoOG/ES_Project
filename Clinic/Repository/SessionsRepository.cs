using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Repository
{
    public class SessionsRepository : FileRepository<int, Session>
    {

        public SessionsRepository(String filename) : base(filename, EntityToFileMapping.createSession)
        {
            loadFromFile();
        }

        public override IEnumerable<Session> FindAll()
        {
            loadFromFile();
            return base.FindAll();
        }

        public override Session FindOne(int sessionId)
        {
            loadFromFile();
            return base.FindOne(sessionId);
        }

        /*
         * input: a patient
         * returns the given therapist if saved, null otherwise
         */
        public override Session Save(Session session)
        {
            Session toReturn = base.Save(session);
            writeToFile();
            return toReturn;
        }

    }
}
