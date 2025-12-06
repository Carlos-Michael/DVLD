using DVLD;
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
using DVLD___Logic_Layer;
namespace DVLD
{
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void _Refresh()
        {
            dgvTestTypes.DataSource =  clsTestTypes.GetTestTypes();
            lblRecords.Text = dgvTestTypes.RowCount.ToString();
        }
        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTestType updateTestType = new frmUpdateTestType((int)dgvTestTypes.CurrentRow.Cells[0].Value);
            updateTestType.ShowDialog();
            _Refresh();
        }
    }
}
