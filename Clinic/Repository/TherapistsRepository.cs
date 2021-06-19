using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Repository
{
    public class TherapistsRepository : FileRepository<int, Therapist>
    {

        public TherapistsRepository(String filename) : base(filename, EntityToFileMapping.createTherapist)
        {
            loadFromFile();
        }

        public override IEnumerable<Therapist> FindAll()
        {
            loadFromFile();
            return base.FindAll();
        }

        public override Therapist FindOne(int therapistId)
        {
            loadFromFile();
            return base.FindOne(therapistId);
        }

        /*
         * input: a patient
         * returns the given therapist if saved, null otherwise
         */
        public override Therapist Save(Therapist therapist)
        {
            Therapist toReturn = base.Save(therapist);
            writeToFile();
            return toReturn;
        }

    }
}
