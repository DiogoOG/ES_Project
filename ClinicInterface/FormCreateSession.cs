using Clinic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClinicInterface
{
    public partial class FormCreateSession : Form
    {
        FormTherapist formTherapist;
        User therapist;
        Prescription prescription;
        public FormCreateSession(FormTherapist formTherapist, User therapist, Prescription prescription)
        {
            this.formTherapist = formTherapist;
            this.therapist = therapist;
            this.prescription = prescription;
            InitializeComponent();
            errorLabel.Visible = false;
        }

        private void FormCreateSession_Load(object sender, EventArgs e)
        {
            patientBox.Text = Controller.Instance.GetPatientByID(prescription.IDPatient).Username;
            typeBox.Text = prescription.Prescriptionable.Type;
            nameBox.Text = prescription.Prescriptionable.Name;
            dateBox.Text = prescription.Schedule.ToString();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string note = notesBox.Text;
            Session s = Controller.Instance.SaveSession(prescription, note);
            if(s!=null)
            {
                errorLabel.Visible = true;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            formTherapist.MdiParent = this.MdiParent;
            this.Hide();
            formTherapist.Show();
        }
    }
}
