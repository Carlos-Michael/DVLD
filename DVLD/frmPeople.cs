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

        private void _UpdatePeople(DataTable dt)
        {
            dgvPeople.DataSource = dt;
            lblRecords.Text = dgvPeople.RowCount.ToString();
        }

        private void frmPeople_Load(object sender, EventArgs e)
        {
            _UpdatePeople(clsPeople.GetAllPeople());
            cbFilter.SelectedIndex = 0;
        }

        private void _Filter()
        {
            switch (cbFilter.SelectedItem.ToString())
            {
                case "National No":
                    _UpdatePeople(clsPeople.GetPeopleWithNationalNo(mtbFilter.Text));
                    break;

                case "PersonID":
                    _UpdatePeople(clsPeople.GetPeopleWithPersonID(mtbFilter.Text));
                    break;

                case "First Name":
                    _UpdatePeople(clsPeople.GetPeopleWithFirstName(mtbFilter.Text));
                    break;

                case "Second Name":
                    _UpdatePeople(clsPeople.GetPeopleWithSecondName(mtbFilter.Text));
                    break;

                case "Third Name":
                    _UpdatePeople(clsPeople.GetPeopleWithThirdName(mtbFilter.Text));
                    break;

                case "Last Name":
                    _UpdatePeople(clsPeople.GetPeopleWithLastName(mtbFilter.Text));
                    break;

                case "Gendor":
                    _UpdatePeople(clsPeople.GetPeopleWithGender(mtbFilter.Text));
                    break;

                case "Address":
                    _UpdatePeople(clsPeople.GetPeopleWithAddress(mtbFilter.Text));
                    break;

                case "Phone":
                    _UpdatePeople(clsPeople.GetPeopleWithPhone(mtbFilter.Text));
                    break;

                case "Email":
                    _UpdatePeople(clsPeople.GetPeopleWithEmail(mtbFilter.Text));
                    break;

                case "Nationalty":
                    _UpdatePeople(clsPeople.GetPeopleWithNationalty(mtbFilter.Text));
                    break;

                default:
                    break;
            }

            if (mtbFilter.Text == "")
            {
                _UpdatePeople(clsPeople.GetAllPeople());
            }
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TextMask = "L?????";
            string NumbrsMask = "099999";

            switch (cbFilter.SelectedItem.ToString())
            {
                case "None":
                    mtbFilter.Visible = false;
                    _UpdatePeople(clsPeople.GetAllPeople());
                    break;

                case "National No":
                    mtbFilter.Visible = true;
                    mtbFilter.Mask = "";
                    break;

                case "PersonID":
                    mtbFilter.Visible = true;
                    mtbFilter.Mask = NumbrsMask;
                    break;

                case "First Name":
                case "Second Name":
                case "Third Name":
                case "Last Name":
                case "Address":
                case "Email":
                case "Nationalty":
                    mtbFilter.Visible = true;
                    mtbFilter.Mask = TextMask;
                    break;

                case "Phone":
                    mtbFilter.Visible = true;
                    mtbFilter.Mask = "00000009999";
                    break;

                default:
                    mtbFilter.Visible = false;
                    break;
            }

        }

        private void mtbFilter_TextChanged(object sender, EventArgs e)
        {
            _Filter();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frmAddPerson = new frmAddEditPerson(-1);
            frmAddPerson.ShowDialog();
            _UpdatePeople(clsPeople.GetAllPeople());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ShowPersonInfo = new frmShowPersonInfo((int)dgvPeople.CurrentRow.Cells[0].Value);
            ShowPersonInfo.ShowDialog();
            _UpdatePeople(clsPeople.GetAllPeople());

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmAddPerson = new frmAddEditPerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            frmAddPerson.ShowDialog();
            _UpdatePeople(clsPeople.GetAllPeople());
            
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmAddPerson = new frmAddEditPerson(-1);
            frmAddPerson.ShowDialog();
            _UpdatePeople(clsPeople.GetAllPeople());
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
                _UpdatePeople(clsPeople.GetAllPeople());
            }
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
