using DVLD___Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class Retake : UserControl
    {
        private clsApplicationTypes _ApplicationType;
        private clsTestTypes _TestType;

        public Retake()
        {
            InitializeComponent();
        }

        public void SetData(int ID, int TestTypeID)
        {
            _TestType = clsTestTypes.FindTestTypeByID(TestTypeID);
            _ApplicationType = clsApplicationTypes.FindAppliationTypeByID(7);
            lblAppFees.Text = _ApplicationType.ApplicationFees.ToString();
            lblTotalFees.Text = (_TestType.TestTypeFees + _ApplicationType.ApplicationFees).ToString();
            if (ID == -1)
            {
                lblAppID.Text = "N/A";
            }
            else 
            {
                lblAppID.Text = ID.ToString(); 
            }
        }
    }
}
