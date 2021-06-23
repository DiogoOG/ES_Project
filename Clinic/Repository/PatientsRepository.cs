using System;
using System.Collections.Generic;

namespace Clinic

{
    public class PatientsRepository : FileRepository<int,Patient>
    {

        public PatientsRepository(String filename) : base(filename,EntityToFileMapping.CreatePatient) 
        {
            LoadFromFile();
        }

        public override IEnumerable<Patient> FindAll()
        {
            LoadFromFile();
            return base.FindAll();
        }

        public override Patient FindOne(int patientId)
        {
            LoadFromFile();
            return base.FindOne(patientId);
        }

        /*
         * input: a patient
         * returns the given patient if saved, null otherwise
         */
        public override Patient Save(Patient patient)
        {
            Patient toReturn = base.Save(patient);
            writeToFile();
            return toReturn;
        }

    }
}
