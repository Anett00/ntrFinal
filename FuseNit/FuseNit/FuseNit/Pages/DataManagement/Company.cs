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
    public partial class Company : Form
    {
        List<Actions.Company> companyList = new List<Actions.Company>();
        TextBox[] textes;
        TextBox[] textesHead;
        TextBox[] textesMail;
        ComboBox[] comboHead;
        ComboBox[] comboMail;

        public Company()
        {
            InitializeComponent();
            SetData();
            FillPanel();
        }

        void SetData()
        {
            textes = new[] { txtCompany, txtExecutiveDirector, txtVAT };
            textesHead = new[] { txtHeadCountry, txtHeadCity, txtHeadPlace, txtHeadNumber, txtHeadBuilding, txtHeadFloor, txtHeadDoor, txtHeadZIP };
            textesMail = new[] { txtMailCountry, txtMailCity, txtMailPlace, txtMailNumber, txtMailBuilding, txtMailFloor, txtMailDoor, txtMailZIP };
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
            companyList.Clear();
            flpCompany.Controls.Clear();

            DataBaseActions company = new DataBaseActions();

            foreach (Actions.Company companyList in company.GetAllCompany(companyList))
            {
                ucCustomer companyControl = new ucCustomer(companyList);
                companyControl.Click += new EventHandler(this.ucCustomer_Click);
                companyControl.AddButtonClick += (sender, args) => this.ucCustomer_Click(companyControl, args);
                flpCompany.Controls.Add(companyControl);
            }
        }

        void ucCustomer_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
            btnModify.Enabled = true;

            ucCustomer control = (ucCustomer)sender;
            int companyID = Convert.ToInt32(control.lblID.Text);
            var companyName = from x in companyList
                               where x.companyID == companyID
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
            for (int i = 0; i < comboHead.Length; i++)
            {
                comboHead[i].Visible = true;
            }
            for (int i = 0; i < comboMail.Length; i++)
            {
                comboMail[i].Visible = true;
            }

            foreach (var x in companyName)
            {
                int headCbID;
                int mailCbID;

                txtCompany.Text = x.companyName;
                lblID.Text = Convert.ToString(companyID);
                txtExecutiveDirector.Text = x.companyExeCutiveDirector;
                txtVAT.Text = x.companyVATNumber;
                txtHeadCountry.Text = x.companyHeadCountry;
                txtHeadCity.Text = x.companyHeadCity;
                txtHeadPlace.Text = x.companyHeadStreet;
                txtHeadNumber.Text = x.companyHeadNumber;
                txtHeadBuilding.Text = x.companyHeadBuilding;
                txtHeadFloor.Text = x.companyHeadFloor;
                txtHeadDoor.Text = x.companyHeadDoor;
                txtHeadZIP.Text = x.companyHeadZIPCode;
                txtMailCountry.Text = x.companyMailCountry;
                txtMailCity.Text = x.companyMailCity;
                txtMailPlace.Text = x.companyMailStreet;
                txtMailNumber.Text = x.companyMailNumber;
                txtMailBuilding.Text = x.companyMailBuilding;
                txtMailFloor.Text = x.companyMailFloor;
                txtMailDoor.Text = x.companyMailDoor;
                txtMailZIP.Text = x.companyMailZIPCode;

                if (x.companyHeadStreet == "")
                {
                    headCbID = -1;
                }
                else
                {
                    headCbID = cbHeadPlace.FindString(x.companyHeadStreet.ToString());
                }

                if (x.companyMailStreet == "")
                {
                    mailCbID = -1;
                }
                else
                {
                    mailCbID = cbHeadPlace.FindString(x.companyMailStreet.ToString());
                }

                cbHeadPlace.SelectedIndex = headCbID;
                cbMailPlace.SelectedIndex = mailCbID;

                if (txtHeadBuilding.Text == txtMailBuilding.Text && txtHeadCity.Text == txtMailCity.Text && txtHeadCountry.Text == txtMailCountry.Text && txtHeadDoor.Text == txtMailDoor.Text && txtHeadFloor.Text == txtMailFloor.Text && txtHeadNumber.Text == txtMailNumber.Text && txtHeadPlace.Text == txtMailPlace.Text && txtHeadZIP.Text == txtMailZIP.Text)
                {
                    cbMailEqualHead.Checked = true;
                    pMail.Hide();
                }
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            string modify = "UPDATE SelfCompany SET " +
                    "companyName = '" + txtCompany.Text +
                    "', companyVAT = '" + txtVAT.Text +
                    "', companyHeadCountry = '" + txtHeadCountry.Text +
                    "', companyHeadCity = '" + txtHeadCity.Text +
                    "', companyHeadStreet = '" + txtHeadPlace.Text +
                    "', companyHeadPlace = '" + cbHeadPlace.Text +
                    "', companyHeadNumber = '" + txtHeadNumber.Text +
                    "', companyHeadBuilding = '" + txtHeadBuilding.Text +
                    "', companyHeadFloor = '" + txtHeadFloor.Text +
                    "', companyHeadDoor = '" + txtHeadDoor.Text +
                    "', companyMailCountry = '" + txtMailCountry.Text +
                    "', companyMailCity = '" + txtMailCity.Text +
                    "', companyMailStreet = '" + txtMailPlace.Text +
                    "', companyMailPlace = '" + cbMailPlace.Text +
                    "', companyMailNumber = '" + txtMailNumber.Text +
                    "', companyMailBuilding = '" + txtMailBuilding.Text +
                    "', companyMailFloor = '" + txtMailFloor.Text +
                    "', companyMailDoor = '" + txtMailDoor.Text +
                    "', companyExecutiveDirector = '" + txtExecutiveDirector.Text +
                    "', companyHeadZIP = '" + txtHeadZIP.Text +
                    "', companyMailZIP = '" + txtMailZIP.Text + "' " +
                    "WHERE  companyID = '" + Convert.ToInt32(lblID.Text) + "';";

            DataBaseActions modifyCompany = new DataBaseActions();
            modifyCompany.ActionWithDataBase(modify);

            FillPanel();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string add = "INSERT INTO selfcompany (companyName, companyVAT, companyHeadCountry, companyHeadCity, companyHeadStreet, companyHeadPlace, companyHeadNumber, companyHeadBuilding, companyHeadFloor, companyHeadDoor, companyHeadZIP, companyMailCountry, companyMailCity, companyMailStreet, companyMailPlace, companyMailNumber, companyMailBuilding, companyMailFloor, companyMailDoor, companyMailZIP, companyExecutiveDirector) VALUES ('Új saját cég', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '')";

            DataBaseActions addCompany = new DataBaseActions();
            addCompany.ActionWithDataBase(add);

            FillPanel();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string delete = "DELETE FROM selfCompany WHERE companyID ='" + Convert.ToInt32(lblID.Text) + "';";

            DataBaseActions deleteCompany = new DataBaseActions();
            deleteCompany.DeleteFromDataBase(delete);

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
