namespace DentalClinic_Presentation.Users
{
    partial class frmAddUpdateUser
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
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.chkIsActive = new Guna.UI2.WinForms.Guna2CheckBox();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtConfirmPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lblUserID = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.guna2GradientPanel1.SuspendLayout();
            this.guna2ShadowPanel2.SuspendLayout();
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.White;
            this.guna2GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GradientPanel1.BorderRadius = 5;
            this.guna2GradientPanel1.BorderThickness = 4;
            this.guna2GradientPanel1.Controls.Add(this.btnSave);
            this.guna2GradientPanel1.Controls.Add(this.btnClose);
            this.guna2GradientPanel1.Controls.Add(this.guna2ShadowPanel2);
            this.guna2GradientPanel1.Controls.Add(this.guna2ShadowPanel1);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(910, 474);
            this.guna2GradientPanel1.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.BorderRadius = 15;
            this.btnSave.BorderThickness = 3;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.Image = global::DentalClinic_Presentation.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnSave.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSave.Location = new System.Drawing.Point(474, 388);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSave.Size = new System.Drawing.Size(135, 52);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.BorderColor = System.Drawing.Color.Maroon;
            this.btnClose.BorderRadius = 15;
            this.btnClose.BorderThickness = 3;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.Maroon;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::DentalClinic_Presentation.Properties.Resources.close__1_;
            this.btnClose.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnClose.ImageSize = new System.Drawing.Size(30, 30);
            this.btnClose.Location = new System.Drawing.Point(285, 388);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnClose.Size = new System.Drawing.Size(135, 52);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // guna2ShadowPanel2
            // 
            this.guna2ShadowPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ShadowPanel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel2.Controls.Add(this.chkIsActive);
            this.guna2ShadowPanel2.Controls.Add(this.txtPassword);
            this.guna2ShadowPanel2.Controls.Add(this.guna2HtmlLabel8);
            this.guna2ShadowPanel2.Controls.Add(this.txtConfirmPassword);
            this.guna2ShadowPanel2.Controls.Add(this.txtUserName);
            this.guna2ShadowPanel2.Controls.Add(this.guna2HtmlLabel2);
            this.guna2ShadowPanel2.Controls.Add(this.guna2HtmlLabel5);
            this.guna2ShadowPanel2.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel2.Location = new System.Drawing.Point(25, 100);
            this.guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            this.guna2ShadowPanel2.Radius = 12;
            this.guna2ShadowPanel2.ShadowColor = System.Drawing.Color.White;
            this.guna2ShadowPanel2.ShadowShift = 4;
            this.guna2ShadowPanel2.Size = new System.Drawing.Size(870, 261);
            this.guna2ShadowPanel2.TabIndex = 1;
            // 
            // chkIsActive
            // 
            this.chkIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIsActive.CheckedState.BorderColor = System.Drawing.Color.Teal;
            this.chkIsActive.CheckedState.BorderRadius = 15;
            this.chkIsActive.CheckedState.BorderThickness = 2;
            this.chkIsActive.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkIsActive.CheckMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkIsActive.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIsActive.Location = new System.Drawing.Point(346, 146);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkIsActive.Size = new System.Drawing.Size(148, 59);
            this.chkIsActive.TabIndex = 120;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.chkIsActive.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkIsActive.UncheckedState.BorderRadius = 10;
            this.chkIsActive.UncheckedState.BorderThickness = 1;
            this.chkIsActive.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // txtPassword
            // 
            this.txtPassword.BorderColor = System.Drawing.Color.Teal;
            this.txtPassword.BorderRadius = 12;
            this.txtPassword.BorderThickness = 2;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Location = new System.Drawing.Point(136, 93);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.PlaceholderText = "";
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(224, 33);
            this.txtPassword.TabIndex = 119;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // guna2HtmlLabel8
            // 
            this.guna2HtmlLabel8.AutoSize = false;
            this.guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2HtmlLabel8.Location = new System.Drawing.Point(18, 93);
            this.guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            this.guna2HtmlLabel8.Size = new System.Drawing.Size(313, 57);
            this.guna2HtmlLabel8.TabIndex = 118;
            this.guna2HtmlLabel8.Text = "Password:";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BorderColor = System.Drawing.Color.Teal;
            this.txtConfirmPassword.BorderRadius = 12;
            this.txtConfirmPassword.BorderThickness = 2;
            this.txtConfirmPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfirmPassword.DefaultText = "";
            this.txtConfirmPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtConfirmPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtConfirmPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirmPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirmPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtConfirmPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConfirmPassword.Location = new System.Drawing.Point(628, 93);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.PlaceholderText = "";
            this.txtConfirmPassword.SelectedText = "";
            this.txtConfirmPassword.Size = new System.Drawing.Size(224, 33);
            this.txtConfirmPassword.TabIndex = 116;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            this.txtConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPassword_Validating);
            // 
            // txtUserName
            // 
            this.txtUserName.BorderColor = System.Drawing.Color.Teal;
            this.txtUserName.BorderRadius = 12;
            this.txtUserName.BorderThickness = 2;
            this.txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserName.DefaultText = "";
            this.txtUserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserName.Location = new System.Drawing.Point(360, 14);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PlaceholderText = "";
            this.txtUserName.SelectedText = "";
            this.txtUserName.Size = new System.Drawing.Size(224, 33);
            this.txtUserName.TabIndex = 10;
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserName_Validating);
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.AutoSize = false;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(239, 14);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(234, 60);
            this.guna2HtmlLabel2.TabIndex = 4;
            this.guna2HtmlLabel2.Text = "User Name:";
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.AutoSize = false;
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(454, 93);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(313, 66);
            this.guna2HtmlLabel5.TabIndex = 7;
            this.guna2HtmlLabel5.Text = "Confirm Password:";
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.lblUserID);
            this.guna2ShadowPanel1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2ShadowPanel1.Controls.Add(this.guna2CirclePictureBox1);
            this.guna2ShadowPanel1.Controls.Add(this.lblTitle);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(25, 14);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.Radius = 12;
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.ShadowShift = 4;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(870, 80);
            this.guna2ShadowPanel1.TabIndex = 0;
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = false;
            this.lblUserID.BackColor = System.Drawing.Color.Transparent;
            this.lblUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.ForeColor = System.Drawing.Color.Teal;
            this.lblUserID.Location = new System.Drawing.Point(490, 16);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(54, 32);
            this.lblUserID.TabIndex = 3;
            this.lblUserID.Text = "0";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(381, 16);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(173, 45);
            this.guna2HtmlLabel1.TabIndex = 2;
            this.guna2HtmlLabel1.Text = "User ID:";
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.Color.White;
            this.guna2CirclePictureBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2CirclePictureBox1.Image = global::DentalClinic_Presentation.Properties.Resources.user__4_;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(26, 11);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(55, 50);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox1.TabIndex = 1;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(96, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(330, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add User";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddUpdateUser
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(910, 474);
            this.Controls.Add(this.guna2GradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmAddUpdateUser";
            this.Text = "frmAddUpdateUser";
            this.Load += new System.EventHandler(this.frmAddUpdateUser_Load);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2ShadowPanel2.ResumeLayout(false);
            this.guna2ShadowPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;
        private Guna.UI2.WinForms.Guna2CheckBox chkIsActive;
        private Guna.UI2.WinForms.Guna2TextBox txtUserName;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUserID;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel8;
        private Guna.UI2.WinForms.Guna2TextBox txtConfirmPassword;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}