using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Clinic
{
    public class PrescriptionsRepository : FileRepository<int, Prescription>
    {

        public PrescriptionsRepository(String filename) : base(filename, EntityToFileMapping.CreatePrescription)
        {
            LoadFromFile();
        }

        public override IEnumerable<Prescription> FindAll()
        {
            LoadFromFile();
            return base.FindAll();
        }

        public override Prescription FindOne(int prescriptionId)
        {
            LoadFromFile();
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

        public override Prescription Edit(Prescription newPrescription)
        {
            Prescription toReturn = base.Edit(newPrescription);
            writeToFile();
            return toReturn;
        }

    }
}
