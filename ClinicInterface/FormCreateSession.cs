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
        FormTherapist _formTherapist;
        User _therapist;
        Prescription _prescription;
        public FormCreateSession(FormTherapist formTherapist, User therapist, Prescription prescription)
        {
            this._formTherapist = formTherapist;
            this._therapist = therapist;
            this._prescription = prescription;
            InitializeComponent();
            errorLabel.Visible = false;
        }

        private void FormCreateSession_Load(object sender, EventArgs e)
        {
            patientBox.Text = Controller.Instance.GetPatientByID(_prescription.IDPatient).Username;
            typeBox.Text = _prescription.Prescriptionable.Type;
            nameBox.Text = _prescription.Prescriptionable.Name;
            dateBox.Text = _prescription.Schedule.ToString();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string note = notesBox.Text;
            Session s = Controller.Instance.SaveSession(_prescription, note);
            if(s!=null)
            {
                errorLabel.Visible = true;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _formTherapist.MdiParent = this.MdiParent;
            this.Hide();
            _formTherapist.Show();
        }
    }
}
