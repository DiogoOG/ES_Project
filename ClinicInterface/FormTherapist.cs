using Clinic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClinicInterface
{
    public partial class FormTherapist : Form, IObserver
    {
        private Controller controller;
        private User therapist;
        private FormLogin formLogin;
        private bool seeAll;
        private int currentRow;
        public FormTherapist(Controller controller, User therapist, FormLogin formLogin)
        {
            this.controller = controller;
            this.therapist = therapist;
            this.formLogin = formLogin;
            InitializeComponent();
            errorLabel.Visible = false;
        }

        //shows all the prescriprions the therapist can see (own and public)
        private void FormTherapist_Load(object sender, EventArgs e)
        {
            foreach(Prescription prescription in controller.GetAccessiblePrescriptions(therapist))
            {
                string username = controller.GetPatientByID(prescription.IDPatient).Username;
                string[] row = new string[] { username, prescription.Prescriptionable.Type, prescription.Prescriptionable.Name, prescription.Schedule.ToString() };
                prescriptionsTable.Rows.Add(row);
            }
            seeAll = true;
            showButton.Text = "See own";
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

            controller.EditPrescription(newType, newName, newDate, idTherapist, patient, type, name, schedule);
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

        //show only own prescriptions
        private void showFiltered()
        {
            prescriptionsTable.Rows.Clear();
            foreach (Prescription prescription in controller.GetPrescriptionsByTherapist(therapist))
            {
                string username = controller.GetPatientByID(prescription.IDPatient).Username;
                string[] row = new string[] { username, prescription.Prescriptionable.Type, prescription.Prescriptionable.Name, prescription.Schedule.ToString() };
                prescriptionsTable.Rows.Add(row);
            }
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

        private void showButton_Click(object sender, EventArgs e)
        {
            if(seeAll==true)
            {
                showFiltered();
                showButton.Text = "See all";
                seeAll = false;
            }
            else
            {
                prescriptionsTable.Rows.Clear();
                FormTherapist_Load(null,null);
                showButton.Text = "See own";
                seeAll = true;
            }
        }

        private void sessionButton_Click(object sender, EventArgs e)
        {
            errorLabel.Visible = false;
            string patient = prescriptionsTable.SelectedRows[currentRow].Cells[0].Value.ToString();
            string type = prescriptionsTable.SelectedRows[currentRow].Cells[1].Value.ToString();
            string name = prescriptionsTable.SelectedRows[currentRow].Cells[2].Value.ToString();
            DateTime schedule = DateTime.Parse(prescriptionsTable.SelectedRows[currentRow].Cells[3].Value.ToString());
            int idTherapist = therapist.ID;

            Patient p = controller.GetPatientByUsername(patient);
            Prescription prescription = controller.GetPrescription(idTherapist, p.ID, type, name, schedule);

            if(prescription.Prescriptionable.Type=="Treatment")
            {
                FormCreateSession formCreateSession = new FormCreateSession(controller, this, therapist, prescription);
                formCreateSession.MdiParent = this.MdiParent;
                this.Hide();
                formCreateSession.Show();
            }
            else
            {
                errorLabel.Visible = true;
            }
        }
    }
}
