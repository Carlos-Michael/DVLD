using DVLD___Logic_Layer;
using System;
using System.Windows.Forms;
using DVLD___Logic_Layer;

namespace DVLD
{

    public partial class frmUpdateTestType : Form
    {
        private int _TestTypeID;
        private clsTestTypes _TestType;
        public frmUpdateTestType(int TestTypeID)
        {
            InitializeComponent();

            _TestTypeID = TestTypeID;
        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        public void _LoadData()
        {
            _TestType = clsTestTypes.FindTestTypeByID(_TestTypeID);

            lblID.Text = _TestTypeID.ToString();
            tbTitel.Text = _TestType.TestTypeTitel;
            tbDescription.Text = _TestType.TestTypeDescription;
            tbFees.Text = _TestType.TestTypeFees.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _TestType.TestTypeTitel = tbTitel.Text;
            _TestType.TestTypeDescription = tbDescription.Text;
            _TestType.TestTypeFees = decimal.Parse(tbFees.Text);

            if (_TestType.Save())
            {
                MessageBox.Show("Test Type Updated Successfully", "Test Type Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Test Type Update Falid", "Test Type Update Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
