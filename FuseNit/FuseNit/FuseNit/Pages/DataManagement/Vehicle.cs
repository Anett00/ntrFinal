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
    public partial class Vehicle : Form
    {

        List<Actions.Vehicle> vehicleList = new List<Actions.Vehicle>();
        List<Actions.Categorie> categorieList = new List<Categorie>();
        TextBox[] textes;
        ComboBox[] combo;
        DateTimePicker[] dates;

        public Vehicle()
        {
            InitializeComponent();
            SetData();
            FillPanel();
        }

        private void SetData()
        {
            btnModify.Enabled = false;
            btnDelete.Enabled = false;

            DataBaseActions getCategorie = new DataBaseActions();

            categorieList = getCategorie.GetAllCategorie(categorieList);

            foreach (var item in categorieList)
            {
                cbCategorie.Items.Add(item.categorieName);
            }

            textes = new[] { txtRegNumber, txtCylinderWeight, txtMake, txtMod, txtModel, txtRegistrationNumber, txtRegistrationMark, txtYear, txtLoadability, txtSelfWeight };
            combo = new[] { cbCategorie };
            dates = new[] { dtpFirstRegistration, dtpRoadWorthinessExpireDate };
        }

        private void FillPanel()
        {
            vehicleList.Clear();
            flpVehicle.Controls.Clear();

            DataBaseActions getVehicle = new DataBaseActions();

            foreach (var item in getVehicle.GetAllVehicle(vehicleList))
            {
                ucVehicle vehicleControl = new ucVehicle(item);
                vehicleControl.Click += new EventHandler(this.ucVehicle_Click);
                vehicleControl.AddButtonClick += (sender, args) => this.ucVehicle_Click(vehicleControl, args);
                flpVehicle.Controls.Add(vehicleControl);
            }
        }

        void ucVehicle_Click(object sender, EventArgs e)
        {
            btnModify.Enabled = true;
            btnDelete.Enabled = true;

            for (int i = 0; i < textes.Length; i++)
            {
                textes[i].Visible = true;
            }
            for (int i = 0; i < combo.Length; i++)
            {
                combo[i].Visible = true;
            }
            for (int i = 0; i < dates.Length; i++)
            {
                dates[i].Visible = true;
            }

            ucVehicle control = (ucVehicle)sender;
            int vehicleID = Convert.ToInt32(control.lblID.Text);
            var vehicle = from x in vehicleList
                          where x.vehicleID == vehicleID
                          select x;

            foreach (var x in vehicle)
            {
                txtRegNumber.Text = Convert.ToString(x.registrationNumber);
                txtCylinderWeight.Text = Convert.ToString(x.cilynderCapacity);
                txtRegistrationNumber.Text = Convert.ToString(x.registrationNumber);
                txtMake.Text = Convert.ToString(x.make);
                txtModel.Text = String.Concat(x.make, " ,", x.model);
                txtMod.Text = Convert.ToString(x.model);
                txtRegistrationMark.Text = Convert.ToString(x.registrationMark);
                txtYear.Text = Convert.ToString(x.year);
                txtLoadability.Text = Convert.ToString(x.loadability);
                txtID.Text = Convert.ToString(x.vehicleID);
                txtSelfWeight.Text = Convert.ToString(x.selfWeight);
                dtpFirstRegistration.Value = x.dateOfFirstRegistration;
                dtpRoadWorthinessExpireDate.Value = x.vehicleRoadworthinessTestExpireDate;
                cbCategorie.SelectedIndex = Convert.ToInt32(x.vehicleCategory);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE vehicles SET " +
                "make ='" + txtMake.Text + "', " +
                "model ='" + txtMod.Text +"', " +
                "registrationNumber ='" + txtRegNumber.Text +"', " +
                "year ='" + Convert.ToInt32(txtYear.Text) +"', " +
                "dateOfFirstRegistration ='" + dtpFirstRegistration.Value +"', " +
                "vehicleCategorie ='" + cbCategorie.SelectedIndex +"', " +
                "registrationMark ='" + txtRegistrationMark.Text +"', " +
                "cilynderCapacity ='" + Convert.ToDouble(txtCylinderWeight.Text) +"', " +
                "vehicleRoadWorthinessTestExpireDate ='" + dtpRoadWorthinessExpireDate.Value +"', " +
                "selfWeight ='" + Convert.ToDouble(txtSelfWeight.Text) +"' " +
                "WHERE vehicleID = '" + Convert.ToInt32(txtID.Text) + "'"
                ;

            DataBaseActions modify = new DataBaseActions();
            modify.ModifyDataBase(sql);

            FillPanel();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string add = "INSERT INTO vehicles (make, model, registrationNumber, year, dateOfFirstRegistration, vehicleCategorie, registrationMark, selfWeight, cilynderCapacity, vehicleRoadWorthinessTestExpireDate) VALUES ('Új', 'jármű', 'ABC123', '" + DateTime.Now.Year + "', '" + DateTime.Now + "', '-1', '', '0', '0', '" + DateTime.Now + "')";

            DataBaseActions addVehicle = new DataBaseActions();
            addVehicle.ActionWithDataBase(add);

            FillPanel();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM vehicles WHERE vehicleID = '" + Convert.ToInt32(txtID.Text) + "'";
            DataBaseActions delete = new DataBaseActions();
            delete.DeleteFromDataBase(sql);

            FillPanel();
        }
    }
}
