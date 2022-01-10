using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuseNit.Actions
{
    class FormActions
    {
        public string BoolToRank(string rank)
        {
            string driver;
            if (rank == "True" || rank == "true")
            {
                driver = "igen";
            }
            else
            {
                driver = "nem";
            }

            return driver;
        }

        public string BoolToLevel(string level)
        {
            string admin;
            if (level == "True" || level == "true")
            {
                admin = "igen";
            }
            else
            {
                admin = "nem";
            }

            return admin;
        }

        public int StringToComboBoxIndex(ComboBox combo, string isIt)
        {
            int index;

            index = combo.FindString(isIt);

            return index;
        }

    }
}
