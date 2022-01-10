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
    public partial class Customer : Form
    {
        List<Actions.Customer> customerList = new List<Actions.Customer>();
        TextBox[] textes;
        TextBox[] textesHead;
        TextBox[] textesMail;
        ComboBox[] combo;
        ComboBox[] comboHead;
        ComboBox[] comboMail;

        public Customer()
        {
            InitializeComponent();
            SetData();
            FillPanel();
        }

        void SetData()
        {
            textes = new[] { txtCustomerName, txtExecutiveDirector, txtName, txtVAT };
            textesHead = new[] { txtHeadCountry, txtHeadCity, txtHeadStreet, txtHeadNumber, txtHeadBuilding, txtHeadFloor, txtHeadDoor, txtHeadZIP };
            textesMail = new[] { txtMailCountry, txtMailCity, txtMailStreet, txtMailNumber, txtMailBuilding, txtMailFloor, txtMailDoor, txtMailZIP };
            combo = new[] { cbType };
            comboHead = new[] { cbHeadPlace };
            comboMail = new[] { cbMailPlace };

            btnDelete.Enabled = false;
            btnModify.Enabled = false;

            for (int i = 0; i < textes.Length; i++)
            {
                textes[i].Visible = false;
            }
            for (int i = 0; i < textesHead.Length; i++)
            {
                textesHead[i].Visible = false;
            }
            for (int i = 0; i < textesMail.Length; i++)
            {
                textesMail[i].Visible = false;
            }
            for (int i = 0; i < combo.Length; i++)
            {
                combo[i].Visible = false;
            }
            for (int i = 0; i < comboHead.Length; i++)
            {
                comboHead[i].Visible = false;
            }
            for (int i = 0; i < comboMail.Length; i++)
            {
                comboMail[i].Visible = false;
            }
        }

        void FillPanel()
        {
            customerList.Clear();
            flpCustomer.Controls.Clear();

            DataBaseActions customer = new DataBaseActions();

            foreach (Actions.Customer customerList in customer.GetAllCustomer(customerList))
            {
                ucCustomer companyControl = new ucCustomer(customerList);
                companyControl.Click += new EventHandler(this.ucCustomer_Click);
                companyControl.AddButtonClick += (sender, args) => this.ucCustomer_Click(companyControl, args);
                flpCustomer.Controls.Add(companyControl);
            }
        }

        private void ucCustomer_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
            btnModify.Enabled = true;

            ucCustomer control = (ucCustomer)sender;
            int customerID = Convert.ToInt32(control.lblID.Text);
            var customerName = from x in customerList
                               where x.customerID == customerID
                               select x;

            for (int i = 0; i < textes.Length; i++)
            {
                textes[i].Visible = true;
            }
            for (int i = 0; i < textesHead.Length; i++)
            {
                textesHead[i].Visible = true;
            }
            for (int i = 0; i < textesMail.Length; i++)
            {
                textesMail[i].Visible = true;
            }
            for (int i = 0; i < combo.Length; i++)
            {
                combo[i].Visible = true;
            }
            for (int i = 0; i < comboHead.Length; i++)
            {
                comboHead[i].Visible = true;
            }
            for (int i = 0; i < comboMail.Length; i++)
            {
                comboMail[i].Visible = true;
            }

            foreach (var x in customerName)
            {
                int typeCbID;
                int headCbID;
                int mailCbID;

                txtCustomerName.Text = x.customerName;
                lblID.Text = Convert.ToString(customerID);
                txtName.Text = x.customerName;
                txtExecutiveDirector.Text = x.customerExecutiveDirector;
                txtVAT.Text = x.customerVAT;
                txtHeadCountry.Text = x.customerHeadCountry;
                txtHeadCity.Text = x.customerHeadCity;
                txtHeadStreet.Text = x.customerHeadStreet;
                txtHeadNumber.Text = x.customerHeadNumber;
                txtHeadBuilding.Text = x.customerHeadBuilding;
                txtHeadFloor.Text = x.customerHeadFloor;
                txtHeadDoor.Text = x.customerHeadDoor;
                txtHeadZIP.Text = x.customerHeadZIPCode;
                txtMailCountry.Text = x.customerMailCountry;
                txtMailCity.Text = x.customerMailCity;
                txtMailStreet.Text = x.customerMailStreet;
                txtMailNumber.Text = x.customerMailNumber;
                txtMailBuilding.Text = x.customerMailBuilding;
                txtMailFloor.Text = x.customerMailFloor;
                txtMailDoor.Text = x.customerMailDoor;
                txtMailZIP.Text = x.customerMailZIPCode;

                if (x.customerType == "magánszemély")
                {
                    typeCbID = cbType.FindString(x.customerType.ToString());
                    panel17.Visible = false;
                    panel16.Visible = false;
                }
                else
                {
                    typeCbID = cbType.FindString(x.customerType.ToString());
                    txtExecutiveDirector.Visible = true;
                    txtVAT.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                }

                if (x.customerHeadPlace == "")
                {
                    headCbID = -1;
                }
                else
                {
                    headCbID = cbHeadPlace.FindString(x.customerHeadPlace.ToString());
                }

                if (x.customerMailPlace == "")
                {
                    mailCbID = -1;
                }
                else
                {
                    mailCbID = cbHeadPlace.FindString(x.customerMailPlace.ToString());
                }

                cbHeadPlace.SelectedIndex = headCbID;
                cbMailPlace.SelectedIndex = mailCbID;
                cbType.SelectedIndex = typeCbID;

                if (txtHeadBuilding.Text == txtMailBuilding.Text && txtHeadCity.Text == txtMailCity.Text && txtHeadCountry.Text == txtMailCountry.Text && txtHeadDoor.Text == txtMailDoor.Text && txtHeadFloor.Text == txtMailFloor.Text && txtHeadNumber.Text == txtMailNumber.Text && txtHeadStreet.Text == txtMailStreet.Text && txtHeadZIP.Text == txtMailZIP.Text)
                {
                    cbMailEqualHead.Checked = true;
                    pMail.Hide();
                }
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            string modify = "UPDATE customer SET " +
                       "customerName = '" + txtName.Text +
                       "', customerVAT = '" + txtVAT.Text +
                       "', customerType = '" + cbType.Text +
                       "', customerHeadCountry = '" + txtHeadCountry.Text +
                       "', customerHeadCity = '" + txtHeadCity.Text +
                       "', customerHeadStreet = '" + txtHeadStreet.Text +
                       "', customerHeadPlace = '" + cbHeadPlace.Text +
                       "', customerHeadNumber = '" + txtHeadNumber.Text +
                       "', customerHeadBuilding = '" + txtHeadBuilding.Text +
                       "', customerHeadFloor = '" + txtHeadFloor.Text +
                       "', customerHeadDoor = '" + txtHeadDoor.Text +
                       "', customerMailCountry = '" + txtMailCountry.Text +
                       "', customerMailCity = '" + txtMailCity.Text +
                       "', customerMailStreet = '" + txtMailStreet.Text +
                       "', customerMailPlace = '" + cbMailPlace.Text +
                       "', customerMailNumber = '" + txtMailNumber.Text +
                       "', customerMailBuilding = '" + txtMailBuilding.Text +
                       "', customerMailFloor = '" + txtMailFloor.Text +
                       "', customerMailDoor = '" + txtMailDoor.Text +
                       "', customerExecutiveDirector = '" + txtExecutiveDirector.Text +
                       "', customerHeadZIP = '" + txtHeadZIP.Text +
                       "', customerMailZIP = '" + txtMailZIP.Text + "' " +
                       "WHERE  customerID = '" + Convert.ToInt32(lblID.Text) + "';";

            DataBaseActions modifyCustomer = new DataBaseActions();
            modifyCustomer.ModifyDataBase(modify);

            FillPanel();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string add = "INSERT INTO customer (customerName, customerType, customerExecutiveDirector, customerVAT, customerHeadCountry, customerHeadCity, customerHeadStreet, customerHeadPlace, customerHeadNumber, customerHeadBuilding, customerHeadFloor, customerHeadDoor, customerHeadZIP, customerMailCountry, customerMailCity, customerMailStreet, customerMailPlace, customerMailNumber, customerMailBuilding, customerMailFloor, customerMailDoor, customerMailZIP) VALUES ('Új ügyfél', 'nem magánszemély', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '')";

            DataBaseActions addCustomer = new DataBaseActions();
            addCustomer.ActionWithDataBase(add);

            FillPanel();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string delete = "DELETE FROM customer WHERE customerID ='" + Convert.ToInt32(lblID.Text) + "';";

            DataBaseActions deleteCustomer = new DataBaseActions();
            deleteCustomer.DeleteFromDataBase(delete);

            FillPanel();
        }

        private void cbMailEqualHead_Click(object sender, EventArgs e)
        {
            if (cbMailEqualHead.Checked == true)
            {
                pMail.Hide();
            }
            else
            {
                pMail.Visible = true;
            }
        }
    }
}
