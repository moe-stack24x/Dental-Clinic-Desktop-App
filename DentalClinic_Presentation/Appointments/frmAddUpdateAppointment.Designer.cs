namespace DentalClinic_Presentation.Appointments
{
    partial class frmAddUpdateAppointment
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
            this.components = new System.ComponentModel.Container();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lblAppointmentID = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpAppointmentDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpstartTime = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpEndTime = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbStatuslist = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlPatientInfoWithFillter1 = new DentalClinic_Presentation.Patients.Controls.ctrlPatientInfoWithFillter();
            this.ctrlDentistInfoWithFillter1 = new DentalClinic_Presentation.Dentists.controls.ctrlDentistInfoWithFillter();
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.lblAppointmentID);
            this.guna2ShadowPanel1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2ShadowPanel1.Controls.Add(this.guna2CirclePictureBox1);
            this.guna2ShadowPanel1.Controls.Add(this.lblTitle);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(4, 3);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.Radius = 12;
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.ShadowShift = 4;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(799, 102);
            this.guna2ShadowPanel1.TabIndex = 3;
            // 
            // lblAppointmentID
            // 
            this.lblAppointmentID.AutoSize = false;
            this.lblAppointmentID.BackColor = System.Drawing.Color.Transparent;
            this.lblAppointmentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentID.ForeColor = System.Drawing.Color.Teal;
            this.lblAppointmentID.Location = new System.Drawing.Point(618, 45);
            this.lblAppointmentID.Name = "lblAppointmentID";
            this.lblAppointmentID.Size = new System.Drawing.Size(54, 32);
            this.lblAppointmentID.TabIndex = 3;
            this.lblAppointmentID.Text = "0";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(432, 45);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(224, 45);
            this.guna2HtmlLabel1.TabIndex = 2;
            this.guna2HtmlLabel1.Text = "Appointment ID:";
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.Color.White;
            this.guna2CirclePictureBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2CirclePictureBox1.Image = global::DentalClinic_Presentation.Properties.Resources.appointment__4_;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(14, 9);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(76, 68);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox1.TabIndex = 1;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(96, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(330, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add Appointment";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.AutoSize = false;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(18, 481);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(224, 45);
            this.guna2HtmlLabel2.TabIndex = 4;
            this.guna2HtmlLabel2.Text = "Date";
            // 
            // dtpAppointmentDate
            // 
            this.dtpAppointmentDate.BorderRadius = 10;
            this.dtpAppointmentDate.BorderThickness = 2;
            this.dtpAppointmentDate.Checked = true;
            this.dtpAppointmentDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtpAppointmentDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpAppointmentDate.ForeColor = System.Drawing.Color.White;
            this.dtpAppointmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpAppointmentDate.Location = new System.Drawing.Point(18, 513);
            this.dtpAppointmentDate.MaxDate = new System.DateTime(2077, 11, 16, 23, 59, 59, 999);
            this.dtpAppointmentDate.MinDate = new System.DateTime(1900, 4, 30, 0, 0, 0, 0);
            this.dtpAppointmentDate.Name = "dtpAppointmentDate";
            this.dtpAppointmentDate.Size = new System.Drawing.Size(370, 48);
            this.dtpAppointmentDate.TabIndex = 5;
            this.dtpAppointmentDate.Value = new System.DateTime(2026, 11, 10, 9, 43, 6, 552);
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.AutoSize = false;
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(375, 579);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(224, 45);
            this.guna2HtmlLabel3.TabIndex = 6;
            this.guna2HtmlLabel3.Text = "End Time";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.AutoSize = false;
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(12, 579);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(224, 45);
            this.guna2HtmlLabel4.TabIndex = 7;
            this.guna2HtmlLabel4.Text = "Start Time";
            // 
            // dtpstartTime
            // 
            this.dtpstartTime.AllowDrop = true;
            this.dtpstartTime.BorderRadius = 10;
            this.dtpstartTime.Checked = true;
            this.dtpstartTime.CustomFormat = "HH:mm:ss:mmm";
            this.dtpstartTime.FillColor = System.Drawing.Color.Gray;
            this.dtpstartTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpstartTime.ForeColor = System.Drawing.Color.White;
            this.dtpstartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpstartTime.Location = new System.Drawing.Point(12, 618);
            this.dtpstartTime.MaxDate = new System.DateTime(2077, 11, 16, 23, 59, 59, 999);
            this.dtpstartTime.MinDate = new System.DateTime(1900, 4, 30, 0, 0, 0, 0);
            this.dtpstartTime.Name = "dtpstartTime";
            this.dtpstartTime.ShowUpDown = true;
            this.dtpstartTime.Size = new System.Drawing.Size(200, 36);
            this.dtpstartTime.TabIndex = 8;
            this.dtpstartTime.Value = new System.DateTime(2026, 11, 10, 9, 47, 57, 6);
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.BorderRadius = 10;
            this.dtpEndTime.Checked = true;
            this.dtpEndTime.CustomFormat = "HH:mm:ss:mmm";
            this.dtpEndTime.FillColor = System.Drawing.Color.Gray;
            this.dtpEndTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEndTime.ForeColor = System.Drawing.Color.White;
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndTime.Location = new System.Drawing.Point(353, 618);
            this.dtpEndTime.MaxDate = new System.DateTime(2077, 11, 16, 23, 59, 59, 999);
            this.dtpEndTime.MinDate = new System.DateTime(1900, 4, 30, 0, 0, 0, 0);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(200, 36);
            this.dtpEndTime.TabIndex = 9;
            this.dtpEndTime.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.dtpEndTime.Value = new System.DateTime(2026, 11, 10, 9, 45, 47, 762);
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.AutoSize = false;
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel5.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(18, 679);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(224, 45);
            this.guna2HtmlLabel5.TabIndex = 10;
            this.guna2HtmlLabel5.Text = "Status";
            // 
            // cbStatuslist
            // 
            this.cbStatuslist.BackColor = System.Drawing.Color.Transparent;
            this.cbStatuslist.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbStatuslist.BorderRadius = 10;
            this.cbStatuslist.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbStatuslist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatuslist.FillColor = System.Drawing.Color.Gainsboro;
            this.cbStatuslist.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbStatuslist.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbStatuslist.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbStatuslist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbStatuslist.ItemHeight = 30;
            this.cbStatuslist.Items.AddRange(new object[] {
            "Scheduled",
            "Cancelled",
            "Completed"});
            this.cbStatuslist.Location = new System.Drawing.Point(18, 709);
            this.cbStatuslist.Name = "cbStatuslist";
            this.cbStatuslist.Size = new System.Drawing.Size(296, 36);
            this.cbStatuslist.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.BorderRadius = 15;
            this.btnSave.BorderThickness = 3;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSave.Image = global::DentalClinic_Presentation.Properties.Resources.diskette;
            this.btnSave.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSave.ImageSize = new System.Drawing.Size(40, 40);
            this.btnSave.Location = new System.Drawing.Point(608, 685);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSave.Size = new System.Drawing.Size(186, 60);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlPatientInfoWithFillter1
            // 
            this.ctrlPatientInfoWithFillter1.BackColor = System.Drawing.SystemColors.Control;
            this.ctrlPatientInfoWithFillter1.FilterEnabled = true;
            this.ctrlPatientInfoWithFillter1.Location = new System.Drawing.Point(-5, 111);
            this.ctrlPatientInfoWithFillter1.Name = "ctrlPatientInfoWithFillter1";
            this.ctrlPatientInfoWithFillter1.Size = new System.Drawing.Size(799, 184);
            this.ctrlPatientInfoWithFillter1.TabIndex = 14;
            // 
            // ctrlDentistInfoWithFillter1
            // 
            this.ctrlDentistInfoWithFillter1.FilterEnabled = true;
            this.ctrlDentistInfoWithFillter1.Location = new System.Drawing.Point(4, 290);
            this.ctrlDentistInfoWithFillter1.Name = "ctrlDentistInfoWithFillter1";
            this.ctrlDentistInfoWithFillter1.Size = new System.Drawing.Size(799, 184);
            this.ctrlDentistInfoWithFillter1.TabIndex = 13;
            // 
            // frmAddUpdateAppointment
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(806, 753);
            this.Controls.Add(this.ctrlPatientInfoWithFillter1);
            this.Controls.Add(this.ctrlDentistInfoWithFillter1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbStatuslist);
            this.Controls.Add(this.guna2HtmlLabel5);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.dtpstartTime);
            this.Controls.Add(this.guna2HtmlLabel4);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.dtpAppointmentDate);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddUpdateAppointment";
            this.Text = "dd";
            this.Load += new System.EventHandler(this.frmAddUpdateAppointment_Load);
            this.guna2ShadowPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAppointmentID;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpAppointmentDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpstartTime;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEndTime;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2ComboBox cbStatuslist;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Dentists.controls.ctrlDentistInfoWithFillter ctrlDentistInfoWithFillter1;
        private Patients.Controls.ctrlPatientInfoWithFillter ctrlPatientInfoWithFillter1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}