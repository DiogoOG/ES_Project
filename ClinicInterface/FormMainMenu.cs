using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClinicInterface
{
    public partial class FormMainMenu : Form
    {
        Controller controller;
        FormLogin formLogin;

        public FormMainMenu(Controller controller, FormLogin formLogin)
        {
            this.controller = controller;
            this.formLogin = formLogin;
            InitializeComponent();
        }
    }
}
