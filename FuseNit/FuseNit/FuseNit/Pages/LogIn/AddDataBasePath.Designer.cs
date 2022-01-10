
namespace FuseNit.Pages.LogIn
{
    partial class AddDataBasePath
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDataBasePath));
            this.btnSaveFolder = new System.Windows.Forms.Button();
            this.lblSavingFolder = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSaveFolder
            // 
            this.btnSaveFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSaveFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveFolder.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSaveFolder.Location = new System.Drawing.Point(12, 171);
            this.btnSaveFolder.Name = "btnSaveFolder";
            this.btnSaveFolder.Size = new System.Drawing.Size(258, 39);
            this.btnSaveFolder.TabIndex = 17;
            this.btnSaveFolder.Text = "Ment";
            this.btnSaveFolder.UseVisualStyleBackColor = true;
            this.btnSaveFolder.Click += new System.EventHandler(this.btnSaveFolder_Click);
            // 
            // lblSavingFolder
            // 
            this.lblSavingFolder.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSavingFolder.Location = new System.Drawing.Point(12, 112);
            this.lblSavingFolder.Name = "lblSavingFolder";
            this.lblSavingFolder.Size = new System.Drawing.Size(258, 56);
            this.lblSavingFolder.TabIndex = 16;
            this.lblSavingFolder.Text = "A mentés helye";
            this.lblSavingFolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSavingFolder.UseCompatibleTextRendering = true;
            this.lblSavingFolder.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(64, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Ide mentjük az adatbázist:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFolder
            // 
            this.btnFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFolder.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFolder.Location = new System.Drawing.Point(12, 13);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(258, 39);
            this.btnFolder.TabIndex = 14;
            this.btnFolder.Text = "Mappaválasztás";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // AddDataBasePath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(282, 223);
            this.Controls.Add(this.btnSaveFolder);
            this.Controls.Add(this.lblSavingFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFolder);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddDataBasePath";
            this.Text = "Adatbázis mentése";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveFolder;
        private System.Windows.Forms.Label lblSavingFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFolder;
    }
}