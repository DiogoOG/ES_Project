using Clinic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClinicInterface
{
    public partial class FormTherapist : Form, IObserver
    {
        private User _therapist;
        private FormLogin _formLogin;
        private bool _seeAll;
        private int _currentRow;
        public FormTherapist(User therapist, FormLogin formLogin)
        {
            this._therapist = therapist;
            this._formLogin = formLogin;
            InitializeComponent();
            errorLabel.Visible = false;
        }

        //shows all the prescriprions the therapist can see (own and public)
        private void FormTherapist_Load(object sender, EventArgs e)
        {
            foreach(Prescription prescription in Controller.Instance.getAccessiblePrescriptions(_therapist))
            {
                string username = Controller.Instance.GetPatientByID(prescription.IDPatient).Username;
                string[] row = new string[] { username, prescription.Prescriptionable.Type, prescription.Prescriptionable.Name, prescription.Schedule.ToString() };
                prescriptionsTable.Rows.Add(row);
            }
            _seeAll = true;
            showButton.Text = "See own";
        }

        private void createPrescriptionButton_Click(object sender, EventArgs e)
        {
            FormCreatePrescription formCreate = new FormCreatePrescription(_therapist,this);
            formCreate.MdiParent = this.MdiParent;
            formCreate.AddObserver(this);
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
            int idTherapist = this._therapist.ID;
            string patient = prescriptionsTable.Rows[_currentRow].Cells[0].Value.ToString();
            string type = prescriptionsTable.Rows[_currentRow].Cells[1].Value.ToString();
            string name = prescriptionsTable.Rows[_currentRow].Cells[2].Value.ToString();
            DateTime schedule = DateTime.Parse(prescriptionsTable.Rows[_currentRow].Cells[3].Value.ToString());

            Controller.Instance.editPrescription(newType, newName, newDate, idTherapist, patient, type, name, schedule);
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
            _formLogin.MdiParent = this.MdiParent;
            this.Hide();
            _formLogin.Show();
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
            foreach (Prescription prescription in Controller.Instance.getPrescriptionsByTherapist(_therapist))
            {
                string username = Controller.Instance.GetPatientByID(prescription.IDPatient).Username;
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
            if(_seeAll==true)
            {
                showFiltered();
                showButton.Text = "See all";
                _seeAll = false;
            }
            else
            {
                prescriptionsTable.Rows.Clear();
                FormTherapist_Load(null,null);
                showButton.Text = "See own";
                _seeAll = true;
            }
        }

        private void sessionButton_Click(object sender, EventArgs e)
        {
            if(_currentRow!=-1)
            {
                errorLabel.Visible = false;
                string patient = prescriptionsTable.Rows[_currentRow].Cells[0].Value.ToString();
                string type = prescriptionsTable.Rows[_currentRow].Cells[1].Value.ToString();
                string name = prescriptionsTable.Rows[_currentRow].Cells[2].Value.ToString();
                DateTime schedule = DateTime.Parse(prescriptionsTable.Rows[_currentRow].Cells[3].Value.ToString());
                int idTherapist = _therapist.ID;

                Patient p = Controller.Instance.GetPatientByUsername(patient);
                Prescription prescription = Controller.Instance.GetPrescription(idTherapist, p.ID, type, name, schedule);

                if (prescription.Prescriptionable.Type == "Treatment")
                {
                    FormCreateSession formCreateSession = new FormCreateSession(this, _therapist, prescription);
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

        private void prescriptionsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _currentRow = e.RowIndex;   
        }

        private void seeSessionButton_Click(object sender, EventArgs e)
        {
            FormSessions formSessions = new FormSessions(this,_therapist);
            formSessions.MdiParent = this.MdiParent;
            this.Hide();
            formSessions.Show();
        }
    }
}
