using Clinic;
using Clinic.Repository;
using Clinic.Repository.Clinic.Repository;
using Clinic.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClinicInterface
{
    
    public class Controller 
    {
        PatientsRepository patientsRepository;
        TherapistsRepository therapistsRepository;
        PrescriptionsRepository prescriptionsRepository;
        UserFactory userFactory = new UserFactory();
        PrescriptionFactory prescriptionFactory = new PrescriptionFactory();
        public Controller(PatientsRepository patientsRepository, TherapistsRepository therapistsRepository, PrescriptionsRepository prescriptionsRepository)
        {
            this.patientsRepository = patientsRepository;
            this.therapistsRepository = therapistsRepository;
            this.prescriptionsRepository = prescriptionsRepository;
        }


        //USER FUNCTIONALITIES
        public User saveUser(string type, string username, string password)
        {
            User user = userFactory.getUser(type, username, password);
            if (type == "Patient")
            {
                user.ID = idGenerator<Patient>(patientsRepository);
                return patientsRepository.Save((Patient)user);
            }
            else
            {
                user.ID = idGenerator<Therapist>(therapistsRepository);
                return therapistsRepository.Save((Therapist)user);
            }
            
        }

        public User getUserByUsername(string username)
        {
            foreach (Patient patient in patientsRepository.FindAll())
            {
                if (patient.Username == username)
                    return patient;
            }

            foreach (Therapist therapist in therapistsRepository.FindAll())
            {
                if (therapist.Username == username)
                    return therapist;
            }

            return null;
        }

        public User getUserById(int idUser)
        {
            foreach (Patient patient in patientsRepository.FindAll())
            {
                if (patient.ID == idUser)
                    return patient;
            }

            foreach (Therapist therapist in therapistsRepository.FindAll())
            {
                if (therapist.ID == idUser)
                    return therapist;
            }

            return null;
        }







        //PRESCRIPTION FUNCTIONALITIES
        public Prescription savePrescription(string patientUsername, User therapist, string type, string name, DateTime date)
        {
            int patientId = getUserByUsername(patientUsername).ID;
            Prescription prescription = prescriptionFactory.getPrescription(patientId, therapist.ID, type, name, false, date);
            prescription.ID = idGenerator<Prescription>(prescriptionsRepository);
            return prescriptionsRepository.Save(prescription);
        }

        public List<Prescription> getPrescriptionsByTherapist(User therapist)
        {
            List<Prescription> prescriptions = new List<Prescription>();
            foreach(Prescription prescription in prescriptionsRepository.FindAll())
            {
                if (prescription.IdTherapist == therapist.ID)
                    prescriptions.Add(prescription);
            }
            return prescriptions;
        }

        public List<Prescription> getPrescriptionsByPatient(User patient)
        {
            List<Prescription> prescriptions = new List<Prescription>();
            foreach (Prescription prescription in prescriptionsRepository.FindAll())
            {
                if (prescription.IdPatient == patient.ID)
                    prescriptions.Add(prescription);
            }
            return prescriptions;
        }






        //PATIENT FUNCTIONALITIES
        public List<Patient> getAllPatients()
        {
            return patientsRepository.FindAll().ToList();
        }

        public bool isPatient(string username)
        {
            foreach (Patient patient in patientsRepository.FindAll())
            {
                if (patient.Username == username)
                    return true;
            }

            return false;
        }





        //THERAPIST FUNCTIONALITIES








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
