using System;
using System.Collections.Generic;
using System.Linq;

namespace Clinic
{

    public class Controller
    {
        private static Controller _instance;
        public static Controller Instance { get => _instance; set => _instance = value; }

        PatientsRepository patientsRepository;
        TherapistsRepository therapistsRepository;
        PrescriptionsRepository prescriptionsRepository;
        SessionsRepository sessionsRepository;
        UserFactory userFactory = new UserFactory();
        PrescriptionFactory prescriptionFactory = new PrescriptionFactory();
        SessionFactory sessionFactory = new SessionFactory();
        public Controller(PatientsRepository patientsRepository, TherapistsRepository therapistsRepository, PrescriptionsRepository prescriptionsRepository, SessionsRepository sessionsRepository)
        {
            this.patientsRepository = patientsRepository;
            this.therapistsRepository = therapistsRepository;
            this.prescriptionsRepository = prescriptionsRepository;
            this.sessionsRepository = sessionsRepository;
        }


        //USER FUNCTIONALITIES
        public User saveUser(string type, string username, string password)
        {
            User user = userFactory.GetUser(type, username, password);
            if (type == "Patient")
            {
                user.ID = IDGenerator<Patient>(patientsRepository);
                return patientsRepository.Save((Patient)user);
            }
            else
            {
                user.ID = IDGenerator<Therapist>(therapistsRepository);
                return therapistsRepository.Save((Therapist)user);
            }
            
        }





        //PRESCRIPTION FUNCTIONALITIES
        public Prescription savePrescription(string patientUsername, User therapist, string type, string name, DateTime date)
        {
            int patientId = GetPatientByUsername(patientUsername).ID;
            Prescription prescription = prescriptionFactory.GetPrescription(patientId, therapist.ID, type, name, false, date,null);
            prescription.ID = IDGenerator<Prescription>(prescriptionsRepository);
            return prescriptionsRepository.Save(prescription);
        }

        //returns a list of the prescriptions of the given therapist
        public List<Prescription> getPrescriptionsByTherapist(User therapist)
        {
            List<Prescription> prescriptions = new List<Prescription>();
            foreach(Prescription prescription in prescriptionsRepository.FindAll())
            {
                if (prescription.IDTherapist == therapist.ID)
                    prescriptions.Add(prescription);
            }
            return prescriptions;
        }

        //returns a list of public prescriptions and the prescriptions of the given therapist
        public List<Prescription> getAccessiblePrescriptions(User therapist)
        {
            List<Prescription> prescriptions = new List<Prescription>();
            foreach (Prescription prescription in prescriptionsRepository.FindAll())
            {
                if (prescription.HasPermission(therapist.ID) || (prescription.Visibility))
                    prescriptions.Add(prescription);
            }
            return prescriptions;
        }

        //returns a list of the prescriptions of the given patient
        public List<Prescription> getPrescriptionsByPatient(User patient)
        {
            List<Prescription> prescriptions = new List<Prescription>();
            foreach (Prescription prescription in prescriptionsRepository.FindAll())
            {
                if (prescription.IDPatient == patient.ID)
                    prescriptions.Add(prescription);
            }
            return prescriptions;
        }

        //returns the prescription that has the given attributes
        public Prescription GetPrescription(int idTherapist, int idPatient, string type, string name, DateTime schedule)
        {
            List<Prescription> prescriptions = new List<Prescription>();

            Therapist therapist = therapistsRepository.FindOne(idTherapist);
            List<Prescription> therapistPrescriptions = getPrescriptionsByTherapist(therapist);
            foreach(Prescription p in therapistPrescriptions)
            {
                if ((p.IDPatient == idPatient) && (p.Prescriptionable.Type == type) && (p.Prescriptionable.Name == name) && (p.Schedule == schedule))
                    return p;
            }
            return null;
        }

        //edits in the file the a prescription with new attributes
        public Prescription editPrescription(string newType, string newName, DateTime newDate, int idTherapist, string patient, string type, string name, DateTime schedule)
        {
            int idPatient = GetPatientByUsername(patient).ID;
            Prescription prescription = GetPrescription(idTherapist, idPatient, type, name, schedule);
            int[] permissionsIds = prescription.Permissions.ToArray();
            string[] permissions = permissionsIds.Select(x => x.ToString()).ToArray();
            if (prescription != null)
            {
                Prescription newPrescription = prescriptionFactory.GetPrescription(idPatient, idTherapist, newType, newName, false, newDate, permissions);
                newPrescription.ID = prescription.ID;
                return prescriptionsRepository.Edit(newPrescription);
            }
            return null;
        }

        public void addPermission(int prescriptionId, int newId)
        {
            Prescription p = prescriptionsRepository.FindOne(prescriptionId);
            p.AddPermission(newId);

            prescriptionsRepository.Edit(p);
        }

        public void removePermission(int prescriptionId, int oldId)
        {
            Prescription p = prescriptionsRepository.FindOne(prescriptionId);
            p.RevokePermission(oldId);

            prescriptionsRepository.Edit(p);
        }


        //edits int the file the visibility of the prescription
        public void ChangeVisibility(string therapist, int idPatient, string type, string name, DateTime schedule)
        {
            Therapist t = GetTherapistByUsername(therapist);
            Prescription p = GetPrescription(t.ID, idPatient, type, name, schedule);

            p.Visibility = !p.Visibility;
            prescriptionsRepository.Edit(p);
        }

        public bool GetVisibility(string therapist, int idPatient, string type, string name, DateTime schedule)
        {
            Therapist t = GetTherapistByUsername(therapist);
            Prescription p = GetPrescription(t.ID, idPatient, type, name, schedule);

            return p.Visibility;
        }

        public Prescription GetPrescriptionByID(int idPrescription)
        {
            return prescriptionsRepository.FindOne(idPrescription);
        }


        //PATIENT FUNCTIONALITIES
        public List<Patient> GetAllPatients()
        {
            return patientsRepository.FindAll().ToList();
        }

        public bool IsPatient(string username)
        {
            foreach (Patient patient in patientsRepository.FindAll())
            {
                if (patient.Username == username)
                    return true;
            }

            return false;
        }


        public Patient GetPatientByID(int idPatient)
        {
            foreach (Patient patient in patientsRepository.FindAll())
            {
                if (patient.ID == idPatient)
                    return patient;
            }
            return null;
        }

        public Patient GetPatientByUsername(string username)
        {
            foreach (Patient patient in patientsRepository.FindAll())
            {
                if (patient.Username == username)
                    return patient;
            }
            return null;
        }


        //THERAPIST FUNCTIONALITIES
        public Therapist GetTherapistById(int idTherapist)
        {
            foreach (Therapist therapist in therapistsRepository.FindAll())
            {
                if (therapist.ID == idTherapist)
                return therapist;
            }

            return null;
        }

        public Therapist GetTherapistByUsername(string username)
        {
            foreach (Therapist therapist in therapistsRepository.FindAll())
            {
                if (therapist.Username == username)
                return therapist;
            }

            return null;
        }

        public List<Therapist> GetAllTherapists()
        {
             return therapistsRepository.FindAll().ToList();
        }



        //SESSION FUNCTIONALITIES

        public Session SaveSession(Prescription prescription, string note)
        {
            Session session = sessionFactory.GetSession(prescription.ID, note);
            session.ID = IDGenerator<Session>(sessionsRepository);
            return sessionsRepository.Save(session);

        }


        public List<Session> GetSessionsByTherapist(int idTherapist)
        {
            List<Session> sessions = new List<Session>();
            foreach(Session s in sessionsRepository.FindAll().ToList())
            {
                Prescription p = prescriptionsRepository.FindOne(s.IDPrescription);
                if (p.IDTherapist == idTherapist)
                    sessions.Add(s);
            }

            return sessions;

        }



        //OTHER FUNCTIONALITITES
        private int IDGenerator<E>(IRepository<int, E> repository) where E : Entity<int>
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
