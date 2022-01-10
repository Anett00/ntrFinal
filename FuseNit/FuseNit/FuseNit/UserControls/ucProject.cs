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
    public partial class ucProject : UserControl
    {
        public ucProject(Actions.Project project)
        {
            InitializeComponent();
            SetData(project);
        }

        void SetData(Actions.Project project)
        {
            lblName.Text = project.projectName;
            lblAdress.Text = string.Concat(project.projectPlaceStreet, " ", project.projectPlaceNumber, ".");
            lblCity.Text = project.projectPlaceCity;
            lblProjectNumber.Text = project.projectNumber;
            lblID.Text = project.projectID.ToString();
        }

        public event EventHandler AddButtonClick
        {
            add
            {
                lblName.Click += value;
                lblAdress.Click += value;
                lblCity.Click += value;
                lblProjectNumber.Click += value;
                borderedPanel1.Click += value;
            }
            remove
            {
                lblName.Click -= value;
                lblAdress.Click -= value;
                lblCity.Click -= value;
                lblProjectNumber.Click -= value;
                borderedPanel1.Click -= value;
            }
        }

        public void MouseLabelHover()
        {
            borderedPanel1.BackgroundColor = Color.FromArgb(60, 0, 0);
            borderedPanel1.BorderColor = Color.FromArgb(60, 0, 0);
            lblName.BackColor = Color.FromArgb(60, 0, 0);
            lblAdress.BackColor = Color.FromArgb(60, 0, 0);
            lblCity.BackColor = Color.FromArgb(60, 0, 0);
            lblProjectNumber.BackColor = Color.FromArgb(60, 0, 0);
        }

        public void MouseLabelLeave()
        {
            borderedPanel1.BackgroundColor = Color.FromArgb(38, 38, 38);
            borderedPanel1.BorderColor = Color.FromArgb(38, 38, 38);
            lblName.BackColor = Color.FromArgb(38, 38, 38);
            lblAdress.BackColor = Color.FromArgb(38, 38, 38);
            lblCity.BackColor = Color.FromArgb(38, 38, 38);
            lblProjectNumber.BackColor = Color.FromArgb(38, 38, 38);
        }

        private void borderedPanel1_MouseHover(object sender, EventArgs e)
        {
            MouseLabelHover();
        }

        private void lblProjectNumber_MouseHover(object sender, EventArgs e)
        {
            MouseLabelHover();
        }

        private void lblName_MouseHover(object sender, EventArgs e)
        {
            MouseLabelHover();
        }

        private void lblCity_MouseHover(object sender, EventArgs e)
        {
            MouseLabelHover();
        }

        private void lblAdress_MouseHover(object sender, EventArgs e)
        {
            MouseLabelHover();
        }

        private void borderedPanel1_MouseLeave(object sender, EventArgs e)
        {
            MouseLabelLeave();
        }

        private void lblProjectNumber_Leave(object sender, EventArgs e)
        {
            MouseLabelLeave();
        }

        private void lblName_MouseLeave(object sender, EventArgs e)
        {
            MouseLabelLeave();
        }

        private void lblCity_MouseLeave(object sender, EventArgs e)
        {
            MouseLabelLeave();
        }

        private void lblAdress_MouseLeave(object sender, EventArgs e)
        {
            MouseLabelLeave();
        }
    }
}
