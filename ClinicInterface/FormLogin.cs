﻿using Clinic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicInterface
{
    public partial class FormLogin : Form
    {
        private User user;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            FormSignUp formSignUp = new FormSignUp(this);
            formSignUp.MdiParent = this.MdiParent;
            this.Hide();
            formSignUp.Show();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {

            bool valid = true;
            usernameLabel.Text = "";
            passwordLabel.Text = "";
            errorLabel.Text = "";

            string username = usernameBox.Text;
            string password = passwordBox.Text;
            usernameBox.Text = "";
            passwordBox.Text = "";

            if (username == "")
            {
                usernameLabel.Text = "Invalid username!";
                valid = false;
                
            }
            if (password == "")
            {
                passwordLabel.Text = "Invalid password!";
                valid = false;
            }

            if (valid)
            {
                user = Controller.Instance.GetPatientByUsername(username);
                if (user == null)
                    user = Controller.Instance.GetTherapistByUsername(username);
                if (user == null)
                    errorLabel.Text = "The user doesn't exist!";
                else
                {
                    if (user.Password != password)
                        errorLabel.Text = "Incorrect password!";
                    else
                    {
                        if (Controller.Instance.IsPatient(username))
                        {
                            openPatientForm();
                        }
                        else
                        {
                            openTherapistForm();
                        }
                        
                    }
                }
            } 
        }

        private void openPatientForm()
        {
            FormPatient formPatient = new FormPatient(user, this);
            formPatient.MdiParent = this.MdiParent;
            this.Hide();
            formPatient.Show();
        }

        private void openTherapistForm()
        {
            FormTherapist formTherapist = new FormTherapist(user, this);
            formTherapist.MdiParent = this.MdiParent;
            this.Hide();
            formTherapist.Show();
        }
    }
}
