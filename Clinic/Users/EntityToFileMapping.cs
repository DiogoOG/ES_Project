using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic
{
    public class EntityToFileMapping
    {
        public static Therapist createTherapist(string userData)
        {
            return null;
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
