using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic
{
    public class EntityToFileMapping
    {
        public static Session createSession(string sessionData)
        {
            string[] fields = sessionData.Split(',');
            Session session = new Session()
            {
                ID = int.Parse(fields[0]),
                IdPrescription = int.Parse(fields[1]),
                Note = fields[2]
            };

            return session;
        }

        public static Therapist createTherapist(string therapistData)
        {
            string[] fields = therapistData.Split(',');
            Therapist therapist = new Therapist()
            {
                ID = int.Parse(fields[0]),
                Username = fields[1],
                Password = fields[2]
            };

            return therapist;
        }

        public static Prescription createPrescription(string prescriptionData)
        {
            PrescriptionFactory prescriptionFactory = new PrescriptionFactory();
            string[] fields = prescriptionData.Split(',');

            int idPrescription = int.Parse(fields[0]);
            int idPatient = int.Parse(fields[1]);
            int idTherapist = int.Parse(fields[2]);
            string type = fields[3];
            string name = fields[4];
            bool visibility = bool.Parse(fields[5]);
            DateTime schedule = DateTime.Parse(fields[6]);

            Prescription prescription = prescriptionFactory.getPrescription(idPatient, idTherapist, type, name, visibility, schedule);
            prescription.ID = idPrescription;

            return prescription;
        }

        public static Patient createPatient(string patientData)
        {
            string[] fields = patientData.Split(',');
            Patient patient = new Patient()
            {
                ID = int.Parse(fields[0]),
                Username = fields[1],
                Password = fields[2]
            };

            return patient;}
    }
}
