using DVLD___Logic_Layer;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmPeople : Form
    {
        public frmPeople()
        {
            InitializeComponent();
        }
        
        private static DataTable _dtAllPeople = clsPeople.GetAllPeople();
      
        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName", "LastName"
            , "GendorCaption", "DateOfBirth", "Nationalty", "Phone", "Email");

        private void _RefreshPeople()
        {
            dgvPeople.DataSource = _dtPeople;

            if (dgvPeople.ColumnCount > 0)
            {
                dgvPeople.Columns[0].HeaderText = "Person ID";

                dgvPeople.Columns[1].HeaderText = "National No";

                dgvPeople.Columns[2].HeaderText = "First Name";
                
                dgvPeople.Columns[3].HeaderText = "Second Name";
                
                dgvPeople.Columns[4].HeaderText = "Third Name";
                
                dgvPeople.Columns[5].HeaderText = "Last Name";
                
                dgvPeople.Columns[6].HeaderText = "Gendor";
                
                dgvPeople.Columns[7].HeaderText = "DateOfBirth";
                
                dgvPeople.Columns[8].HeaderText = "Nationality";
                
                dgvPeople.Columns[9].HeaderText = "Phone";
                
                dgvPeople.Columns[10].HeaderText = "Email";
            }
            lblRecords.Text = dgvPeople.RowCount.ToString();
        }

        private void frmPeople_Load(object sender, EventArgs e)
        {
            _RefreshPeople();
            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilterBy.Visible = (cbFilter.Text != "None");
        }
        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            string ColumnFilter;
            switch (cbFilter.Text) 
            {
                case "Person ID":
                    ColumnFilter = "PersonID";
                    break;
                case "National No":
                    ColumnFilter = "NationalNo";
                    break;
                case "First Name":
                    ColumnFilter = "FirstName";
                    break;
                case "Second Name":
                    ColumnFilter = "SecondName";
                    break;
                case "Third Name":
                    ColumnFilter = "ThirdName";
                    break;
                case "Last Name":
                    ColumnFilter = "LastName";
                    break;                
                case "Nationality":
                    ColumnFilter = "Nationality";
                    break;
                case "Phone":
                    ColumnFilter = "Phone";
                    break;
                case "Email":
                    ColumnFilter = "Email";
                    break;
                default:
                    ColumnFilter = "None";
                    break;
            }

            if (tbFilterBy.Text == "" || ColumnFilter == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRecords.Text = _dtPeople.Rows.Count.ToString();
                return;
            }

            if (ColumnFilter == "PersonID")
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnFilter, tbFilterBy.Text);
            }
            else
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", ColumnFilter, tbFilterBy.Text);
            }
            lblRecords.Text = _dtPeople.Rows.Count.ToString();

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Form frmAddPerson = new frmAddEditPerson(-1);
            frmAddPerson.ShowDialog();
            _RefreshPeople();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ShowPersonInfo = new frmShowPersonInfo((int)dgvPeople.CurrentRow.Cells[0].Value);
            ShowPersonInfo.ShowDialog();
            _RefreshPeople();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmAddPerson = new frmAddEditPerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            frmAddPerson.ShowDialog();
            _RefreshPeople();
            
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmAddPerson = new frmAddEditPerson(-1);
            frmAddPerson.ShowDialog();
            _RefreshPeople();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure Do You Want To Delete This Person ?", "Delete Person", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (clsPeople.DeletePerson((int)dgvPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully", "Person Deleted ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Person Delete Faild", "Person Delete Faild ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                _RefreshPeople();
            }
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tbFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Person ID")
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }
    }
}
