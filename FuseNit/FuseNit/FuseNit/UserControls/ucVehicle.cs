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
    public partial class ucVehicle : UserControl
    {
        public ucVehicle(Actions.Vehicle vehicle)
        {
            InitializeComponent();
            SetData(vehicle);
        }

        private void SetData(Actions.Vehicle vehicle)
        {
            lblID.Text = vehicle.vehicleID.ToString();
            lblModel.Text = vehicle.model;
            lblRegistrationNumber.Text = vehicle.registrationNumber;
        }

        public event EventHandler AddButtonClick
        {
            add
            {
                lblModel.Click += value;
                lblRegistrationNumber.Click += value;
                borderedPanel1.Click += value;
            }
            remove
            {
                lblModel.Click -= value;
                lblRegistrationNumber.Click -= value;
                borderedPanel1.Click -= value;
            }
        }

        private void lblModel_MouseHover(object sender, EventArgs e)
        {
            borderedPanel1.BackgroundColor = Color.FromArgb(60, 0, 0);
            borderedPanel1.BorderColor = Color.FromArgb(60, 0, 0);
            lblModel.BackColor = Color.FromArgb(60, 0, 0);
            lblRegistrationNumber.BackColor = Color.FromArgb(60, 0, 0);
        }
        private void lblRegistrationNumber_MouseHover(object sender, EventArgs e)
        {
            borderedPanel1.BackgroundColor = Color.FromArgb(60, 0, 0);
            borderedPanel1.BorderColor = Color.FromArgb(60, 0, 0);
            lblModel.BackColor = Color.FromArgb(60, 0, 0);
            lblRegistrationNumber.BackColor = Color.FromArgb(60, 0, 0);
        }
        private void borderedPanel1_MouseHover(object sender, EventArgs e)
        {
            borderedPanel1.BackgroundColor = Color.FromArgb(60, 0, 0);
            borderedPanel1.BorderColor = Color.FromArgb(60, 0, 0);
            lblModel.BackColor = Color.FromArgb(60, 0, 0);
            lblRegistrationNumber.BackColor = Color.FromArgb(60, 0, 0);
        }

        private void lblModel_MouseLeave(object sender, EventArgs e)
        {
            borderedPanel1.BackgroundColor = Color.FromArgb(38, 38, 38);
            borderedPanel1.BorderColor = Color.FromArgb(38, 38, 38);
            lblModel.BackColor = Color.FromArgb(38, 38, 38);
            lblRegistrationNumber.BackColor = Color.FromArgb(38, 38, 38);
        }
        private void lblRegistrationNumber_MouseLeave(object sender, EventArgs e)
        {
            borderedPanel1.BackgroundColor = Color.FromArgb(38, 38, 38);
            borderedPanel1.BorderColor = Color.FromArgb(38, 38, 38);
            lblModel.BackColor = Color.FromArgb(38, 38, 38);
            lblRegistrationNumber.BackColor = Color.FromArgb(38, 38, 38);
        }
        private void borderedPanel1_MouseLeave(object sender, EventArgs e)
        {
            borderedPanel1.BackgroundColor = Color.FromArgb(38, 38, 38);
            borderedPanel1.BorderColor = Color.FromArgb(38, 38, 38);
            lblModel.BackColor = Color.FromArgb(38, 38, 38);
            lblRegistrationNumber.BackColor = Color.FromArgb(38, 38, 38);
        }
    }
}
