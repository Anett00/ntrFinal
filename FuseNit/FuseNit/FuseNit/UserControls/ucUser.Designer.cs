
namespace FuseNit.UserControls
{
    partial class ucUser
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
            this.lblRank = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
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
            this.borderedPanel1.TabIndex = 0;
            this.borderedPanel1.TextColor = System.Drawing.Color.Black;
            this.borderedPanel1.UseVisualStyleBackColor = false;
            this.borderedPanel1.MouseLeave += new System.EventHandler(this.borderedPanel1_MouseLeave);
            this.borderedPanel1.MouseHover += new System.EventHandler(this.borderedPanel1_MouseHover);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(145, 24);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(35, 13);
            this.lblID.TabIndex = 3;
            this.lblID.Text = "label3";
            this.lblID.Visible = false;
            // 
            // lblRank
            // 
            this.lblRank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblRank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRank.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblRank.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblRank.Location = new System.Drawing.Point(15, 25);
            this.lblRank.Name = "lblRank";
            this.lblRank.Size = new System.Drawing.Size(150, 20);
            this.lblRank.TabIndex = 5;
            this.lblRank.Text = "label2";
            this.lblRank.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRank.MouseLeave += new System.EventHandler(this.lblRank_MouseLeave);
            this.lblRank.MouseHover += new System.EventHandler(this.lblRank_MouseHover);
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblName.Location = new System.Drawing.Point(15, 5);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(150, 20);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "label1";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblName.MouseLeave += new System.EventHandler(this.lblName_MouseLeave);
            this.lblName.MouseHover += new System.EventHandler(this.lblName_MouseHover);
            // 
            // ucUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblRank);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.borderedPanel1);
            this.Name = "ucUser";
            this.Size = new System.Drawing.Size(180, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BorderedPanel borderedPanel1;
        public System.Windows.Forms.Label lblRank;
        public System.Windows.Forms.Label lblName;
        public System.Windows.Forms.Label lblID;
    }
}
