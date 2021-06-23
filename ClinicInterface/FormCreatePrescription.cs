using Clinic;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ClinicInterface
{
    public partial class FormCreatePrescription : Form, ISubject
    {
        List<IObserver> observers = new List<IObserver>();


        private User _therapist;
        private FormTherapist _formTherapist;
        public FormCreatePrescription(User therapist, FormTherapist formTherapist)
        {
            this._therapist = therapist;
            this._formTherapist = formTherapist;
            InitializeComponent();
            datePicker.MaxSelectionCount = 1;
        }

        private void FormTherapist_Load(object sender, EventArgs e)
        {
            foreach(Patient patient in Controller.Instance.GetAllPatients())
            {
                patientsList.Items.Add(patient.Username);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            string patientUsername = "";
            if (patientsList.SelectedIndex!=-1)
            {
                patientUsername = patientsList.SelectedItem.ToString();
                string type = typeBox.SelectedItem.ToString();
                DateTime date = datePicker.SelectionRange.Start;
                string name = nameBox.Text;

                bool valid = true;
                string errors = "";
                if (name == "")
                {
                    errors += "Invalid name!\n";
                    valid = false;
                }
                errorLabel.Text = errors;
                nameBox.Text = "";

                if (valid)
                {
                    Prescription prescription = Controller.Instance.savePrescription(patientUsername, this._therapist, type, name, date);
                    if (prescription != null)
                    {
                        errorLabel.Text = "Prescription saved!";
                        Notify();
                    }
                }
            }
            else errorLabel.Text = "Select a patient!";
        }

        private void backButton_Click_1(object sender, EventArgs e)
        {
            _formTherapist.MdiParent = this.MdiParent;
            this.Hide();
            _formTherapist.Show();
        }

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Notify()
        {
            observers.ForEach(o => o.Update(this));
        }
    }
}
