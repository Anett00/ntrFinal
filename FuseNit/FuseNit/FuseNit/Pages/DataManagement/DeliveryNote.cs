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
    public partial class DeliveryNote : Form
    {
        List<Actions.DeliveryNote> noteList = new List<Actions.DeliveryNote>();
        List<Actions.Driver> driverList = new List<Actions.Driver>();
        List<Actions.Customer> customerList = new List<Actions.Customer>();
        List<Actions.Vehicle> vehicleList = new List<Actions.Vehicle>();
        List<Actions.Company> companyList = new List<Actions.Company>();
        List<Actions.Project> projectList = new List<Actions.Project>();
        List<Actions.Product> productList = new List<Actions.Product>();
        public double vehicleWeight = 0;
        public double cylinderCapacity = 0;
        public double sumWeight = 0;
        int vehicleID = 0;
        ComboBox[] combos;
        TextBox[] textes;
        DateTimePicker[] dates;
        Button[] buttons;

        public DeliveryNote()
        {
            InitializeComponent();
            SetData();
            FillPanel();
        }

        void SetData()
        {
            DataBaseActions note = new DataBaseActions();
            noteList = note.GetAllSheet(noteList);

            DataBaseActions driver = new DataBaseActions();
            driverList = driver.GetAllDriver(driverList);

            DataBaseActions customer = new DataBaseActions();
            customerList = customer.GetAllCustomer(customerList);

            DataBaseActions vehicle = new DataBaseActions();
            vehicleList = vehicle.GetAllVehicle(vehicleList);

            DataBaseActions company = new DataBaseActions();
            companyList = company.GetAllCompany(companyList);

            DataBaseActions project = new DataBaseActions();
            projectList = project.GetAllProject(projectList);

            combos = new[] { cbDriver, cbVehicle, cbProject, cbSelfCompany, cbCustomer, cbFromPlace, cbToPlace };
            textes = new[] { txtDeliverySheetNumber, txtFromBuilding, txtFromCity, txtFromCountry, txtFromDoor, txtFromFloor, txtFromNumber, txtFromStreet, txtFromZIP, txtToBuilding, txtToCity, txtToCountry, txtToDoor, txtToFloor, txtToNumber, txtToStreet, txtToZIP, txtVehicleTotalWeight };
            dates = new[] { dtpFrom, dtpTil };
            buttons = new[] { btnDelete, btnModify, btnProduts, borderedPanel5 };

            for (int i = 0; i < combos.Length; i++)
            {
                combos[i].Visible = false;
            }
            for (int i = 0; i < textes.Length; i++)
            {
                textes[i].Visible = false;
            }
            for (int i = 0; i < dates.Length; i++)
            {
                dates[i].Visible = false;
            }
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Enabled = false;
            }

            foreach (var item in driverList)
            {
                cbDriver.Items.Add(item.fullName);
            }
            foreach (var item in vehicleList)
            {
                cbVehicle.Items.Add(string.Concat(item.make, ", ", item.model, ", ", item.registrationMark));
            }
            foreach (var item in customerList)
            {
                cbCustomer.Items.Add(item.customerName);
            }
            foreach (var item in projectList)
            {
                cbProject.Items.Add(string.Concat(item.projectName, " - ", item.projectNumber));
            }
            foreach (var item in companyList)
            {
                cbSelfCompany.Items.Add(item.companyName);
            }
        }

        void FillPanel()
        {
            noteList.Clear();
            flpDeliveryNote.Controls.Clear();

            DataBaseActions notes = new DataBaseActions();

            foreach (Actions.DeliveryNote noteList in notes.GetAllSheet(noteList))
            {
                var driver = driverList.Where(x => x.driverID == noteList.driverID);
                string fullName = "";
                foreach (var item in driver)
                {
                    fullName = item.fullName;
                }

                ucNote userControl = new ucNote(noteList, fullName);
                userControl.Click += new EventHandler(this.ucNote_Click);
                userControl.AddButtonClick += (sender, args) => this.ucNote_Click(userControl, args);
                flpDeliveryNote.Controls.Add(userControl);
            }
        }

        void ucNote_Click(object sender, EventArgs e)
        {
            ucNote control = (ucNote)sender;
            pDeparture.Visible = true;
            pDestination.Visible = true;

            if (control.lblActive.Text == "True")
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Enabled = true;
                }
            }

            borderedPanel5.Enabled = true;

            for (int i = 0; i < combos.Length; i++)
            {
                combos[i].Visible = true;
            }
            for (int i = 0; i < textes.Length; i++)
            {
                textes[i].Visible = true;
            }
            for (int i = 0; i < dates.Length; i++)
            {
                dates[i].Visible = true;
            }

            var note = noteList.Where(x => x.noteID == Convert.ToInt32(control.lblDeliveryNote.Text));

            foreach (var x in note)
            {
                int searchedDriverID = x.driverID;
                int searchedCompanyID = x.companyID;
                int searchedCustomerID = x.customerID;
                int searchedVehicleID = x.vehicleID;
                vehicleID = x.vehicleID;
                int searchedProject = x.projectID;
                int fromPlaceIndex = cbFromPlace.FindString(x.departurePlace);
                int toPlaceIndex = cbToPlace.FindString(x.destinationPlace);
                int driverName = -1;
                int selfCompanyName = -1;
                int customerName = -1;
                int vehicleRegistrationNumber = -1;
                int projectNumber = -1;

                var driver = from a in driverList
                             where a.driverID == searchedDriverID
                             select a;

                foreach (var a in driver)
                {
                    driverName = cbDriver.FindString(a.fullName);
                }

                var company = from a in companyList
                              where a.companyID == searchedCompanyID
                              select a;

                foreach (var a in company)
                {
                    selfCompanyName = cbSelfCompany.FindString(a.companyName);
                }

                var customer = from a in customerList
                               where a.customerID == searchedCustomerID
                               select a;

                foreach (var a in customer)
                {
                    customerName = cbCustomer.FindString(a.customerName);
                }

                var vehicle = from a in vehicleList
                              where a.vehicleID == searchedVehicleID
                              select a;

                foreach (var a in vehicle)
                {
                    string cbText = string.Concat(a.make, ", ", a.model, ", ", a.registrationMark);
                    vehicleRegistrationNumber = cbVehicle.FindString(cbText);
                }

                var project = from a in projectList
                              where a.projectID == searchedProject
                              select a;

                foreach (var a in project)
                {
                    string cbText = string.Concat(a.projectName, " - ", a.projectNumber);
                    projectNumber = cbProject.FindString(cbText);
                }

                lblNoteID.Text = x.noteID.ToString();
                txtDeliverySheetNumber.Text = x.deliveryNoteID.ToString();
                txtFromCountry.Text = x.departureCountry.ToString();
                txtFromCity.Text = x.deparutureCity.ToString();
                txtFromStreet.Text = x.departureStreet.ToString();
                txtFromNumber.Text = x.departureNumber.ToString();
                txtFromBuilding.Text = x.departureBuilding.ToString();
                txtFromFloor.Text = x.departureFloor.ToString();
                txtFromDoor.Text = x.departureDoor.ToString();
                txtFromZIP.Text = x.departureZIP.ToString();
                txtToCountry.Text = x.destinationCountry.ToString();
                txtToCity.Text = x.destinationCity.ToString();
                txtToStreet.Text = x.destinationStreet.ToString();
                txtToNumber.Text = x.destinationNumber.ToString();
                txtToBuilding.Text = x.destinationBuilding.ToString();
                txtToFloor.Text = x.destinationFloor.ToString();
                txtToDoor.Text = x.destinationDoor.ToString();
                txtToZIP.Text = x.destinationZIP.ToString();
                dtpFrom.Value = x.dateFrom;
                dtpTil.Value = x.dateTo;
                lblActive.Text = x.isItActive.ToString();
                cbProject.SelectedIndex = projectNumber;
                cbVehicle.SelectedIndex = vehicleRegistrationNumber;
                cbCustomer.SelectedIndex = customerName;
                cbSelfCompany.SelectedIndex = selfCompanyName;
                cbDriver.SelectedIndex = driverName;
                cbFromPlace.SelectedIndex = fromPlaceIndex;
                cbToPlace.SelectedIndex = toPlaceIndex;

                DataBaseActions productToList = new DataBaseActions();
                productToList.GetTheProduct(productList, x.deliveryNoteID);

                var product = productList.Where(y => y.deliveryNoteID == (lblNoteID.Text)).ToList();

                foreach (var item in product)
                {
                    sumWeight = sumWeight + item.weight;
                }

                var searchedVehicle = vehicleList.Where(z => z.vehicleID == x.vehicleID);
                foreach (var item in searchedVehicle)
                {
                    vehicleWeight = item.selfWeight;
                    cylinderCapacity = item.cilynderCapacity;
                }

                txtVehicleTotalWeight.Text = sumWeight.ToString("0,00 kg");

                if (cylinderCapacity < (sumWeight + vehicleWeight))
                {
                    MessageBox.Show("A kiválasztott jármű összteherbírása alacsony, válassz másikat!");
                }
            }
        }

        private void btnProduts_Click(object sender, EventArgs e)
        {
            DataBaseActions productToList = new DataBaseActions();
            productList = productToList.GetTheProduct(productList, txtDeliverySheetNumber.Text);
            Pages.DeliveryNotes.Products product = new Pages.DeliveryNotes.Products(txtDeliverySheetNumber.Text, lblActive.Text, productList);
            product.ShowDialog();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            int projectID = -1;
            int vehicleID = -1;
            int driverID = -1;
            int companyID = -1;
            int customerID = -1;

            string[] cbProjectSearched = cbProject.Text.Split('-');
            string projectSearchedNumber = cbProjectSearched[1].TrimStart(' ');

            var project = from x in projectList
                          where x.projectNumber == projectSearchedNumber
                          select x;

            foreach (var x in project)
            {
                projectID = x.projectID;
            }

            string[] cbVehicleSearched = cbVehicle.Text.Split(',');
            string regNumb = cbVehicleSearched[2].TrimStart(' ');

            var vehicle = from x in vehicleList
                          where x.registrationMark == regNumb
                          select x;

            foreach (var x in vehicle)
            {
                vehicleID = x.vehicleID;
            }

            var driver = from x in driverList
                         where x.fullName == cbDriver.Text
                         select x;

            foreach (var x in driver)
            {
                driverID = x.driverID;
            }

            var company = from x in companyList
                          where x.companyName == cbSelfCompany.Text
                          select x;

            foreach (var x in company)
            {
                companyID = x.companyID;
            }

            string[] cbCustomerSearched = cbCustomer.Text.Split('-');
            string customerSearchedName = cbCustomerSearched[0].TrimEnd(' ');

            var customer = from x in customerList
                           where x.customerName == customerSearchedName
                           select x;

            foreach (var x in customer)
            {
                customerID = x.customerID;
            }

            string modifyNote = "UPDATE deliveryNote SET " +
                    "projectID = '" + projectID +
                    "', vehicleID = '" + vehicleID +
                    "', driverID = '" + driverID +
                    "', companyID = '" + companyID +
                    "', customerID = '" + customerID +
                    "', departureCountry = '" + txtFromCountry.Text +
                    "', departureCity = '" + txtFromCity.Text +
                    "', departureStreet = '" + txtFromStreet.Text +
                    "', departurePlace = '" + cbFromPlace.Text +
                    "', departureNumber = '" + txtFromNumber.Text +
                    "', departureBuilding = '" + txtFromBuilding.Text +
                    "', departureFloor = '" + txtFromFloor.Text +
                    "', departureDoor = '" + txtFromDoor.Text +
                    "', departureZIP = '" + txtFromZIP.Text +
                    "', destinationCountry = '" + txtToCountry.Text +
                    "', destinationCity = '" + txtToCity.Text +
                    "', destinationStreet = '" + txtToStreet.Text +
                    "', destinationPlace = '" + cbToPlace.Text +
                    "', destinationNumber = '" + txtToNumber.Text +
                    "', destinationBuilding = '" + txtToBuilding.Text +
                    "', destinationFloor = '" + txtToFloor.Text +
                    "', destinationDoor = '" + txtToDoor.Text +
                    "', destinationZIP = '" + txtToZIP.Text +
                    "', dateFrom = '" + dtpFrom.Value +
                    "', dateTo = '" + dtpTil.Value +
                    "', vehicleTotalWeight = '" + vehicleWeight + "' " +
                    "WHERE  noteID = '" + Convert.ToInt32(lblNoteID.Text) + "';";

            DataBaseActions modify = new DataBaseActions();
            modify.ModifyDataBase(modifyNote);

            FillPanel();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int year = Convert.ToInt32(DateTime.Now.Year);
            int month = Convert.ToInt32(DateTime.Now.Month);
            int id = noteList.Count + 1;
            string idFormatted = id.ToString("000000");
            string deliveryNoteID = string.Concat("SZ", "/", year, "/", month, "/", idFormatted);
            string addSheet = "INSERT INTO deliveryNote (projectID, vehicleID, driverID, companyID, customerID, departureCountry, departureCity, departureStreet, departurePlace, departureNumber, departureBuilding, departureFloor, departureDoor, departureZIP, destinationCountry, destinationCity, destinationStreet, destinationPlace, destinationNumber, destinationBuilding, destinationFloor, destinationDoor, destinationZIP, vehicleTotalWeight, isItActive, deliveryNoteID, dateFrom, dateTo) VALUES ( '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '" + Convert.ToDouble(0) + "', 'True', '" + deliveryNoteID + "', '" + DateTime.Now + "', '" + DateTime.Now + "')";

            DataBaseActions newNote = new DataBaseActions();
            newNote.ActionWithDataBase(addSheet);

            FillPanel();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string delNote = "DELETE FROM deliveryNote WHERE noteID ='" + Convert.ToInt32(lblNoteID.Text) + "';";
            string delFromProducts = "DELETE FROM product WHERE productDeliveryNote ='" + Convert.ToInt32(lblNoteID.Text) + "';";

            DataBaseActions delete = new DataBaseActions();
            try
            {
                delete.DeleteFromDataBase(delNote);
                delete.ActionWithDataBase(delFromProducts);
            }
            finally { }

            FillPanel();
        }

        private void borderedPanel5_Click(object sender, EventArgs e)
        {
            if (lblActive.Text == "True" || lblActive.Text == "true")
            {
                string message = "Ha kinyomtatod, utána a szállítólevelet már nem módosíthatod. \n Biztos véglegesíted?";
                string title = "Szállítólevél nyomtatása";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    string lockNote = "UPDATE deliveryNote SET " +
                        "isItActive = 'False'" +
                        "WHERE noteID = '" + Convert.ToInt32(lblNoteID.Text) + "';"
                        ;
                    DataBaseActions lockDeliveryNote = new DataBaseActions();
                    lockDeliveryNote.ActionWithDataBase(lockNote);

                    DeliveryNotes.DeliverySheet note = new DeliveryNotes.DeliverySheet(txtDeliverySheetNumber.Text, noteList, driverList, customerList, vehicleList, companyList, projectList, productList);
                    note.ShowDialog();
                }
            }
            else
            {
                DeliveryNotes.DeliverySheet note = new DeliveryNotes.DeliverySheet(txtDeliverySheetNumber.Text, noteList, driverList, customerList, vehicleList, companyList, projectList, productList);
                note.ShowDialog();
            }
        }
    }
}
