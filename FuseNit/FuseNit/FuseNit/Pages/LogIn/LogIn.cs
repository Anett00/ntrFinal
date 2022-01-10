using FuseNit.Actions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuseNit.Pages.LogIn
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();

            ControlActions checkDataBase = new ControlActions();
            checkDataBase.CheckProperties();

            ControlActions checkTables = new ControlActions();
            checkTables.CheckDataBase();
        }

        User user = new User();

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            TryToLogIn(txtBoxUserName.Text, txtBoxPassword.Text);
        }

        private void btnLogIn_Enter(object sender, EventArgs e)
        {
            TryToLogIn(txtBoxUserName.Text, txtBoxPassword.Text);
        }

        private void TryToLogIn(string userName, string password)
        {
            int count = 0;

            DataBaseActions getMyProfil = new DataBaseActions();
            count = getMyProfil.GetMyProfil(userName, password, user , count);

            if (count != 0)
            {
                this.DialogResult = DialogResult.OK;
                HomePage.user = user;
            }

            else
            {
                MessageBox.Show("Rossz felhasználónév és/vagy jelszó!");
                txtBoxUserName.Clear();
                txtBoxPassword.Clear();
                txtBoxUserName.Focus();
            }
        }
    }
}
