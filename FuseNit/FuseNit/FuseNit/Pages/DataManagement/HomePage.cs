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

namespace FuseNit.Pages
{
    public partial class HomePage : Form
    {
        public static Actions.User user;
        public Actions.User user1;
        Button[] buttonsOptional;
        Button[] buttonForAdmin;
        Button[] buttonForUsers;
        Button[] buttonHideable;
        PictureBox[] picturesOptional;
        PictureBox[] picturesForAdmin;
        PictureBox[] picturesForUsers;
        PictureBox[] picturesHidable;

        public HomePage(Actions.User user)
        {
            InitializeComponent();
            buttonsOptional = new[] { btnUser, btnVehicle, btnDriver, btnCompany };
            buttonForUsers = new[] { btnDriver, btnCustomer, btnProject };
            buttonForAdmin = new[] { btnUser, btnDriver, btnVehicle, btnCompany, btnCustomer, btnProject };
            picturesOptional = new[] { pbUsers, pbVehicles, pbDrivers, pbCompany };
            picturesForAdmin = new[] { pbUsers, pbDrivers, pbVehicles, pbProjects, pbCustomer, pbCompany };
            picturesForUsers = new[] { pbDrivers, pbProjects, pbCustomer };
            GroundSettings(user.userName, user.isItAdmin);
            user1 = user;
        }



        public void GroundSettings(string userName, bool admin)
        {
            lblUserName.Text = userName;
            if (admin)
            {
                for (int i = 0; i < buttonsOptional.Length; i++)
                {
                    buttonsOptional[i].Visible = true;
                    picturesOptional[i].Visible = true;
                }
                    buttonHideable = buttonForAdmin;
                    picturesHidable = picturesForAdmin;
            }

            else
            {
                for (int i = 0; i < buttonsOptional.Length; i++)
                {
                    buttonsOptional[i].Visible = false;
                    picturesOptional[i].Visible = false;
                }
                    buttonHideable = buttonForUsers;
                    picturesHidable = picturesForUsers;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblTimeNow.Text = DateTime.Now.ToString("yyyy.MM.dd.\nHH:mm:ss");
        }

        private void btnHomePage_Click(object sender, EventArgs e)
        {

        }

        private void btnMyProfil_Click(object sender, EventArgs e)
        {
            HomePageActions hide = new HomePageActions();
            hide.HideButtons(buttonHideable, picturesHidable);
            HomePageActions openChildform = new HomePageActions();
            openChildform.OpenChildForm(new Pages.DataManagement.MyProfil(user1), panelChildForm);
        }

        private void btnDataBase_Click(object sender, EventArgs e)
        {
            HomePageActions buttonVisible = new HomePageActions();
            buttonVisible.ShowHideButton(btnUser, buttonHideable, picturesHidable);
        }

        private void btnDeliverySheet_Click(object sender, EventArgs e)
        {
            HomePageActions hide = new HomePageActions();
            hide.HideButtons(buttonHideable, picturesHidable);
            HomePageActions openChildform = new HomePageActions();
            openChildform.OpenChildForm(new Pages.DataManagement.DeliveryNote(), panelChildForm);
        }

        private void pbHamburgerMenu_Click(object sender, EventArgs e)
        {
            HomePageActions hidePanel = new HomePageActions();
            hidePanel.HideSubPanelWithHamburger(panelMenuLeft);
        }

        private void btnVehicle_Click(object sender, EventArgs e)
        {
            HomePageActions openChildform = new HomePageActions();
            openChildform.OpenChildForm(new Pages.DataManagement.Vehicle(), panelChildForm);
        }

        private void btnDriver_Click(object sender, EventArgs e)
        {
            HomePageActions openChildform = new HomePageActions();
            openChildform.OpenChildForm(new Pages.DataManagement.Driver(), panelChildForm);
        }

        private void btnProject_Click(object sender, EventArgs e)
        {
            HomePageActions openChildform = new HomePageActions();
            openChildform.OpenChildForm(new Pages.DataManagement.Project(), panelChildForm);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            HomePageActions openChildform = new HomePageActions();
            openChildform.OpenChildForm(new Pages.DataManagement.Customer(), panelChildForm);
        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            HomePageActions openChildform = new HomePageActions();
            openChildform.OpenChildForm(new Pages.DataManagement.Company(), panelChildForm);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            HomePageActions openChildform = new HomePageActions();
            openChildform.OpenChildForm(new Pages.DataManagement.User(), panelChildForm);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
