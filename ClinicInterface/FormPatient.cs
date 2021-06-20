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
        Controller controller;
        User patient;
        FormLogin formLogin;
        

        public FormPatient(Controller controller, User patient, FormLogin formLogin)
        {
            this.controller = controller;
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
            foreach (Prescription prescription in controller.getPrescriptionsByPatient(patient))
            {
                string therapist = controller.getUserById(prescription.IdTherapist).Username;
                string[] row = new string[] { therapist, prescription.Prescriptionable.Type, prescription.Prescriptionable.Name, prescription.Schedule.ToString() };
                prescriptionsTable.Rows.Add(row);
            }
        }
    }
}
