using Clinic;
using Clinic.Repository;
using Clinic.Repository.Clinic.Repository;
using Clinic.Users;
using Clinic.Utils;
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

        


        //PRESCRIPTION FUNCTIONALITIES
        public Prescription savePrescription(string patientUsername, User therapist, string type, string name, DateTime date)
        {
            int patientId = getPatientByUsername(patientUsername).ID;
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

        public Prescription getPrescription(int idTherapist, int idPatient, string type, string name, DateTime schedule)
        {
            List<Prescription> prescriptions = new List<Prescription>();

            Therapist therapist = therapistsRepository.FindOne(idTherapist);
            List<Prescription> therapistPrescriptions = getPrescriptionsByTherapist(therapist);
            foreach(Prescription p in therapistPrescriptions)
            {
                if ((p.IdPatient == idPatient) && (p.Prescriptionable.Type == type) && (p.Prescriptionable.Name == name) && (p.Schedule == schedule))
                    return p;
            }
            return null;
        }

        public Prescription editPrescription(string newType, string newName, DateTime newDate, int idTherapist, string patient, string type, string name, DateTime schedule)
        {
            int idPatient = getPatientByUsername(patient).ID;
            Prescription prescription = getPrescription(idTherapist, idPatient, type, name, schedule);
            if (prescription != null)
            {
                Prescription newPrescription = prescriptionFactory.getPrescription(idPatient, idTherapist, newType, newName, false, newDate);
                newPrescription.ID = prescription.ID;
                return prescriptionsRepository.Edit(newPrescription);
            }
            return null;
        }

        public void changeVisibility(string therapist, int idPatient, string type, string name, DateTime schedule)
        {
            Therapist t = getTherapistByUsername(therapist);
            Prescription p = getPrescription(t.ID, idPatient, type, name, schedule);

            p.pushButton();
            prescriptionsRepository.Edit(p);
        }

        public bool getVisibility(string therapist, int idPatient, string type, string name, DateTime schedule)
        {
            Therapist t = getTherapistByUsername(therapist);
            Prescription p = getPrescription(t.ID, idPatient, type, name, schedule);

            return p.Visibility;
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

        public Patient getPatientById(int idPatient)
        {
            foreach (Patient patient in patientsRepository.FindAll())
            {
                if (patient.ID == idPatient)
                    return patient;
            }
            return null;
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
    public Therapist getTherapistById(int idTherapist)
    {
        foreach (Therapist therapist in therapistsRepository.FindAll())
        {
            if (therapist.ID == idTherapist)
            return therapist;
        }

        return null;
    }

    public Therapist getTherapistByUsername(string username)
    {
        foreach (Therapist therapist in therapistsRepository.FindAll())
        {
            if (therapist.Username == username)
            return therapist;
        }

        return null;
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
