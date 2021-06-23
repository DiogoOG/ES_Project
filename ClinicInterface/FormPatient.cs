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
    public partial class FormPatient : Form
    {
        User patient;
        FormLogin formLogin;
        int currentRow;

        public FormPatient(User patient, FormLogin formLogin)
        {
            this.formLogin = formLogin;
            this.patient = patient;
            InitializeComponent();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            formLogin.MdiParent = this.MdiParent;
            this.Hide();
            formLogin.Show();
        }

        private void FormPatient_Load(object sender, EventArgs e)
        {
            foreach (Prescription prescription in Controller.Instance.GetPrescriptionsByPatient(patient))
            {
                string therapist = Controller.Instance.GetTherapistByID(prescription.IDTherapist).Username;
                string[] row = new string[] { therapist, prescription.Prescriptionable.Type, prescription.Prescriptionable.Name, prescription.Schedule.ToString() };
                prescriptionsTable.Rows.Add(row);
            }
        }

        private void prescriptionsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            currentRow = e.RowIndex;

            string therapist = prescriptionsTable.Rows[currentRow].Cells[0].Value.ToString();
            string type = prescriptionsTable.Rows[currentRow].Cells[1].Value.ToString();
            string name = prescriptionsTable.Rows[currentRow].Cells[2].Value.ToString();
            DateTime schedule = DateTime.Parse(prescriptionsTable.Rows[currentRow].Cells[3].Value.ToString());
            int idPatient = patient.ID;

            bool visibility = Controller.Instance.GetVisibility(therapist, idPatient, type, name, schedule);
            if (visibility)
            {
                changeButton.Text = "Make private";
            }
            else changeButton.Text = "Make public";
            changeButton.Visible = true;
        }

        private void makePrivateButton_Click(object sender, EventArgs e)
        { 
            string therapist = prescriptionsTable.Rows[currentRow].Cells[0].Value.ToString();
            string type = prescriptionsTable.Rows[currentRow].Cells[1].Value.ToString();
            string name = prescriptionsTable.Rows[currentRow].Cells[2].Value.ToString();
            DateTime schedule = DateTime.Parse(prescriptionsTable.Rows[currentRow].Cells[3].Value.ToString());
            int idPatient = patient.ID;

            Controller.Instance.ChangeVisibility(therapist, idPatient, type, name, schedule);
            changeButton.Visible = false;
        }
    }
}
