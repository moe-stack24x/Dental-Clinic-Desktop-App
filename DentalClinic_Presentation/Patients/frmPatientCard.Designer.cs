namespace DentalClinic_Presentation.Patients
{
    partial class frmPatientCard
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
            this.ctrlPatientcard1 = new DentalClinic_Presentation.Patients.Controls.ctrlPatientcard();
            this.SuspendLayout();
            // 
            // ctrlPatientcard1
            // 
            this.ctrlPatientcard1.Location = new System.Drawing.Point(-3, -14);
            this.ctrlPatientcard1.Name = "ctrlPatientcard1";
            this.ctrlPatientcard1.Size = new System.Drawing.Size(825, 684);
            this.ctrlPatientcard1.TabIndex = 0;
            // 
            // frmPatientCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 646);
            this.Controls.Add(this.ctrlPatientcard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPatientCard";
            this.Text = "frmPatientCard";
            this.Load += new System.EventHandler(this.frmPatientCard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlPatientcard ctrlPatientcard1;
    }
}