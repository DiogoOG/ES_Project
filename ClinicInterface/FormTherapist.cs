using Clinic;
using Clinic.Utils;
using System;
using System.Windows.Forms;

namespace ClinicInterface
{
    public partial class FormTherapist : Form, IObserver
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
                string username = controller.getPatientById(prescription.IdPatient).Username;
                string[] row = new string[] { username, prescription.Prescriptionable.Type, prescription.Prescriptionable.Name, prescription.Schedule.ToString() };
                prescriptionsTable.Rows.Add(row);
            }
        }

        private void createPrescriptionButton_Click(object sender, EventArgs e)
        {
            FormCreatePrescription formCreate = new FormCreatePrescription(controller, therapist,this);
            formCreate.MdiParent = this.MdiParent;
            formCreate.addObserver(this);
            this.Hide();
            formCreate.Show();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            changeButtonsVisibility(true);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string newType = newTypeBox.Text;
            string newName = newNameBox.Text;
            DateTime newDate = newDatePicker.Value;
            int idTherapist = this.therapist.ID;
            string patient = prescriptionsTable.SelectedRows[0].Cells[0].Value.ToString();
            string type = prescriptionsTable.SelectedRows[0].Cells[1].Value.ToString();
            string name = prescriptionsTable.SelectedRows[0].Cells[2].Value.ToString();
            DateTime schedule = DateTime.Parse(prescriptionsTable.SelectedRows[0].Cells[3].Value.ToString());

            controller.editPrescription(newType, newName, newDate, idTherapist, patient, type, name, schedule);
            newTypeBox.Text = "";
            newNameBox.Text = "";

            changeButtonsVisibility(false);
            updateTable();
        }

        private void changeButtonsVisibility(bool visibility)
        {
            newTypeBox.Visible = visibility;
            newNameBox.Visible = visibility;
            newDatePicker.Visible = visibility;
            saveButton.Visible = visibility;
            cancelButton.Visible = visibility;
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            formLogin.MdiParent = this.MdiParent;
            this.Hide();
            formLogin.Show();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            newTypeBox.Text = "";
            newNameBox.Text = "";

            changeButtonsVisibility(false);
        }

        private void updateTable()
        {
            prescriptionsTable.Rows.Clear();
            FormTherapist_Load(null, null);
        }

        public void Update(ISubject subject)
        {
            updateTable();
        }
    }
}
