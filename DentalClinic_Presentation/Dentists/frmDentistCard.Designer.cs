namespace DentalClinic_Presentation.Dentists
{
    partial class frmDentistCard
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
            this.ctrlDentistCard1 = new DentalClinic_Presentation.Dentists.controls.ctrlDentistCard();
            this.SuspendLayout();
            // 
            // ctrlDentistCard1
            // 
            this.ctrlDentistCard1.Location = new System.Drawing.Point(-3, -7);
            this.ctrlDentistCard1.Name = "ctrlDentistCard1";
            this.ctrlDentistCard1.Size = new System.Drawing.Size(836, 658);
            this.ctrlDentistCard1.TabIndex = 0;
            // 
            // frmDentistCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 646);
            this.Controls.Add(this.ctrlDentistCard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDentistCard";
            this.Text = "frmDentistCard";
            this.Load += new System.EventHandler(this.frmDentistCard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private controls.ctrlDentistCard ctrlDentistCard1;
    }
}