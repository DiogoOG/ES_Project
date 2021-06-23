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
        User _patient;
        FormLogin _formLogin;
        int _currentRow=0;
        

        public FormPatient(User patient, FormLogin formLogin)
        {
            this._formLogin = formLogin;
            this._patient = patient;
            InitializeComponent();
            permissionList.Visible = false;
            decideButton.Visible = false;
            doneButton.Visible = false;
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            _formLogin.MdiParent = this.MdiParent;
            this.Hide();
            _formLogin.Show();
        }

        private void FormPatient_Load(object sender, EventArgs e)
        {
            foreach (Prescription prescription in Controller.Instance.getPrescriptionsByPatient(_patient))
            {
                string therapist = Controller.Instance.GetTherapistById(prescription.IDTherapist).Username;
                string[] row = new string[] { therapist, prescription.Prescriptionable.Type, prescription.Prescriptionable.Name, prescription.Schedule.ToString() };
                prescriptionsTable.Rows.Add(row);
            }
            makePrivateButton_Click(null, null);
        }

        private void prescriptionsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _currentRow = e.RowIndex;

            if(_currentRow!=-1)
            {
                string therapist = prescriptionsTable.Rows[_currentRow].Cells[0].Value.ToString();
                string type = prescriptionsTable.Rows[_currentRow].Cells[1].Value.ToString();
                string name = prescriptionsTable.Rows[_currentRow].Cells[2].Value.ToString();
                DateTime schedule = DateTime.Parse(prescriptionsTable.Rows[_currentRow].Cells[3].Value.ToString());
                int idPatient = _patient.ID;

                bool visibility = Controller.Instance.GetVisibility(therapist, idPatient, type, name, schedule);
                if (visibility)
                {
                    changeButton.Text = "Make private";
                }
                else changeButton.Text = "Make public";
            }
            
        }

        private void makePrivateButton_Click(object sender, EventArgs e)
        { 
            string therapist = prescriptionsTable.Rows[_currentRow].Cells[0].Value.ToString();
            string type = prescriptionsTable.Rows[_currentRow].Cells[1].Value.ToString();
            string name = prescriptionsTable.Rows[_currentRow].Cells[2].Value.ToString();
            DateTime schedule = DateTime.Parse(prescriptionsTable.Rows[_currentRow].Cells[3].Value.ToString());
            int idPatient = _patient.ID;

            Controller.Instance.ChangeVisibility(therapist, idPatient, type, name, schedule);
            bool visibility = Controller.Instance.GetVisibility(therapist, idPatient, type, name, schedule);
            if (visibility)
            {
                changeButton.Text = "Make private";
            }
            else changeButton.Text = "Make public";
        }

        private void permissionButton_Click(object sender, EventArgs e)
        {
            permissionList.Items.Clear();
            foreach (Therapist t in Controller.Instance.GetAllTherapists())
            {
                permissionList.Items.Add(t.Username);
            }
            permissionList.Visible = true;
            decideButton.Visible = true;
            doneButton.Visible = true;
        }

        private void decideButton_Click(object sender, EventArgs e)
        {
            string therapistUsername = prescriptionsTable.Rows[_currentRow].Cells[0].Value.ToString();
            string type = prescriptionsTable.Rows[_currentRow].Cells[1].Value.ToString();
            string name = prescriptionsTable.Rows[_currentRow].Cells[2].Value.ToString();
            DateTime schedule = DateTime.Parse(prescriptionsTable.Rows[_currentRow].Cells[3].Value.ToString());
            int idPatient = _patient.ID;

            Therapist prescriptionTherapist = Controller.Instance.GetTherapistByUsername(therapistUsername);
            Prescription p = Controller.Instance.GetPrescription(prescriptionTherapist.ID, idPatient, type, name, schedule);

            string selectedTherapist = permissionList.SelectedItem.ToString();
            Therapist permissionTherapist = Controller.Instance.GetTherapistByUsername(selectedTherapist);

            if (p.HasPermission(permissionTherapist.ID))
            {
                Controller.Instance.removePermission(p.ID,permissionTherapist.ID);
                decideButton.Text = "Add";
            }
            else {
                Controller.Instance.addPermission(p.ID, permissionTherapist.ID);
                decideButton.Text = "Remove";
            }

        }

        private void permissionList_SelectedIndexChanged(object sender, EventArgs e)
        {

            string therapistUsername = prescriptionsTable.Rows[_currentRow].Cells[0].Value.ToString();
            string type = prescriptionsTable.Rows[_currentRow].Cells[1].Value.ToString();
            string name = prescriptionsTable.Rows[_currentRow].Cells[2].Value.ToString();
            DateTime schedule = DateTime.Parse(prescriptionsTable.Rows[_currentRow].Cells[3].Value.ToString());
            int idPatient = _patient.ID;

            Therapist prescriptionTherapist = Controller.Instance.GetTherapistByUsername(therapistUsername);
            Prescription p = Controller.Instance.GetPrescription(prescriptionTherapist.ID, idPatient, type, name, schedule);

            string selectedTherapist = permissionList.SelectedItem.ToString();
            Therapist permissionTherapist = Controller.Instance.GetTherapistByUsername(selectedTherapist);

            if (p.HasPermission(permissionTherapist.ID))
                decideButton.Text = "Remove";
            else decideButton.Text = "Add";
        }
    }
}
