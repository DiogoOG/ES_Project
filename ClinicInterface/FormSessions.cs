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
    public partial class FormSessions : Form
    {
        FormTherapist _formTherapist;
        User _therapist;
        public FormSessions(FormTherapist formTherapist, User therapist)
        { 
            this._formTherapist = formTherapist;
            this._therapist = therapist;
            InitializeComponent();
        }

        private void FormSessions_Load(object sender, EventArgs e)
        {
            foreach(Session s in Controller.Instance.GetSessionsByTherapist(_therapist.ID))
            {
                Prescription p = Controller.Instance.GetPrescriptionByID(s.IDPrescription);
                string patient = Controller.Instance.GetPatientByID(p.IDPatient).Username;
                string[] row = new string[] { patient, p.Prescriptionable.Name, p.Schedule.ToString(), s.Note };
                sessionsTable.Rows.Add(row);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            _formTherapist.MdiParent = this.MdiParent;
            this.Hide();
            _formTherapist.Show();
        }
    }
}
