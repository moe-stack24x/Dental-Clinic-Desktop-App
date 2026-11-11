using DentalClinic_Business;
using DentalClinic_Presentation.Dentists.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentalClinic_Presentation.Dentists
{
    public partial class frmDentistCard : Form
    {

        private int _DentistID = -1;

        public int DentistID
        {
            get { return ctrlDentistCard1.DentistID; }
        }

        public clsDentist SelectedDentistInfo
        {
            get { return ctrlDentistCard1.SelectedDentist; }
        }
        public frmDentistCard(int DentistID)
        {
            InitializeComponent();
            _DentistID = DentistID;
            ctrlDentistCard1.LoadDentistInfo(DentistID);
        }

        private void frmDentistCard_Load(object sender, EventArgs e)
        {

        }
    }
}
