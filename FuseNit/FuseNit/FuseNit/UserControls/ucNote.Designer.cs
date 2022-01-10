
namespace FuseNit.UserControls
{
    partial class ucNote
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDeliveryNote = new System.Windows.Forms.Label();
            this.lblActive = new System.Windows.Forms.Label();
            this.lblDriverID = new System.Windows.Forms.Label();
            this.txtDateTo = new System.Windows.Forms.TextBox();
            this.txtDateFrom = new System.Windows.Forms.TextBox();
            this.txtDriver = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.borderedPanel1 = new FuseNit.BorderedPanel();
            this.SuspendLayout();
            // 
            // lblDeliveryNote
            // 
            this.lblDeliveryNote.AutoSize = true;
            this.lblDeliveryNote.Location = new System.Drawing.Point(848, 13);
            this.lblDeliveryNote.Name = "lblDeliveryNote";
            this.lblDeliveryNote.Size = new System.Drawing.Size(35, 13);
            this.lblDeliveryNote.TabIndex = 16;
            this.lblDeliveryNote.Text = "label1";
            this.lblDeliveryNote.Visible = false;
            // 
            // lblActive
            // 
            this.lblActive.AutoSize = true;
            this.lblActive.Location = new System.Drawing.Point(848, 9);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(35, 13);
            this.lblActive.TabIndex = 15;
            this.lblActive.Text = "label1";
            // 
            // lblDriverID
            // 
            this.lblDriverID.AutoSize = true;
            this.lblDriverID.Location = new System.Drawing.Point(848, 0);
            this.lblDriverID.Name = "lblDriverID";
            this.lblDriverID.Size = new System.Drawing.Size(35, 13);
            this.lblDriverID.TabIndex = 14;
            this.lblDriverID.Text = "label1";
            this.lblDriverID.Visible = false;
            // 
            // txtDateTo
            // 
            this.txtDateTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtDateTo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDateTo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtDateTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtDateTo.Location = new System.Drawing.Point(151, 6);
            this.txtDateTo.Margin = new System.Windows.Forms.Padding(1);
            this.txtDateTo.Multiline = true;
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.ReadOnly = true;
            this.txtDateTo.Size = new System.Drawing.Size(115, 20);
            this.txtDateTo.TabIndex = 13;
            this.txtDateTo.Text = "Eddig az időpontig";
            // 
            // txtDateFrom
            // 
            this.txtDateFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDateFrom.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtDateFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtDateFrom.Location = new System.Drawing.Point(13, 6);
            this.txtDateFrom.Margin = new System.Windows.Forms.Padding(1);
            this.txtDateFrom.Multiline = true;
            this.txtDateFrom.Name = "txtDateFrom";
            this.txtDateFrom.ReadOnly = true;
            this.txtDateFrom.Size = new System.Drawing.Size(115, 20);
            this.txtDateFrom.TabIndex = 12;
            this.txtDateFrom.Text = "Ettől a dátumtól";
            // 
            // txtDriver
            // 
            this.txtDriver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtDriver.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDriver.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtDriver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtDriver.Location = new System.Drawing.Point(321, 6);
            this.txtDriver.Margin = new System.Windows.Forms.Padding(1);
            this.txtDriver.Multiline = true;
            this.txtDriver.Name = "txtDriver";
            this.txtDriver.ReadOnly = true;
            this.txtDriver.Size = new System.Drawing.Size(162, 20);
            this.txtDriver.TabIndex = 11;
            this.txtDriver.Text = "Sofőr";
            // 
            // txtTo
            // 
            this.txtTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtTo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtTo.Location = new System.Drawing.Point(702, 6);
            this.txtTo.Margin = new System.Windows.Forms.Padding(1);
            this.txtTo.Multiline = true;
            this.txtTo.Name = "txtTo";
            this.txtTo.ReadOnly = true;
            this.txtTo.Size = new System.Drawing.Size(181, 20);
            this.txtTo.TabIndex = 10;
            this.txtTo.Text = "Hova";
            // 
            // txtFrom
            // 
            this.txtFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtFrom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFrom.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtFrom.Location = new System.Drawing.Point(499, 6);
            this.txtFrom.Margin = new System.Windows.Forms.Padding(1);
            this.txtFrom.Multiline = true;
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.ReadOnly = true;
            this.txtFrom.Size = new System.Drawing.Size(184, 20);
            this.txtFrom.TabIndex = 9;
            this.txtFrom.Text = "Honnan";
            // 
            // borderedPanel1
            // 
            this.borderedPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.borderedPanel1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.borderedPanel1.BorderColor = System.Drawing.Color.Black;
            this.borderedPanel1.BorderRadius = 20;
            this.borderedPanel1.BorderSize = 0;
            this.borderedPanel1.FlatAppearance.BorderSize = 0;
            this.borderedPanel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.borderedPanel1.ForeColor = System.Drawing.Color.Black;
            this.borderedPanel1.Location = new System.Drawing.Point(0, 0);
            this.borderedPanel1.Name = "borderedPanel1";
            this.borderedPanel1.Size = new System.Drawing.Size(900, 30);
            this.borderedPanel1.TabIndex = 17;
            this.borderedPanel1.TextColor = System.Drawing.Color.Black;
            this.borderedPanel1.UseVisualStyleBackColor = false;
            // 
            // ucNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblDeliveryNote);
            this.Controls.Add(this.lblActive);
            this.Controls.Add(this.lblDriverID);
            this.Controls.Add(this.txtDateTo);
            this.Controls.Add(this.txtDateFrom);
            this.Controls.Add(this.txtDriver);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.borderedPanel1);
            this.Name = "ucNote";
            this.Size = new System.Drawing.Size(900, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblDeliveryNote;
        public System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.Label lblDriverID;
        private System.Windows.Forms.TextBox txtDateTo;
        private System.Windows.Forms.TextBox txtDateFrom;
        private System.Windows.Forms.TextBox txtDriver;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.TextBox txtFrom;
        private BorderedPanel borderedPanel1;
    }
}
