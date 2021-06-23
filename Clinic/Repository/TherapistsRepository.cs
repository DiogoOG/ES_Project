using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    public class TherapistsRepository : FileRepository<int, Therapist>
    {

        public TherapistsRepository(String filename) : base(filename, EntityToFileMapping.CreateTherapist)
        {
            LoadFromFile();
        }

        public override IEnumerable<Therapist> FindAll()
        {
            LoadFromFile();
            return base.FindAll();
        }

        public override Therapist FindOne(int therapistId)
        {
            LoadFromFile();
            return base.FindOne(therapistId);
        }

        /*
         * input: a patient
         * returns the given therapist if saved, null otherwise
         */
        public override Therapist Save(Therapist therapist)
        {
            Therapist toReturn = base.Save(therapist);
            WriteToFile();
            return toReturn;
        }

    }
}
