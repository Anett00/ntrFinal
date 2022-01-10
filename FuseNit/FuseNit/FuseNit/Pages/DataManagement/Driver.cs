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
    public partial class Driver : Form
    {
        CheckBox[] categorie;
        CheckBox[] qlicat;
        TextBox[] textes;
        DateTimePicker[] dates;
        ComboBox[] combos;
        List<Actions.Driver> driverList = new List<Actions.Driver>();
        List<Actions.Categorie> categorieFullList = new List<Actions.Categorie>();
        List<Actions.Categorie> categorieDriverList = new List<Actions.Categorie>();
        List<Actions.Categorie> categorieCheckList = new List<Actions.Categorie>();
        List<Actions.QualificationLevelInCareerAptitudeTest> qlicatFullList = new List<Actions.QualificationLevelInCareerAptitudeTest>();
        List<Actions.QualificationLevelInCareerAptitudeTest> qlicatDriverList = new List<Actions.QualificationLevelInCareerAptitudeTest>();
        List<Actions.QualificationLevelInCareerAptitudeTest> qlicatCheckList = new List<Actions.QualificationLevelInCareerAptitudeTest>();

        public Driver()
        {
            InitializeComponent();
            btnDelete.Enabled = false;
            btnModify.Enabled = false;
            pbDelete.Enabled = false;
            pbModify.Enabled = false;
            textes = new[] { txtFirstName, txtLastName, txtFullName, txtMothersName, txtDrivingLicenseNumber, txtBirthPlace, txtBirthCountry };
            dates = new[] { dtpBirthDate, dtpDrivingLicenseExpireDate };
            combos = new[] { cbQLICAT };
            categorie = new[] { cbCatA, cbCatA1, cbCatA2, cbCatAM, cbCatB, cbCatB1, cbCatBE, cbCatC, cbCatC1, cbCatC1E, cbCatCE, cbCatD, cbCatD1, cbCatD1E, cbCatDE, cbCatTK };
            qlicat = new[] { cbCL1, cbCL2, cbCL3 };
            GetCategories();
            GetQlicat();
            FillPanel();
        }

        void GetCategories()
        {
            DataBaseActions categories = new DataBaseActions();
            categorieFullList = categories.GetAllCategorie(categorieFullList);
        }

        void GetQlicat()
        {
            DataBaseActions qlicat = new DataBaseActions();
            qlicatFullList = qlicat.GetAllQLICAT(qlicatFullList);
        }

        void FillPanel()
        {
            driverList.Clear();
            flpDriver.Controls.Clear();

            DataBaseActions getDriver = new DataBaseActions();

            foreach (Actions.Driver driverList in getDriver.GetAllDriver(driverList))
            {
                ucDriver userControl = new ucDriver(driverList);
                userControl.Click += new EventHandler(this.ucDriver_Click);
                userControl.AddButtonClick += (sender, args) => this.ucDriver_Click(userControl, args);
                flpDriver.Controls.Add(userControl);
            }
        }

        private void ucDriver_Click(object sender, EventArgs e)
        {
            ucDriver control = (ucDriver)sender;
            btnDelete.Enabled = true;
            btnModify.Enabled = true;
            pbDelete.Enabled = true;
            pbModify.Enabled = true;

            for (int i = 0; i < categorie.Length; i++)
            {
                categorie[i].Checked = false;
                categorie[i].Visible = true;
            }

            for (int i = 0; i < qlicat.Length; i++)
            {
                qlicat[i].Checked = false;
                qlicat[i].Visible = true;
            }
            for (int i = 0; i < textes.Length; i++)
            {
                textes[i].Visible = true;
            }
            for (int i = 0; i < dates.Length; i++)
            {
                dates[i].Visible = true;
            }
            for (int i = 0; i < combos.Length; i++)
            {
                combos[i].Visible = true;
            }

            DataBaseActions getDriverCat = new DataBaseActions();
            categorieDriverList = getDriverCat.GetDriverCategorie(categorieDriverList, Convert.ToInt32(control.lblID.Text));

            DataBaseActions getDriverQlicat = new DataBaseActions();
            qlicatDriverList = getDriverQlicat.GetDriverQLICAT(qlicatDriverList, Convert.ToInt32(control.lblID.Text));

            CategorieCheckBoxChecked(categorieDriverList);
            DatCheckBoxChecked(qlicatDriverList);

            var driverName = from x in driverList
                             where x.driverID == Convert.ToInt32(control.lblID.Text)
                             select x;

            if (qlicatDriverList.Count > 0)
            {
                cbQLICAT.SelectedIndex = 0;
            }

            foreach (var x in driverName)
            {
                txtFullName.Text = String.Concat(x.lastName, x.firstName);
                txtFirstName.Text = Convert.ToString(x.firstName);
                txtLastName.Text = Convert.ToString(x.lastName);
                dtpBirthDate.Value = x.birthDate;
                txtBirthCountry.Text = Convert.ToString(x.birthCountry);
                txtBirthPlace.Text = Convert.ToString(x.birthPlace);
                txtMothersName.Text = Convert.ToString(x.mothersName);
                txtDrivingLicenseNumber.Text = Convert.ToString(x.drivingLicenseNumber);
                dtpDrivingLicenseExpireDate.Value = x.drivingLicenseExpireDate;
                lblID.Text = Convert.ToString(x.driverID);
                lblUserID.Text = Convert.ToString(x.userID);
            }
        }

        public void DatCheckBoxChecked(List<QualificationLevelInCareerAptitudeTest> driversData)
        {
            for (int i = 0; i < qlicat.Length; i++)
            {
                var searchDat = from x in driversData
                                where x.qlicatName == qlicat[i].Text
                                select x;

                foreach (var x in searchDat)
                {
                    qlicat[i].Checked = true;
                }

            }
        }

        public void CategorieCheckBoxChecked(List<Actions.Categorie> driversData)
        {
            for (int i = 0; i < categorie.Length; i++)
            {
                var searchCat = from x in driversData
                                where x.categorieName == categorie[i].Text
                                select x;

                foreach (var x in searchCat)
                {
                    categorie[i].Checked = true;
                }

            }
        }

        private List<Actions.Categorie> CheckCategories()
        {
            categorieCheckList.Clear();

            for (int i = 0; i < categorie.Length; i++)
            {
                if (categorie[i].Checked == true)
                {

                    var categorieSearched = from x in categorieFullList
                                    where x.categorieName == categorie[i].Text
                                    select x;

                    foreach (var x in categorieSearched)
                    {
                        int catID = x.categorieID;
                        string catName = x.categorieName;

                        categorieCheckList.Add(new Actions.Categorie()
                        {
                            categorieID = catID,
                            categorieName = catName
                        });

                    }
                }
            }

            return categorieCheckList;
        }

        private List<QualificationLevelInCareerAptitudeTest> CheckDATs()
        {
            qlicatCheckList.Clear();

            for (int i = 0; i < qlicat.Length; i++)
            {
                if (qlicat[i].Checked == true)
                {

                    var dat = from x in qlicatFullList
                              where x.qlicatName == qlicat[i].Text
                              select x;

                    foreach (var x in dat)
                    {
                        int datID = x.qlicatID;
                        string datName = x.qlicatName;

                        qlicatCheckList.Add(new QualificationLevelInCareerAptitudeTest()
                        {
                            qlicatID = datID,
                            qlicatName = datName
                        });
                    }
                }
            }

            return qlicatCheckList;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            string connect = @"Data Source = " + Properties.Settings.Default.dataBaseFolder;

            int id;
            string modifyDriver;
            string modifyCatDriver;
            string modifyDatDriver;

            id = Convert.ToInt32(lblID.Text);
            modifyDriver = "UPDATE drivers SET " +
                "birthCountry = '" + txtBirthCountry.Text +
                "', birthPlace = '" + txtBirthPlace.Text +
                "', birthDate = '" + dtpBirthDate.Value +
                "', mothersName = '" + txtMothersName.Text +
                "', drivingLicenseNumber = '" + txtDrivingLicenseNumber.Text +
                "', drivingLicenseExpireDate = '" + dtpDrivingLicenseExpireDate.Value + "' " +
                "WHERE driverID = '" + id + "';";

            DataBaseActions updateDriver = new DataBaseActions();
            updateDriver.ModifyDataBase(modifyDriver);

            categorieCheckList = CheckCategories();
            qlicatCheckList = CheckDATs();

            int searchedCategorieID = -1;
            int searchedDatID = -1;

            for (int i = 0; i < categorieCheckList.Count; i++)
            {
                var catList = from x in categorieFullList
                              where x.categorieName == categorieCheckList[i].categorieName
                              select x;

                foreach (var x in catList)
                {
                    searchedCategorieID = x.categorieID;
                }

                if (!categorieDriverList.Exists(x => x.categorieName == categorieCheckList[i].categorieName))
                {
                    modifyCatDriver = "INSERT INTO catDrivers (driverID, categorieID) VALUES ('" + id + "', '" + searchedCategorieID + "')";
                    DataBaseActions updateCatDrivers = new DataBaseActions();
                    updateCatDrivers.ActionWithDataBase(modifyCatDriver);
                }
            }

            for (int i = 0; i < categorieDriverList.Count; i++)
            {
                var catList = from x in categorieFullList
                              where x.categorieName == categorieCheckList[i].categorieName
                              select x;

                foreach (var x in catList)
                {
                    searchedCategorieID = x.categorieID;
                }

                if (!categorieCheckList.Exists(x => x.categorieName == categorieDriverList[i].categorieName))
                {
                    modifyCatDriver = "DELETE FROM catDrivers WHERE driverID = '" + id + "' AND categorieID = '" + searchedCategorieID + "'";
                    DataBaseActions updateCatDrivers = new DataBaseActions();
                    updateCatDrivers.ActionWithDataBase(modifyCatDriver);
                }
            }



            for (int i = 0; i < qlicatCheckList.Count; i++)
            {
                var datList = from x in qlicatFullList
                              where x.qlicatName == qlicatCheckList[i].qlicatName
                              select x;

                foreach (var x in datList)
                {
                    searchedDatID = x.qlicatID;
                }

                if (!qlicatDriverList.Exists(x => x.qlicatName == qlicatCheckList[i].qlicatName))
                {
                    modifyDatDriver = "INSERT INTO datDrivers (driverID, datID) VALUES ('" + id + "', '" + searchedDatID + "')";
                    DataBaseActions updateDatDrivers = new DataBaseActions();
                    updateDatDrivers.ActionWithDataBase(modifyDatDriver);
                }
            }

            for (int i = 0; i < qlicatDriverList.Count; i++)
            {
                var datList = from x in qlicatFullList
                              where x.qlicatName == qlicatDriverList[i].qlicatName
                              select x;

                foreach (var x in datList)
                {
                    searchedDatID = x.qlicatID;
                }

                if (!qlicatCheckList.Exists(x => x.qlicatName == qlicatDriverList[i].qlicatName))
                {
                    modifyDatDriver = "DELETE FROM datDrivers WHERE driverID '" + id + " AND datID = '" + searchedDatID + "'";
                    DataBaseActions updateDatDrivers = new DataBaseActions();
                    updateDatDrivers.ActionWithDataBase(modifyDatDriver);
                }
            }

            FillPanel();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sqlDriver = "DELETE FROM drivers WHERE userID ='" + Convert.ToInt32(lblUserID.Text) + "';";
            string sqlQulicatDriver = "DELETE FROM datDrivers WHERE driverID ='" + Convert.ToInt32(lblID.Text) + "';";
            string sqlCatDriver = "DELETE FROM catDrivers WHERE driverID ='" + Convert.ToInt32(lblID.Text) + "';";
            string modifyUser = "UPDATE users SET " +
                "isItADriver = '" + false + "' " +
                "WHERE userID = '" + Convert.ToInt32(lblUserID.Text) + "';";

            DataBaseActions delete = new DataBaseActions();
            delete.DeleteFromDataBase(sqlDriver);
            DataBaseActions deleteWithoutMessage = new DataBaseActions();
            deleteWithoutMessage.ActionWithDataBase(sqlQulicatDriver);
            deleteWithoutMessage.ActionWithDataBase(sqlCatDriver);
            deleteWithoutMessage.ActionWithDataBase(modifyUser);

            FillPanel();
        }
    }
}
