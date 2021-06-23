using Clinic;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ClinicInterface
{
    public partial class FormCreatePrescription : Form, ISubject
    {
        List<IObserver> observers = new List<IObserver>();

        private Controller controller;
        private User therapist;
        private FormTherapist formTherapist;
        public FormCreatePrescription(Controller controller,User therapist, FormTherapist formTherapist)
        {
            this.controller = controller;
            this.therapist = therapist;
            this.formTherapist = formTherapist;
            InitializeComponent();
            datePicker.MaxSelectionCount = 1;
        }

        private void FormTherapist_Load(object sender, EventArgs e)
        {
            foreach(Patient patient in controller.GetAllPatients())
            {
                patientsList.Items.Add(patient.Username);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            errorLabel.Text = "";

            string patientUsername = patientsList.SelectedItem.ToString();
            string type = typeBox.SelectedItem.ToString();
            DateTime date = datePicker.SelectionRange.Start;
            string name = nameBox.Text;

            bool valid = true;
            string errors = "";
            if(name=="")
            {
                errors += "Invalid name!\n";
                valid = false;
            }
            if(patientUsername=="")
            {
                errors += "Pick a patient!";
                valid = false;
            }
            errorLabel.Text = errors;
            nameBox.Text = "";

            if(valid)
            {
                Prescription prescription = controller.SavePrescription(patientUsername, this.therapist, type, name, date);
                if(prescription != null)
                {
                    errorLabel.Text = "Prescription saved!";
                    Notify();
                }
            }

        }

        private void backButton_Click_1(object sender, EventArgs e)
        {
            formTherapist.MdiParent = this.MdiParent;
            this.Hide();
            formTherapist.Show();
        }

        public void addObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Notify()
        {
            observers.ForEach(o => o.Update(this));
        }
    }
}
