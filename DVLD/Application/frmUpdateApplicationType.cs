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
    public partial class frmUpdateApplicationType : Form
    {
        private clsApplicationTypes _ApplicationType;
        private int _AppTypeID;
        public frmUpdateApplicationType(int AppTypeID)
        {
            InitializeComponent();

            _AppTypeID = AppTypeID;
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {
            _ApplicationType = clsApplicationTypes.FindAppliationTypeByID(_AppTypeID);

            lblID.Text = _AppTypeID.ToString();
            tbTitel.Text = _ApplicationType.ApplicationTypeTitel;
            tbFees.Text = _ApplicationType.ApplicationFees.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _ApplicationType.ApplicationTypeTitel = tbTitel.Text;
            _ApplicationType.ApplicationFees = decimal.Parse(tbFees.Text);

            if(_ApplicationType.Save())
            {
                MessageBox.Show("Application Type Updated Successfully", "Application Type Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Application Type Update Falid", "Application Type Update Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
