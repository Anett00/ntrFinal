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

namespace FuseNit.Pages.LogIn
{
    public partial class AddDataBasePath : Form
    {
        public AddDataBasePath()
        {
            InitializeComponent();
            lblSavingFolder.Text = "A mentés helye:";
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog saving = new FolderBrowserDialog();
            if (saving.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lblSavingFolder.Visible = true;
                lblSavingFolder.Text = saving.SelectedPath;
            }
        }

        private void btnSaveFolder_Click(object sender, EventArgs e)
        {
            string dataBaseName = "DataBase";
            string dataBasePath = Path.Combine(lblSavingFolder.Text, dataBaseName);
            Properties.Settings.Default.dataBaseFolder = dataBasePath + ".db";
            Properties.Settings.Default.connection = "Data Source =" + Properties.Settings.Default.dataBaseFolder;
            Properties.Settings.Default.Save();

            this.Close();
        }
    }
}
