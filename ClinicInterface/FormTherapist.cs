using Clinic;
using System;
using System.Windows.Forms;

namespace ClinicInterface
{
    public partial class FormTherapist : Form
    {
        private Controller controller;
        private User therapist;
        private FormLogin formLogin;
        public FormTherapist(Controller controller, User therapist, FormLogin formLogin)
        {
            this.controller = controller;
            this.therapist = therapist;
            this.formLogin = formLogin;
            InitializeComponent();
        }

        private void FormTherapist_Load(object sender, EventArgs e)
        {
            foreach(Prescription prescription in controller.getPrescriptionsByTherapist(therapist))
            {
                string username = controller.getUserById(prescription.IdPatient).Username;
                string[] row = new string[] { username, prescription.Prescriptionable.Type, prescription.Prescriptionable.Name, prescription.Schedule.ToString() };
                prescriptionsTable.Rows.Add(row);
            }
        }

        private void createPrescriptionButton_Click(object sender, EventArgs e)
        {
            FormCreatePrescription formCreate = new FormCreatePrescription(controller, therapist,this);
            formCreate.MdiParent = this.MdiParent;
            this.Hide();
            formCreate.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formLogin.MdiParent = this.MdiParent;
            this.Hide();
            formLogin.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void editButton_Click(object sender, EventArgs e)
        {

        }

        private void prescriptionsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
