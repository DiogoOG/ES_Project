using Clinic;
using System;
using System.Windows.Forms;

namespace ClinicInterface
{
    public partial class FormPatient : Form
    {
        User _patient;
        FormLogin _formLogin;
        int _currentRow=0;
        private int _currentLine=0;

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

            string[] fields = getDataFromTable();
            int idPatient = _patient.ID;

            changeVisibilityButton(fields, idPatient);

            permissionList.Items.Clear();
            foreach (Therapist t in Controller.Instance.GetAllTherapists())
            {
                permissionList.Items.Add(t.Username);
            }

            Therapist prescriptionTherapist = Controller.Instance.GetTherapistByUsername(fields[0]);
            Prescription p = Controller.Instance.GetPrescription(prescriptionTherapist.ID, idPatient, fields[1], fields[2], DateTime.Parse(fields[3]));

            string selectedTherapist = permissionList.Items[_currentLine].ToString();
            Therapist permissionTherapist = Controller.Instance.GetTherapistByUsername(selectedTherapist);

            if (p.HasPermission(permissionTherapist.ID))
                decideButton.Text = "Remove";
            else decideButton.Text = "Add";

        }

        private void prescriptionsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _currentRow = e.RowIndex;

            if(_currentRow!=-1)
            {
                string[] fields = getDataFromTable();
                int idPatient = _patient.ID;

                changeVisibilityButton(fields, idPatient);
            }
            
        }

        private void makePrivateButton_Click(object sender, EventArgs e)
        {
            string[] fields = getDataFromTable();
            int idPatient = _patient.ID;

            Controller.Instance.ChangeVisibility(fields[0], idPatient, fields[1], fields[2], DateTime.Parse(fields[3]));
            changeVisibilityButton(fields, idPatient);
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
            if (permissionList.SelectedIndex != -1)
            {
                errorLabel.Visible = false;
                string[] fields = getDataFromTable();
                int idPatient = _patient.ID;

                Therapist prescriptionTherapist = Controller.Instance.GetTherapistByUsername(fields[0]);
                Prescription p = Controller.Instance.GetPrescription(prescriptionTherapist.ID, idPatient, fields[1], fields[2], DateTime.Parse(fields[3]));

                string selectedTherapist = permissionList.SelectedItem.ToString();
                Therapist permissionTherapist = Controller.Instance.GetTherapistByUsername(selectedTherapist);

                if (p.HasPermission(permissionTherapist.ID))
                {
                    Controller.Instance.removePermission(p.ID, permissionTherapist.ID);
                    decideButton.Text = "Add";
                }
                else
                {
                    Controller.Instance.addPermission(p.ID, permissionTherapist.ID);
                    decideButton.Text = "Remove";
                }
            }
            else errorLabel.Visible = true;
            

        }

        private void permissionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentLine = permissionList.SelectedIndex;

            string[] fields = getDataFromTable();
            int idPatient = _patient.ID;

            Therapist prescriptionTherapist = Controller.Instance.GetTherapistByUsername(fields[0]);
            Prescription p = Controller.Instance.GetPrescription(prescriptionTherapist.ID, idPatient, fields[1], fields[2], DateTime.Parse(fields[3]));

            string selectedTherapist = permissionList.SelectedItem.ToString();
            Therapist permissionTherapist = Controller.Instance.GetTherapistByUsername(selectedTherapist);

            if (p.HasPermission(permissionTherapist.ID))
                    decideButton.Text = "Remove";
            else decideButton.Text = "Add";

            
        }

        public string[] getDataFromTable()
        {
            string[] fields = new string[4];
            fields[0] = prescriptionsTable.Rows[_currentRow].Cells[0].Value.ToString();  //therapist username
            fields[1] = prescriptionsTable.Rows[_currentRow].Cells[1].Value.ToString();  //type of prescriptions
            fields[2] =  prescriptionsTable.Rows[_currentRow].Cells[2].Value.ToString(); //name of prescription
            fields[3] = prescriptionsTable.Rows[_currentRow].Cells[3].Value.ToString();  //schedule of prescription

            return fields;
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            permissionList.Visible = false;
            decideButton.Visible = false;
            doneButton.Visible = false;
        }

        private void changeVisibilityButton(string[] fields, int idPatient)
        {
            bool visibility = Controller.Instance.GetVisibility(fields[0], idPatient, fields[1], fields[2], DateTime.Parse(fields[3]));
            if (visibility)
            {
                changeButton.Text = "Make private";
            }
            else changeButton.Text = "Make public";
        }
    }
}
