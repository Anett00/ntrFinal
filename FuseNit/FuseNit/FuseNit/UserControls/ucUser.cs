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
    public partial class ucUser : UserControl
    {
        Label[] labelArray;
        private string userRank;

        public ucUser(Actions.User user)
        {
            InitializeComponent();
            labelArray = new Label[] { lblName, lblRank };
            lblName.Text = user.fullName;
            lblID.Text = user.userID.ToString();
            lblRank.Text = WrittenRank(user);
        }

        public string WrittenRank(Actions.User user)
        {
            if (user.isItADriver == true || (user.isItADriver).ToString() == "True")
            {
                userRank = "sofőr";
            }
            else
            {
                userRank = "adminisztrátor";
            }

            return userRank;
        }

        public event EventHandler AddButtonClick
        {
            add
            {
                for (int i = 0; i < labelArray.Length; i++)
                {
                    labelArray[i].Click += value;
                }
                borderedPanel1.Click += value;
            }
            remove
            {
                for (int i = 0; i < labelArray.Length; i++)
                {
                    labelArray[i].Click -= value;
                }
                borderedPanel1.Click -= value;
            }
        }

        private void borderedPanel1_MouseHover(object sender, EventArgs e)
        {
            for (int i = 0; i < labelArray.Length; i++)
            {
                labelArray[i].BackColor = Color.FromArgb(60, 0, 0);
            }
            borderedPanel1.BackgroundColor = Color.FromArgb(60, 0, 0);
            borderedPanel1.BorderColor = Color.FromArgb(60, 0, 0);
        }
        private void lblName_MouseHover(object sender, EventArgs e)
        {
            for (int i = 0; i < labelArray.Length; i++)
            {
                labelArray[i].BackColor = Color.FromArgb(60, 0, 0);
            }
            borderedPanel1.BackgroundColor = Color.FromArgb(60, 0, 0);
            borderedPanel1.BorderColor = Color.FromArgb(60, 0, 0);
        }
        private void lblRank_MouseHover(object sender, EventArgs e)
        {
            for (int i = 0; i < labelArray.Length; i++)
            {
                labelArray[i].BackColor = Color.FromArgb(60, 0, 0);
            }
            borderedPanel1.BackgroundColor = Color.FromArgb(60, 0, 0);
            borderedPanel1.BorderColor = Color.FromArgb(60, 0, 0);
        }

        private void borderedPanel1_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i < labelArray.Length; i++)
            {
                labelArray[i].BackColor = Color.FromArgb(38, 38, 38);
            }
            borderedPanel1.BackgroundColor = Color.FromArgb(38, 38, 38);
            borderedPanel1.BorderColor = Color.FromArgb(38, 38, 38);
        }
        private void lblName_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i < labelArray.Length; i++)
            {
                labelArray[i].BackColor = Color.FromArgb(38, 38, 38);
            }
            borderedPanel1.BackgroundColor = Color.FromArgb(38, 38, 38);
            borderedPanel1.BorderColor = Color.FromArgb(38, 38, 38);
        }
        private void lblRank_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i < labelArray.Length; i++)
            {
                labelArray[i].BackColor = Color.FromArgb(38, 38, 38);
            }
            borderedPanel1.BackgroundColor = Color.FromArgb(38, 38, 38);
            borderedPanel1.BorderColor = Color.FromArgb(38, 38, 38);
        }
    }
}
