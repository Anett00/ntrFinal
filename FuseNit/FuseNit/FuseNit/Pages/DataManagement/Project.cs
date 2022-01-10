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
    public partial class Project : Form
    {

        List<Actions.Project> projectList = new List<Actions.Project>();
        TextBox[] textes;

        public Project()
        {
            InitializeComponent();
            textes = new[] { txtProjectName, txtProjectNumber, txtCountry, txtProjectCity, txtProjectStreet, txtProjectPlaceNumber, txtProjectNameUpper, txtProjectZIP };
            SetData();
            FillPanel();
        }

        void SetData()
        {
            for (int i = 0; i < textes.Length; i++)
            {
                textes[i].Visible = false;
            }

            btnDelete.Enabled = false;
            btnModify.Enabled = false;
        }

        void FillPanel()
        {
            projectList.Clear();
            flpProject.Controls.Clear();

            DataBaseActions project = new DataBaseActions();

            foreach (Actions.Project item in project.GetAllProject(projectList))
            {
                ucProject userControl = new ucProject(item);
                userControl.Click += new EventHandler(this.ucProject_Click);
                userControl.AddButtonClick += (sender, args) => this.ucProject_Click(userControl, args);
                flpProject.Controls.Add(userControl);
            }
        }

        void ucProject_Click(object sender, EventArgs e)
        {
            btnModify.Enabled = true;
            btnDelete.Enabled = true;

            for (int i = 0; i < textes.Length; i++)
            {
                textes[i].Visible = true;
            }

            ucProject control = (ucProject)sender;
            int id = Convert.ToInt32(control.lblID.Text);
            var project = from x in projectList
                          where x.projectID == id
                          select x;

            foreach (var x in project)
            {
                lblID.Text = Convert.ToString(x.projectID);
                txtProjectCity.Text = Convert.ToString(x.projectPlaceCity);
                txtCountry.Text = Convert.ToString(x.projectCountry);
                txtProjectName.Text = Convert.ToString(x.projectName);
                txtProjectNameUpper.Text = Convert.ToString(x.projectName);
                txtProjectNumber.Text = Convert.ToString(x.projectNumber);
                txtProjectPlaceNumber.Text = Convert.ToString(x.projectPlaceNumber);
                txtProjectStreet.Text = Convert.ToString(x.projectPlaceStreet);
                txtProjectZIP.Text = Convert.ToString(x.projectPlaceZIPCode);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string delete = "DELETE FROM project WHERE projectID = '" + Convert.ToInt32(lblID.Text) + "'";

            DataBaseActions deleteProject = new DataBaseActions();
            deleteProject.DeleteFromDataBase(delete);

            FillPanel();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string add = "INSERT INTO project (projectName, projectCountry, projectCity, projectStreet, projectNumber, projectZIP, projectOtherNumber) VALUES ('Új projekt', '', '', '', '', '', '')";

            DataBaseActions addProject = new DataBaseActions();
            addProject.ActionWithDataBase(add);

            FillPanel();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE project SET " +
                    "projectName = '" + txtProjectName.Text +
                    "', projectCountry = '" + txtCountry.Text +
                    "', projectOtherNumber = '" + txtProjectNumber.Text +
                    "', projectCity = '" + txtProjectCity.Text +
                    "', projectStreet = '" + txtProjectStreet.Text +
                    "', projectNumber = '" + txtProjectPlaceNumber.Text +
                    "', projectZIP = '" + txtProjectZIP.Text + "' " +
                    "WHERE  projectID = '" + Convert.ToInt32(lblID.Text) + "';";

            DataBaseActions modify = new DataBaseActions();
            modify.ModifyDataBase(sql);

            FillPanel();
        }
    }
}
