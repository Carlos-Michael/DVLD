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

            if (cbFilter.SelectedItem.ToString() == "National No")
            {
                _UpdatePeople(clsPeople.GetPeopleWithNationalNo(mtbFilter.Text));
            }
            else if (cbFilter.SelectedItem.ToString() == "PersonID")
            {
                _UpdatePeople(clsPeople.GetPeopleWithPersonID(mtbFilter.Text));
            }
            else if (cbFilter.SelectedItem.ToString() == "First Name")
            {
                _UpdatePeople(clsPeople.GetPeopleWithFirstName(mtbFilter.Text));
            }
            else if (cbFilter.SelectedItem.ToString() == "Second Name")
            {
                _UpdatePeople(clsPeople.GetPeopleWithSecondName(mtbFilter.Text));
            }
            else if (cbFilter.SelectedItem.ToString() == "Third Name")
            {
                _UpdatePeople(clsPeople.GetPeopleWithThirdName(mtbFilter.Text));
            }
            else if (cbFilter.SelectedItem.ToString() == "Last Name")
            {
                _UpdatePeople(clsPeople.GetPeopleWithLastName(mtbFilter.Text));
            }
            else if (cbFilter.SelectedItem.ToString() == "Gendor")
            {
                _UpdatePeople(clsPeople.GetPeopleWithGender(mtbFilter.Text));
            }
            else if (cbFilter.SelectedItem.ToString() == "Address")
            {
                _UpdatePeople(clsPeople.GetPeopleWithAddress(mtbFilter.Text));
            }
            else if (cbFilter.SelectedItem.ToString() == "Phone")
            {
                _UpdatePeople(clsPeople.GetPeopleWithPhone(mtbFilter.Text));
            }
            else if (cbFilter.SelectedItem.ToString() == "Email")
            {
                _UpdatePeople(clsPeople.GetPeopleWithEmail(mtbFilter.Text));
            }
            else if (cbFilter.SelectedItem.ToString() == "Nationalty")
            {
                _UpdatePeople(clsPeople.GetPeopleWithNationalty(mtbFilter.Text));
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
            if (cbFilter.SelectedItem.ToString() == "None")
            {
                mtbFilter.Visible = false;
                _UpdatePeople(clsPeople.GetAllPeople());
            }
            else if (cbFilter.SelectedItem.ToString() == "National No")
            {
                mtbFilter.Visible = true;
                mtbFilter.Mask = "";
            }
            else if (cbFilter.SelectedItem.ToString() == "PersonID")
            {
                mtbFilter.Visible = true;
                mtbFilter.Mask = NumbrsMask;
            }
            else if (cbFilter.SelectedItem.ToString() == "First Name")
            {
                mtbFilter.Visible = true;
                mtbFilter.Mask = TextMask;
            }
            else if (cbFilter.SelectedItem.ToString() == "Second Name")
            {
                mtbFilter.Visible = true;
                mtbFilter.Mask = TextMask;
            }
            else if (cbFilter.SelectedItem.ToString() == "Third Name")
            {
                mtbFilter.Visible = true;
                mtbFilter.Mask = TextMask;
            }
            else if (cbFilter.SelectedItem.ToString() == "Last Name")
            {
                mtbFilter.Visible = true;
                mtbFilter.Mask = TextMask;
            }
            else if (cbFilter.SelectedItem.ToString() == "Address")
            {
                mtbFilter.Visible = true;
                mtbFilter.Mask = TextMask;
            }
            else if (cbFilter.SelectedItem.ToString() == "Phone")
            {
                mtbFilter.Visible = true;
                mtbFilter.Mask = "00000009999";
            }
            else if (cbFilter.SelectedItem.ToString() == "Email")
            {
                mtbFilter.Visible = true;
                mtbFilter.Mask = TextMask;
            }
            else if (cbFilter.SelectedItem.ToString() == "Nationalty")
            {
                mtbFilter.Visible = true;
                mtbFilter.Mask = TextMask;
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
            _UpdatePeople(clsPeople.GetAllPeople());
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
    }
}
