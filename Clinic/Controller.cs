using System;
using System.Collections.Generic;
using System.Linq;

namespace Clinic
{
    
    public class Controller // Maybe we should rename this "Clinic", since it contains all the information?
    {
        PatientsRepository _patientsRepository;
        TherapistsRepository _therapistsRepository;
        PrescriptionsRepository _prescriptionsRepository;
        SessionsRepository _sessionsRepository;
        UserFactory _userFactory = new UserFactory();
        PrescriptionFactory _prescriptionFactory = new PrescriptionFactory();
        SessionFactory _sessionFactory = new SessionFactory();
        public Controller(PatientsRepository patientsRepository, TherapistsRepository therapistsRepository, PrescriptionsRepository prescriptionsRepository, SessionsRepository sessionsRepository)
        {
            this._patientsRepository = patientsRepository;
            this._therapistsRepository = therapistsRepository;
            this._prescriptionsRepository = prescriptionsRepository;
            this._sessionsRepository = sessionsRepository;
        }


        //USER FUNCTIONALITIES
        public User SaveUser(string type, string username, string password)
        {
            User user = _userFactory.GetUser(type, username, password);
            if (type == "Patient")
            {
                user.ID = IDGenerator<Patient>(_patientsRepository);
                return _patientsRepository.Save((Patient)user);
            }
            else
            {
                user.ID = IDGenerator<Therapist>(_therapistsRepository);
                return _therapistsRepository.Save((Therapist)user);
            }
            
        }

        public Session SaveSession(Prescription prescription, string note)
        {
            Session session = _sessionFactory.GetSession(prescription.ID, note);
            session.ID = IDGenerator<Session>(_sessionsRepository);
            return _sessionsRepository.Save(session);

        }

        //PRESCRIPTION FUNCTIONALITIES
        public Prescription SavePrescription(string patientUsername, User therapist, string type, string name, DateTime date)
        {
            int patientId = GetPatientByUsername(patientUsername).ID;
            Prescription prescription = _prescriptionFactory.GetPrescription(patientId, therapist.ID, type, name, false, date);
            prescription.ID = IDGenerator<Prescription>(_prescriptionsRepository);
            return _prescriptionsRepository.Save(prescription);
        }

        //returns a list of the prescriptions of the given therapist
        public List<Prescription> GetPrescriptionsByTherapist(User therapist)
        {
            List<Prescription> prescriptions = new List<Prescription>();
            foreach(Prescription prescription in _prescriptionsRepository.FindAll())
            {
                if (prescription.IDTherapist == therapist.ID)
                    prescriptions.Add(prescription);
            }
            return prescriptions;
        }

        //returns a list of public prescriptions and the prescriptions of the given therapist
        public List<Prescription> GetAccessiblePrescriptions(User therapist)
        {
            List<Prescription> prescriptions = new List<Prescription>();
            foreach (Prescription prescription in _prescriptionsRepository.FindAll())
            {
                if ((prescription.IDTherapist == therapist.ID) || (prescription.Visibility))
                    prescriptions.Add(prescription);
            }
            return prescriptions;
        }

        //returns a list of the prescriptions of the given patient
        public List<Prescription> GetPrescriptionsByPatient(User patient)
        {
            List<Prescription> prescriptions = new List<Prescription>();
            foreach (Prescription prescription in _prescriptionsRepository.FindAll())
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

            Therapist therapist = _therapistsRepository.FindOne(idTherapist);
            List<Prescription> therapistPrescriptions = GetPrescriptionsByTherapist(therapist);
            foreach(Prescription p in therapistPrescriptions)
            {
                if ((p.IDPatient == idPatient) && (p.Prescriptionable.Type == type) && (p.Prescriptionable.Name == name) && (p.Schedule == schedule))
                    return p;
            }
            return null;
        }

        //edits in the file the a prescription with new attributes
        public Prescription EditPrescription(string newType, string newName, DateTime newDate, int idTherapist, string patient, string type, string name, DateTime schedule)
        {
            int idPatient = GetPatientByUsername(patient).ID;
            Prescription prescription = GetPrescription(idTherapist, idPatient, type, name, schedule);
            if (prescription != null)
            {
                Prescription newPrescription = _prescriptionFactory.GetPrescription(idPatient, idTherapist, newType, newName, false, newDate);
                newPrescription.ID = prescription.ID;
                return _prescriptionsRepository.Edit(newPrescription);
            }
            return null;
        }


        //edits int the file the visibility of the prescription
        public void ChangeVisibility(string therapist, int idPatient, string type, string name, DateTime schedule)
        {
            Therapist t = GetTherapistByUsername(therapist);
            Prescription p = GetPrescription(t.ID, idPatient, type, name, schedule);

            p.Visibility = !p.Visibility;
            _prescriptionsRepository.Edit(p);
        }

        public bool GetVisibility(string therapist, int idPatient, string type, string name, DateTime schedule)
        {
            Therapist t = GetTherapistByUsername(therapist);
            Prescription p = GetPrescription(t.ID, idPatient, type, name, schedule);

            return p.Visibility;
        }


        //PATIENT FUNCTIONALITIES
        public List<Patient> GetAllPatients()
        {
            return _patientsRepository.FindAll().ToList();
        }

        public bool IsPatient(string username)
        {
            foreach (Patient patient in _patientsRepository.FindAll())
            {
                if (patient.Username == username)
                    return true;
            }

            return false;
        }


        public Patient GetPatientByID(int idPatient)
        {
            foreach (Patient patient in _patientsRepository.FindAll())
            {
                if (patient.ID == idPatient)
                    return patient;
            }
            return null;
        }

        public Patient GetPatientByUsername(string username)
        {
            foreach (Patient patient in _patientsRepository.FindAll())
            {
                if (patient.Username == username)
                    return patient;
            }
            return null;
        }


    //THERAPIST FUNCTIONALITIES
    public Therapist GetTherapistByID(int idTherapist)
    {
        foreach (Therapist therapist in _therapistsRepository.FindAll())
        {
            if (therapist.ID == idTherapist)
            return therapist;
        }

        return null;
    }

    public Therapist GetTherapistByUsername(string username)
    {
        foreach (Therapist therapist in _therapistsRepository.FindAll())
        {
            if (therapist.Username == username)
            return therapist;
        }

        return null;
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
