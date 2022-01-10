using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuseNit.Actions
{
    class HomePageActions
    {
        private Form activeForm = null;

        public void HideSubPanelWithHamburger(Panel subPanel)
        {
            if (subPanel.Visible == true)
            {
                subPanel.Visible = false;
            }
            else
            {
                subPanel.Visible = true;
            }
        }

        public void ShowHideButton(Button button, Button[] buttons, PictureBox[] pictures)
        {
            if (button.Visible == false)
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Visible = true;
                    pictures[i].Visible = true;
                }
            }
            else
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Visible = false;
                    pictures[i].Visible = false;
                }
            }
        }

        public void HideButtons(Button[] buttons, PictureBox[] pictures)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Visible = false;
                pictures[i].Visible = false;
            }
        }

        public void OpenChildForm(Form childForm, Panel panelChildForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
