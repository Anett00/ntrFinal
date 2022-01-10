
namespace FuseNit.UserControls
{
    partial class ucCustomer
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
            this.lblID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // borderedPanel1
            // 
            this.borderedPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.borderedPanel1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.borderedPanel1.BorderColor = System.Drawing.Color.Black;
            this.borderedPanel1.BorderRadius = 10;
            this.borderedPanel1.BorderSize = 0;
            this.borderedPanel1.FlatAppearance.BorderSize = 0;
            this.borderedPanel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.borderedPanel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.borderedPanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.borderedPanel1.Location = new System.Drawing.Point(0, 0);
            this.borderedPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.borderedPanel1.Name = "borderedPanel1";
            this.borderedPanel1.Size = new System.Drawing.Size(150, 25);
            this.borderedPanel1.TabIndex = 0;
            this.borderedPanel1.Text = "Cég neve";
            this.borderedPanel1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.borderedPanel1.UseVisualStyleBackColor = false;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(3, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(35, 13);
            this.lblID.TabIndex = 5;
            this.lblID.Text = "label1";
            this.lblID.Visible = false;
            // 
            // ucCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.borderedPanel1);
            this.Name = "ucCustomer";
            this.Size = new System.Drawing.Size(150, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BorderedPanel borderedPanel1;
        public System.Windows.Forms.Label lblID;
    }
}
