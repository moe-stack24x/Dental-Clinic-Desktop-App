namespace DentalClinic_Presentation.Dentists.controls
{
    partial class ctrlDentistInfoWithFillter
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
            this.ctrlDentistInfo1 = new DentalClinic_Presentation.Dentists.controls.ctrlDentistInfo();
            this.gbFillter = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtsearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnFind = new Guna.UI2.WinForms.Guna2Button();
            this.gbFillter.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlDentistInfo1
            // 
            this.ctrlDentistInfo1.Location = new System.Drawing.Point(313, 0);
            this.ctrlDentistInfo1.Name = "ctrlDentistInfo1";
            this.ctrlDentistInfo1.Size = new System.Drawing.Size(522, 216);
            this.ctrlDentistInfo1.TabIndex = 0;
            // 
            // gbFillter
            // 
            this.gbFillter.BackColor = System.Drawing.SystemColors.Control;
            this.gbFillter.BorderColor = System.Drawing.SystemColors.Control;
            this.gbFillter.Controls.Add(this.txtsearch);
            this.gbFillter.Controls.Add(this.btnFind);
            this.gbFillter.CustomBorderColor = System.Drawing.SystemColors.Control;
            this.gbFillter.FillColor = System.Drawing.SystemColors.Control;
            this.gbFillter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gbFillter.ForeColor = System.Drawing.SystemColors.Control;
            this.gbFillter.Location = new System.Drawing.Point(3, 89);
            this.gbFillter.Name = "gbFillter";
            this.gbFillter.Size = new System.Drawing.Size(314, 66);
            this.gbFillter.TabIndex = 13;
            // 
            // txtsearch
            // 
            this.txtsearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtsearch.BorderRadius = 12;
            this.txtsearch.BorderThickness = 2;
            this.txtsearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtsearch.DefaultText = "Search  Dentis By ID";
            this.txtsearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtsearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtsearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtsearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtsearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtsearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtsearch.HoverState.BorderColor = System.Drawing.Color.Teal;
            this.txtsearch.Location = new System.Drawing.Point(0, 14);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.PlaceholderText = "";
            this.txtsearch.SelectedText = "";
            this.txtsearch.Size = new System.Drawing.Size(242, 42);
            this.txtsearch.TabIndex = 10;
            this.txtsearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsearch_KeyPress);
            // 
            // btnFind
            // 
            this.btnFind.BorderRadius = 15;
            this.btnFind.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFind.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFind.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFind.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFind.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFind.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFind.ForeColor = System.Drawing.Color.White;
            this.btnFind.Image = global::DentalClinic_Presentation.Properties.Resources.zoom__1_;
            this.btnFind.ImageSize = new System.Drawing.Size(40, 40);
            this.btnFind.Location = new System.Drawing.Point(248, 14);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(56, 36);
            this.btnFind.TabIndex = 11;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // ctrlDentistInfoWithFillter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.gbFillter);
            this.Controls.Add(this.ctrlDentistInfo1);
            this.Name = "ctrlDentistInfoWithFillter";
            this.Size = new System.Drawing.Size(833, 208);
            this.Load += new System.EventHandler(this.ctrlDentistInfoWithFillter_Load);
            this.gbFillter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlDentistInfo ctrlDentistInfo1;
        private Guna.UI2.WinForms.Guna2GroupBox gbFillter;
        private Guna.UI2.WinForms.Guna2TextBox txtsearch;
        private Guna.UI2.WinForms.Guna2Button btnFind;
    }
}
