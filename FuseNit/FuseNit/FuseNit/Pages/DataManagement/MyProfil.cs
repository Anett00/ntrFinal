using FuseNit.Actions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuseNit.Pages.DataManagement
{
    public partial class MyProfil : Form
    {
        static Actions.User user;

        public MyProfil(Actions.User user)
        {
            InitializeComponent();
            MyProfil.user = user;
            GetMyProfil(MyProfil.user);
        }

        void GetMyProfil(Actions.User user)
        {
            try
            {
                string admin;
                string driver;

                if (user.isItAdmin)
                {
                    admin = "Adminisztrátor";
                }
                else
                {
                    admin = "Felhasználó";
                }

                if (user.isItADriver)
                {
                    driver = "Sofőr";
                }
                else
                {
                    driver = "Nem sofőr";
                }

                txtFirstName.Text = user.firstName;
                txtLastName.Text = user.lastName;
                txtUserName.Text = user.userName;
                txtPassword.Text = user.password;
                txtLevel.Text = admin;
                txtRank.Text = driver;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnUserModify_Click(object sender, EventArgs e)
        {
            string modifyUser = "UPDATE users SET " +
                "password = '" + txtPassword.Text + 
                "' WHERE userName = '" + txtUserName.Text + "'";

            DataBaseActions modify = new DataBaseActions();
            modify.ModifyDataBase(modifyUser);

            DataBaseActions getProfil = new DataBaseActions();
            user = getProfil.GetMyProfil(txtUserName.Text, txtPassword.Text, user);
            GetMyProfil(user);
        }
    }
}
