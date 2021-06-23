using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    public class PrescriptionFactory
    {
        public Prescription GetPrescription(int idPatient, int idTherapist, string type, string name, bool visibility, DateTime schedule, string[] permissions)
        {
            Prescription prescription = new Prescription()
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

            prescription.Visibility = visibility;

            if(permissions!=null)
            {
                for (int i = 0; i < permissions.Length-1; i++)
                {
                    prescription.AddPermission(int.Parse(permissions[i]));
                    
                }
            }

            return prescription;
        }
        
    }
}
