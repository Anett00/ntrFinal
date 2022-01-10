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
    public partial class ucCustomer : UserControl
    {
        public event EventHandler AddButtonClick
        {
            add
            {
                borderedPanel1.Click += value;
            }
            remove
            {
                borderedPanel1.Click -= value;
            }
        }

        public ucCustomer(Actions.Company company)
        {
            InitializeComponent();
            borderedPanel1.Text = company.companyName;
            lblID.Text = company.companyID.ToString();
        }

        public ucCustomer(Actions.Customer company)
        {
            InitializeComponent();
            borderedPanel1.Text = company.customerName;
            lblID.Text = company.customerID.ToString();
        }
    }
}
