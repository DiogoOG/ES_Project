using Clinic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicInterface
{
    public partial class FormCreatePrescription : Form
    {
        private Controller controller;
        private User therapist;
        private FormTherapist formTherapist;
        public FormCreatePrescription(Controller controller,User therapist, FormTherapist formTherapist)
        {
            this.controller = controller;
            this.therapist = therapist;
            this.formTherapist = formTherapist;
            InitializeComponent();
        }

        private void FormTherapist_Load(object sender, EventArgs e)
        {
            foreach(Patient patient in controller.getAllPatients())
            {
                patientsList.Items.Add(patient.Username);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            errorLabel.Text = "";

            string patientUsername = patientsList.SelectedItem.ToString();
            string type = typeBox.SelectedItem.ToString();
            DateTime date = datePicker.Value;
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
                Prescription prescription = controller.savePrescription(patientUsername, this.therapist, type, name, date);
                if(prescription != null)
                {
                    errorLabel.Text = "Prescription saved!";
                }
            }

        }

        private void backButton_Click_1(object sender, EventArgs e)
        {
            formTherapist.MdiParent = this.MdiParent;
            this.Hide();
            formTherapist.Show();
        }
    }
}
