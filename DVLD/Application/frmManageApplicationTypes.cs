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
    public partial class frmManageApplicationTypes : Form
    {
        DataTable dtAllApplicationTypes = clsApplicationTypes.GetApplicationTypes();
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void _Refresh()
        {
            dgvApplicationTypes.DataSource = dtAllApplicationTypes;

            if (dgvApplicationTypes.ColumnCount > 0)
            {
                dgvApplicationTypes.Columns[0].HeaderText = "ID";
                dgvApplicationTypes.Columns[1].HeaderText = "Titel";
                dgvApplicationTypes.Columns[2].HeaderText = "Fees";
            }
            lblRecords.Text = dgvApplicationTypes.RowCount.ToString();
        }
        private void frmManageApplicationTyps_Load(object sender, EventArgs e)
        {
            _Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateApplicationType updateApplicationType = new frmUpdateApplicationType((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);
            updateApplicationType.ShowDialog();
            _Refresh();
        }
    }
}
