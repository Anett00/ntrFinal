
namespace FuseNit.UserControls
{
    partial class ucVehicle
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
            this.borderedPanel1 = new FuseNit.BorderedPanel();
            this.lblRegistrationNumber = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // borderedPanel1
            // 
            this.borderedPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.borderedPanel1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.borderedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.borderedPanel1.BorderRadius = 25;
            this.borderedPanel1.BorderSize = 0;
            this.borderedPanel1.FlatAppearance.BorderSize = 0;
            this.borderedPanel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.borderedPanel1.ForeColor = System.Drawing.Color.Black;
            this.borderedPanel1.Location = new System.Drawing.Point(0, 0);
            this.borderedPanel1.Name = "borderedPanel1";
            this.borderedPanel1.Size = new System.Drawing.Size(180, 50);
            this.borderedPanel1.TabIndex = 1;
            this.borderedPanel1.TextColor = System.Drawing.Color.Black;
            this.borderedPanel1.UseVisualStyleBackColor = false;
            this.borderedPanel1.MouseLeave += new System.EventHandler(this.borderedPanel1_MouseLeave);
            this.borderedPanel1.MouseHover += new System.EventHandler(this.borderedPanel1_MouseHover);
            // 
            // lblRegistrationNumber
            // 
            this.lblRegistrationNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblRegistrationNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRegistrationNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblRegistrationNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblRegistrationNumber.Location = new System.Drawing.Point(15, 25);
            this.lblRegistrationNumber.Name = "lblRegistrationNumber";
            this.lblRegistrationNumber.Size = new System.Drawing.Size(150, 20);
            this.lblRegistrationNumber.TabIndex = 8;
            this.lblRegistrationNumber.Text = "label2";
            this.lblRegistrationNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRegistrationNumber.MouseLeave += new System.EventHandler(this.lblRegistrationNumber_MouseLeave);
            this.lblRegistrationNumber.MouseHover += new System.EventHandler(this.lblRegistrationNumber_MouseHover);
            // 
            // lblModel
            // 
            this.lblModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblModel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblModel.Location = new System.Drawing.Point(15, 5);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(150, 20);
            this.lblModel.TabIndex = 7;
            this.lblModel.Text = "label1";
            this.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblModel.MouseLeave += new System.EventHandler(this.lblModel_MouseLeave);
            this.lblModel.MouseHover += new System.EventHandler(this.lblModel_MouseHover);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(145, 19);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(35, 13);
            this.lblID.TabIndex = 6;
            this.lblID.Text = "label3";
            this.lblID.Visible = false;
            // 
            // ucVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblRegistrationNumber);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.borderedPanel1);
            this.Name = "ucVehicle";
            this.Size = new System.Drawing.Size(180, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BorderedPanel borderedPanel1;
        public System.Windows.Forms.Label lblRegistrationNumber;
        public System.Windows.Forms.Label lblModel;
        public System.Windows.Forms.Label lblID;
    }
}
