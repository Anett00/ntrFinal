using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuseNit.UserControls
{
    public partial class ucProductsNote : UserControl
    {
        public event EventHandler AddButtonClick
        {
            add
            {
                txtName.Click += value;
                txtQuantity.Click += value;
                txtUnit.Click += value;
                txtWeight.Click += value;
                borderedPanel1.Click += value;
            }
            remove
            {
                txtName.Click -= value;
                txtQuantity.Click -= value;
                txtUnit.Click -= value;
                txtWeight.Click -= value;
                borderedPanel1.Click -= value;
            }
        }

        public ucProductsNote(Actions.Product product)
        {
            InitializeComponent();
            SetData(product);
        }

        void SetData(Actions.Product product)
        {
            txtName.Text = product.name;
            txtQuantity.Text = Convert.ToString(product.quantity);
            txtUnit.Text = product.unit;
            txtWeight.Text = Convert.ToString(product.weight);
        }
    }
}
