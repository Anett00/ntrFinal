using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuseNit.Actions
{
    class DataBaseUploading
    {
        public void CreateDataBase()
        {
            try
            {
                SQLiteConnection.CreateFile(Properties.Settings.Default.dataBaseFolder);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void CreateDataTable(string create)
        {
            DataBaseActions createTable = new DataBaseActions();
            createTable.ActionWithDataBase(create);
        }

        public void CreateAdmin(string admin)
        {
            DataBaseActions createAdmin = new DataBaseActions();
            createAdmin.ActionWithDataBase(admin);
        }

        public void FillCategorieTable(string categorie)
        {
            string addCategorie = "INSERT INTO categorie (categorieName) VALUES ('" + categorie + "')";
            DataBaseActions fillCategories = new DataBaseActions();
            fillCategories.ActionWithDataBase(addCategorie);
        }

        public void FillQLICATTable(string qlicat)
        {
            string addQLICAT = "INSERT INTO qualificationLevelInCareerAptitudeTest (drivingAptitudeTestName) VALUES ('" + qlicat + "')";
            DataBaseActions fillQLICAT = new DataBaseActions();
            fillQLICAT.ActionWithDataBase(addQLICAT);
        }
    }
}
