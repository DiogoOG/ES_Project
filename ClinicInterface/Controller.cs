using Clinic;
using Clinic.Repository;
using Clinic.Users;
using System;

namespace ClinicInterface
{
    
    public class Controller 
    {
        PatientsRepository patientsRepository;
        TherapistsRepository therapistsRepository;

        public Controller(PatientsRepository patientsRepository, TherapistsRepository therapistsRepository)
        {
            this.patientsRepository = patientsRepository;
            this.therapistsRepository = therapistsRepository;
        }

        //PATIENT FUNCTIONALITIES
        public Patient savePatient(string username, string password)
        {
            Patient patientToSave = new Patient()
            {
                ID = idGenerator<Patient>(patientsRepository),
                Username = username,
                Password = password
            };

            return patientsRepository.Save(patientToSave);
        }

        public Patient getPatientByUsername(string username)
        {
            foreach (Patient patient in patientsRepository.FindAll())
            {
                if (patient.Username == username)
                    return patient;
            }

            return null;
        }

        

        //THERAPIST FUNCTIONALITIES
        public Therapist saveTherapist(string username, string password)
        {
            Therapist therapistToSave = new Therapist()
            {
                ID = idGenerator<Therapist>(therapistsRepository),
                Username = username,
                Password = password
            };

            return therapistsRepository.Save(therapistToSave);
        }


        //OTHER FUNCTIONALITITES
        private int idGenerator<E>(IRepository<int, E> repository) where E : Entity<int>
        {
            bool ok = true;
            for (int i = 1; ok; i++)
            {
                bool taken = false;
                foreach (var entity in repository.FindAll())
                {
                    if (entity.ID == i)
                    {
                        taken = true;
                        break;
                    }
                }
                if (taken == false)
                    return i;
            }
            return 0;
        }
    }
}
