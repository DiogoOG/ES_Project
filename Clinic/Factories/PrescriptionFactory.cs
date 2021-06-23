using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    public class PrescriptionFactory
    {
        public Prescription GetPrescription(int idPatient, int idTherapist, string type, string name, bool visibility, DateTime schedule)
        {
            Prescription prescription = new Prescription() // this is such a fancy way to call a constructor, i can't
            {
                IDPatient = idPatient,
                IDTherapist = idTherapist,
                Schedule = schedule,
                Visibility = visibility
            };

            if (type == "Medication")
                prescription.Prescriptionable = new Medication(name);
            else if (type == "Exercise")
                prescription.Prescriptionable = new Exercise(name);
            else prescription.Prescriptionable = new Treatment(name);

            return prescription;
        }
        
    }
}
