using System;
using System.Collections.Generic;

namespace Clinic.Repository

{
    public class PatientsRepository : FileRepository<int,Patient>
    {

        public PatientsRepository(String filename) : base(filename,EntityToFileMapping.createPatient) 
        {
            loadFromFile();
        }

        public override IEnumerable<Patient> FindAll()
        {
            loadFromFile();
            return base.FindAll();
        }

        public override Patient FindOne(int patientId)
        {
            loadFromFile();
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
