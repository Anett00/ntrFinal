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
    public partial class ucDriver : UserControl
    {
        String[] driverData;

        public ucDriver(Actions.Driver driver)
        {
            InitializeComponent();
            driverData = new[] { driver.driverID.ToString(), driver.fullName };
            lblID.Text = driverData[0];
            bpName.Text = driverData[1];
        }

        public event EventHandler AddButtonClick
        {
            add
            {
                bpName.Click += value;
            }
            remove
            {
                bpName.Click -= value;
            }
        }

        private void bpName_MouseHover(object sender, EventArgs e)
        {
            bpName.BackgroundColor = Color.FromArgb(60, 0, 0);
            bpName.BorderColor = Color.FromArgb(60, 0, 0);
        }

        private void bpName_MouseLeave(object sender, EventArgs e)
        {
            bpName.BackgroundColor = Color.FromArgb(38, 38, 38);
            bpName.BorderColor = Color.FromArgb(38, 38, 38);
        }
    }
}
