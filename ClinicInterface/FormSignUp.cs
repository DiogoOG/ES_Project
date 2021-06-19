using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClinicInterface
{
    public partial class FormSignUp : Form
    {

        private Controller controller;
        FormLogin formLogin;
        public FormSignUp(Controller controller, FormLogin formLogin)
        {
            this.controller = controller;
            this.formLogin = formLogin;
            InitializeComponent();
        }

        private void FormSignUp_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            bool valid = true;
            usernameLabel.Text = "";
            passwordLabel.Text = "";

            string username = usernameBox.Text;
            string password = passwordBox.Text;

            if ((username == "") || (username.Length<3))
            {
                usernameLabel.Text = "Invalid username!";
                valid = false;
            }
            if ((password == "") || (password.Length < 3))
            {
                passwordLabel.Text = "Invalid password!";
                valid = false;
            }

            if (valid)
            {
                if (typeBox.SelectedItem.ToString() == "Patient")
                    controller.savePatient(username, password);
                else if (typeBox.SelectedItem.ToString() == "Therapist")
                    controller.saveTherapist(username, password);
            }


           
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            formLogin.MdiParent = this.MdiParent;
            this.Hide();
            formLogin.Show();
        }
    }
}
