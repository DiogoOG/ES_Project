using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Clinic.Repository
    {
        public class PrescriptionsRepository : FileRepository<int, Prescription>
        {

            public PrescriptionsRepository(String filename) : base(filename, EntityToFileMapping.createPrescription)
            {
                loadFromFile();
            }

            public override IEnumerable<Prescription> FindAll()
            {
                loadFromFile();
                return base.FindAll();
            }

            public override Prescription FindOne(int prescriptionId)
            {
                loadFromFile();
                return base.FindOne(prescriptionId);
            }

            /*
             * input: a patient
             * returns the given prescription if saved, null otherwise
             */
            public override Prescription Save(Prescription prescription)
            {
                Prescription toReturn = base.Save(prescription);
                writeToFile();
                return toReturn;
            }

        }
    }

}
