using FuseNit.Actions;
using FuseNit.UserControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuseNit.Pages.DeliveryNotes
{
    public partial class DeliverySheet : Form
    {
        List<Actions.DeliveryNote> notes = new List<Actions.DeliveryNote>();
        List<Actions.Driver> drivers = new List<Actions.Driver>();
        List<Actions.Customer> customers = new List<Actions.Customer>();
        List<Actions.Vehicle> vehicles = new List<Actions.Vehicle>();
        List<Actions.Company> companys = new List<Actions.Company>();
        List<Actions.Project> projects = new List<Actions.Project>();
        List<Actions.Product> products = new List<Actions.Product>();
        int driverID;
        int vehicleID;
        int customerID;
        int companyID;
        int projectID;
        string productNote;

        public DeliverySheet(string noteID, List<Actions.DeliveryNote> noteList, List<Actions.Driver> driverList, List<Actions.Customer> customerList, List<Actions.Vehicle> vehicleList, List<Actions.Company> companyList, List<Actions.Project> projectList, List<Actions.Product> productList)
        {
            InitializeComponent();
            SetData(noteID, noteList, driverList, customerList, vehicleList, companyList, projectList, productList);
            FillPanel(productList, noteID);
        }

        void SetData(string noteID, List<Actions.DeliveryNote> noteList, List<Actions.Driver> driverList, List<Actions.Customer> customerList, List<Actions.Vehicle> vehicleList, List<Actions.Company> companyList, List<Actions.Project> projectList, List<Actions.Product> productList)
        {
            notes = noteList;
            drivers = driverList;
            customers = customerList;
            vehicles = vehicleList;
            companys = companyList;
            projects = projectList;
            products = productList;


            var searchedNote = from x in noteList
                               where x.deliveryNoteID == noteID
                               select x;

            foreach (var x in searchedNote)
            {
                driverID = x.driverID;
                vehicleID = x.vehicleID;
                customerID = x.customerID;
                companyID = x.companyID;
                projectID = x.projectID;
                productNote = x.deliveryNoteID;

                txtDepartureCountry.Text = x.departureCountry;
                txtDepartureCity.Text = x.deparutureCity;
                txtDepartureAddress.Text = String.Concat(x.departureStreet, ", ", x.departureNumber, ". ", x.departureBuilding, " épület ", x.departureFloor, " emelet, ", x.departureDoor, ".");
                txtDepartureZIP.Text = x.departureZIP;
                txtDepartureTime.Text = Convert.ToString(x.dateFrom);

                txtDestinationCountry.Text = x.destinationCountry;
                txtDestinationCity.Text = x.destinationCity;
                txtDestinationAddress.Text = String.Concat(x.destinationStreet, ", ", x.destinationNumber, ". ", x.destinationBuilding, " épület ", x.destinationFloor, " emelet, ", x.destinationDoor, ".");
                txtDestinationZIP.Text = x.destinationZIP;
                txtDeliveryTime.Text = x.dateTo.ToString();
                txtDeliveryNumber.Text = x.deliveryNoteID;
            }

            var searchedDriver = from a in driverList
                                 where a.driverID == driverID
                                 select a;

            foreach (var a in searchedDriver)
            {
                txtDriver.Text = a.fullName;
            }

            var searchedProject = from b in projectList
                                  where b.projectID == projectID
                                  select b;

            foreach (var c in searchedProject)
            {
                txtProject.Text = String.Concat(c.projectName, " - ", c.projectNumber);
            }

            var searchedCustomer = from d in customerList
                                   where d.customerID == customerID
                                   select d;

            foreach (var d in searchedCustomer)
            {
                txtCustomerName.Text = d.customerName;
                txtCustomerAddress.Text = String.Concat(d.customerMailCountry, ", ", d.customerMailCity, ", ", d.customerMailStreet, " ", d.customerMailPlace, " ", d.customerMailNumber, ". ", d.customerMailBuilding, " épület ", d.customerMailFloor, " emelet, ", d.customerMailDoor, ".");
                txtCustomerVAT.Text = d.customerVAT;
            }

            var searchedVehicle = from e in vehicleList
                                  where e.vehicleID == vehicleID
                                  select e;

            foreach (var e in searchedVehicle)
            {
                txtVehicle.Text = String.Concat(e.make, " - ", e.model, ", ", e.registrationMark);
            }

            var searchedCompany = from f in companyList
                                  where f.companyID == companyID
                                  select f;

            foreach (var f in searchedCompany)
            {
                txtDeliveryAddress.Text = String.Concat(f.companyMailCountry, ", ", f.companyMailCity, ", ", f.companyMailStreet, " ", f.companyMailPlace, " ", f.companyMailNumber, ". ", f.companyMailBuilding, " épület ", f.companyMailFloor, " emelet, ", f.companyMailDoor, ".");
                txtDeliveryName.Text = f.companyName;
                txtDeliveryVAT.Text = f.companyVATNumber;
            }

        }

        void FillPanel(List<Actions.Product> product, string noteID)
        {
            products.Clear();
            flpProduct.Controls.Clear();

            DataBaseActions notes = new DataBaseActions();

            foreach (Actions.Product item in notes.GetTheProduct(products, noteID))
            {
                ucProductsNote productControl = new ucProductsNote(item);
                flpProduct.Controls.Add(productControl);
            }

            double sumWeight = 0;

            foreach (var x in products)
            {
                sumWeight = sumWeight + x.weight;
            }

            txtSumWeight.Text = sumWeight.ToString() + " kg";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            btnPrint.Visible = false;
            txtPrintTime.Text = DateTime.Now.ToString();

            string note = txtDeliveryNumber.Text;

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = ".pdf";
            PdfPTable pdfForm = new PdfPTable(panel3.Width);
            if (saveFile.ShowDialog()==DialogResult.OK)
            {
                using (FileStream stream = new FileStream(saveFile.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(pdfForm);
                    pdfDoc.Close();
                    stream.Close();
                }
            }
        }
    }
}
