
namespace FuseNit.UserControls
{
    partial class ucDriver
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
            this.bpName = new FuseNit.BorderedPanel();
            this.lblID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bpName
            // 
            this.bpName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.bpName.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.bpName.BorderColor = System.Drawing.Color.Black;
            this.bpName.BorderRadius = 15;
            this.bpName.BorderSize = 0;
            this.bpName.FlatAppearance.BorderSize = 0;
            this.bpName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bpName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bpName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.bpName.Location = new System.Drawing.Point(0, 0);
            this.bpName.Name = "bpName";
            this.bpName.Size = new System.Drawing.Size(150, 25);
            this.bpName.TabIndex = 0;
            this.bpName.Text = "name";
            this.bpName.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.bpName.UseVisualStyleBackColor = false;
            this.bpName.MouseLeave += new System.EventHandler(this.bpName_MouseLeave);
            this.bpName.MouseHover += new System.EventHandler(this.bpName_MouseHover);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(3, 7);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(35, 13);
            this.lblID.TabIndex = 2;
            this.lblID.Text = "label1";
            this.lblID.Visible = false;
            // 
            // ucDriver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.bpName);
            this.Name = "ucDriver";
            this.Size = new System.Drawing.Size(150, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BorderedPanel bpName;
        public System.Windows.Forms.Label lblID;
    }
}
