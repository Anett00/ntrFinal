using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuseNit.Actions
{
    public class ControlActions
    {
        public void CheckProperties()
        {
            if (Properties.Settings.Default.dataBaseFolder == string.Empty)
            {
                Pages.LogIn.AddDataBasePath save = new Pages.LogIn.AddDataBasePath();
                save.ShowDialog();
            }
        }

        public void CheckDataBase()
        {
            if (!File.Exists(Properties.Settings.Default.dataBaseFolder))
            {
                try
                {
                    string[] qlicat = { "PÁV I.", "PÁV II.", "PÁV III." };
                    string[] categories = { "AM", "A1", "A2", "A", "B1", "B", "C1", "C", "D1", "D", "BE", "C1E", "CE", "D1E", "DE", "K, T" };
                    string createAdmin = "INSERT INTO users (userName, password, firstName, lastName, isItADriver, isItAdmin) VALUES ('admin', 'admin', 'Admin', 'Admin', 'false', 'true')";
                    string[] tables = { SQLStringsToDataBase.user, SQLStringsToDataBase.driver, SQLStringsToDataBase.vehicle, SQLStringsToDataBase.project, SQLStringsToDataBase.company, SQLStringsToDataBase.qlicat, SQLStringsToDataBase.categorie, SQLStringsToDataBase.catDriver, SQLStringsToDataBase.datDriver, SQLStringsToDataBase.customer, SQLStringsToDataBase.product, SQLStringsToDataBase.note };
                    string[] tables2 = { "Felhasználók", "Sofőrök", "Járművek", "Projektek", "Saját cégek", "PÁV kategóriák", "Kategóriák", "Sofőr-Kategória", "PÁV-Sofőr", "Ügyfelek", "Termékek", "Szállítólevelek"};

                    DataBaseUploading createDB = new DataBaseUploading();
                    createDB.CreateDataBase();

                    DataBaseUploading createTable = new DataBaseUploading();
                    for (int i = 0; i < tables.Length; i++)
                    {
                        createTable.CreateDataTable(tables[i]);
                        //MessageBox.Show("A(z) " + tables2[i] + " tábla létrehozva");
                    }

                    try
                    {
                        DataBaseUploading createTheAdmin = new DataBaseUploading();
                        createTheAdmin.CreateAdmin(createAdmin);
                        MessageBox.Show("Az admin létrehozva");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }

                    DataBaseUploading fillQLICAT = new DataBaseUploading();
                    for (int i = 0; i < qlicat.Length; i++)
                    {
                        fillQLICAT.FillQLICATTable(qlicat[i]);
                        //MessageBox.Show("A(z) " + qlicat[i] + " PÁV kategória létrehozva");
                    }

                    DataBaseUploading fillCategories = new DataBaseUploading();
                    for (int i = 0; i < categories.Length; i++)
                    {
                        fillCategories.FillCategorieTable(categories[i]);
                        //MessageBox.Show("A(z) " + categories[i] + " járműkategória létrehozva");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
