using FuseNit.Actions;
using FuseNit.UserControls;
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
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
            btnDelete.Enabled = false;
            btnModify.Enabled = false;
            pbDelete.Enabled = false;
            pbModify.Enabled = false;
            FillPanel();
        }

        List<Actions.User> userList = new List<Actions.User>();

        void FillPanel()
        {
            userList.Clear();
            flpUser.Controls.Clear();

            DataBaseActions getUsers = new DataBaseActions();

            foreach (Actions.User usersList in getUsers.GetAllUser(userList))
            {
                ucUser userControl = new ucUser(usersList);
                userControl.Click += new EventHandler(this.ucUser_Click);
                userControl.AddButtonClick += (sender, args) => this.ucUser_Click(userControl, args);
                flpUser.Controls.Add(userControl);
            }
        }

        public void ucUser_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
            btnModify.Enabled = true;
            pbDelete.Enabled = true;
            pbModify.Enabled = true;

            ucUser control = (ucUser)sender;
            TextBox[] text = new TextBox[] { txtUser, txtFirstName, txtLastName, txtFullName, txtPassword };
            ComboBox[] combo = new ComboBox[] { cbAdmin, cbDriver };
            int userID = Convert.ToInt32(control.lblID.Text);

            for (int i = 0; i < text.Length; i++)
            {
                text[i].Visible = true;
            }

            for (int i = 0; i < combo.Length; i++)
            {
                combo[i].Visible = true;
            }

            var user = from x in userList
                       where x.userID == userID
                       select x;

            foreach (var x in user)
            {
                FormActions cbIndex = new FormActions();
                FormActions toRank = new FormActions();
                FormActions toLevel = new FormActions();

                int driverIndex = cbIndex.StringToComboBoxIndex(cbDriver, toRank.BoolToRank(x.isItADriver.ToString()));
                int adminIndex = cbIndex.StringToComboBoxIndex(cbAdmin, toRank.BoolToLevel(x.isItAdmin.ToString()));

                txtID.Text = x.userID.ToString();
                txtUser.Text = x.userName.ToString();
                txtFirstName.Text = x.firstName.ToString();
                txtLastName.Text = x.lastName.ToString();
                txtFullName.Text = x.fullName.ToString();
                txtPassword.Text = x.password.ToString();
                cbAdmin.SelectedIndex = adminIndex;
                cbDriver.SelectedIndex = driverIndex;
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            bool admin = false;
            bool driver = false;

            if (cbAdmin.SelectedIndex == 0)
            {
                admin = true;
            }

            if (cbDriver.SelectedIndex == 0)
            {
                driver = true;
            }

            string sql = "UPDATE users SET " +
                    "userName = '" + txtUser.Text +
                    "', password = '" + txtPassword.Text +
                    "', firstName = '" + txtFirstName.Text +
                    "', lastName = '" + txtLastName.Text +
                    "', isItAdmin = '" + admin +
                    "', isItADriver = '" + driver + "' " +
                    "WHERE  userID = '" + Convert.ToInt32(txtID.Text) + "';";

            DataBaseActions modify = new DataBaseActions();
            modify.ModifyDataBase(sql);

            if (driver)
            {
                DataBaseActions driverExists = new DataBaseActions();
                List<Actions.Driver> driverList = new List<Actions.Driver>();
                driverList.Clear();
                driverList = driverExists.GetAllDriver(driverList);

                int existsDriverID = 0;

                for (int i = 0; i < driverList.Count; i++)
                {
                    if (driverList[i].userID == Convert.ToInt32(txtID.Text))
                    {
                        existsDriverID++;
                    }
                }

                if (existsDriverID == 0)
                {

                    string sqld = "INSERT INTO drivers (userID, birthCountry, birthPlace, birthDate, mothersName, drivingLicenseNumber, drivingLicenseExpireDate) VALUES ('" + Convert.ToInt32(txtID.Text) + "', '', '', '" + DateTime.Now + "', '', '', '" + DateTime.Now + "')";

                    DataBaseActions driverModify = new DataBaseActions();
                    driverModify.ActionWithDataBase(sqld);
                }
            }
            else
            {
                DataBaseActions driverExists = new DataBaseActions();
                List<Actions.Driver> driverList = new List<Actions.Driver>();
                driverList.Clear();
                driverList = driverExists.GetAllDriver(driverList);

                int existsDriverID = 0;

                for (int i = 0; i < driverList.Count; i++)
                {
                    if (driverList[i].userID == Convert.ToInt32(txtID.Text))
                    {
                        existsDriverID++;
                    }
                }

                if (existsDriverID > 0)
                {

                    string sqld = "DELETE FROM drivers WHERE userID = '" + Convert.ToInt32(txtID.Text) + "'";

                    DataBaseActions driverModify = new DataBaseActions();
                    driverModify.ActionWithDataBase(sqld);
                }
            }
            FillPanel();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO users (userName, password, firstName, lastName, isItAdmin, isItADriver) VALUES ('user', 'user', 'Új', 'Felhasználó', 'false', 'false')";

            DataBaseActions add = new DataBaseActions();
            add.ActionWithDataBase(sql);
            FillPanel();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM users WHERE userID ='" + Convert.ToInt32(txtID.Text) + "';";

            DataBaseActions delete = new DataBaseActions();
            delete.DeleteFromDataBase(sql);
            FillPanel();
        }
    }
}
