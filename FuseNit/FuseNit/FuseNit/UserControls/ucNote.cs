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
    public partial class ucNote : UserControl
    {
        public event EventHandler AddButtonClick
        {
            add
            {
                txtFrom.Click += value;
                txtTo.Click += value;
                txtDriver.Click += value;
                txtDateFrom.Click += value;
                txtDateTo.Click += value;
                borderedPanel1.Click += value;
            }
            remove
            {
                txtFrom.Click -= value;
                txtTo.Click -= value;
                txtDriver.Click -= value;
                txtDateFrom.Click -= value;
                txtDateTo.Click -= value;
                borderedPanel1.Click -= value;
            }
        }

        public ucNote(Actions.DeliveryNote note, string driver)
        {
            InitializeComponent();
            SetData(note, driver);
        }

        void SetData(Actions.DeliveryNote note, string driver)
        {
            lblDriverID.Text = note.driverID.ToString();
            lblActive.Text = note.isItActive.ToString();
            lblDeliveryNote.Text = note.noteID.ToString();
            txtFrom.Text = String.Concat(note.deparutureCity, ", ", note.departureStreet, " ", note.departurePlace, " ", note.departureNumber, ".");
            txtTo.Text = String.Concat(note.destinationCity, ", ", note.destinationStreet, " ", note.destinationPlace, " ", note.destinationNumber, ".");
            txtDriver.Text = driver;
            txtDateFrom.Text = note.dateFrom.ToString();
            txtDateTo.Text = note.dateTo.ToString();
        }
    }
}
