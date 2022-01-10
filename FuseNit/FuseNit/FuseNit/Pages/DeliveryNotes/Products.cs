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

namespace FuseNit.Pages.DeliveryNotes
{
    public partial class Products : Form
    {
        TextBox[] textes;
        Button[] buttons;
        List<Actions.Product> productList = new List<Actions.Product>();
        string noteNumber;
        string isItActive;

        public Products(string deliveryNoteNumber, string active, List<Actions.Product> productList)
        {
            InitializeComponent();
            SetData(deliveryNoteNumber, active);
            FillPanel();
        }

        void SetData(string deliveryNoteNumber, string active)
        {
            textes = new[] { txtName, txtQuantity, txtUnit, txtWeight };
            buttons = new[] { btnDelete, btnModify};
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Enabled = false;
            }
            for (int i = 0; i < textes.Length; i++)
            {
                textes[i].Visible = false;
            }

            isItActive = active;
            noteNumber = deliveryNoteNumber;

            txtDeliverySheetNumber.Text = deliveryNoteNumber;
        }

        void FillPanel()
        {
            productList.Clear();
            flpProduct.Controls.Clear();

            DataBaseActions notes = new DataBaseActions();

            foreach (Actions.Product item in notes.GetTheProduct(productList, noteNumber))
            {
                ucProducts productControl = new ucProducts(item);
                productControl.Click += new EventHandler(this.ucProduct_Click);
                productControl.AddButtonClick += (sender, args) => this.ucProduct_Click(productControl, args);
                flpProduct.Controls.Add(productControl);
            }

            double sumWeight = 0;

            foreach (var x in productList)
            {
                sumWeight = sumWeight + x.weight;
            }

            lblSumWeight.Text = "Összsúly: " + sumWeight.ToString() + " kg";
        }

        void ucProduct_Click(object sender, EventArgs e)
        {
            ucProducts control = (ucProducts)sender;

            if (isItActive == "True")
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Enabled = true;
                }
            }
            else
            {
                btnAdd.Enabled = false;
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Enabled = false;
                }
            }

            lblSumWeight.Visible = true;

            for (int i = 0; i < textes.Length; i++)
            {
                textes[i].Visible = true;
            }

            var productsOnNote = from x in productList
                                 where x.productID == Convert.ToInt32(control.lblID.Text)
                                 select x;

            foreach (var x in productsOnNote)
            {
                txtName.Text = Convert.ToString(x.name);
                txtQuantity.Text = Convert.ToString(x.quantity);
                txtUnit.Text = Convert.ToString(x.unit);
                txtWeight.Text = Convert.ToString(x.weight);
                lblID.Text = Convert.ToString(x.productID);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string delProduct = "DELETE FROM product WHERE productID ='" + Convert.ToInt32(lblID.Text) + "';";

            DataBaseActions delete = new DataBaseActions();
            delete.DeleteFromDataBase(delProduct);

            FillPanel();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string addProduct = "INSERT INTO product (productName, productDeliveryNote, productQuantity, productUnit, productWeight) VALUES (' ', '" + txtDeliverySheetNumber.Text + "', '" + Convert.ToInt32(0) + "', ' ', '" + Convert.ToInt32(0) + "')";

            DataBaseActions add = new DataBaseActions();
            add.ActionWithDataBase(addProduct);

            FillPanel();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            string sqlModProduct = "UPDATE product SET " +
                    "productName = '" + txtName.Text +
                    "', productDeliveryNote = '" + txtDeliverySheetNumber.Text +
                    "', productQuantity = '" + Convert.ToDouble(txtQuantity.Text) +
                    "', productUnit = '" + txtUnit.Text +
                    "', productWeight = '" + Convert.ToDouble(txtWeight.Text) + "' " +
                    "WHERE  productID = '" + Convert.ToInt32(lblID.Text) + "';";

            DataBaseActions modify = new DataBaseActions();
            modify.ModifyDataBase(sqlModProduct);


            FillPanel();
        }
    }
}
