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
    public partial class ShowPersonInfoWithFilter : UserControl
    {
        public int PersonID { get; set; }
        public ShowPersonInfoWithFilter()
        {
            InitializeComponent();
        }

        private void ShowPersonInfoWithFilter_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFilter.SelectedItem.ToString())
            {
                case "PersonID":
                    mtbFilter.Visible = true;
                    mtbFilter.Mask = "099999";
                    break;
                case "National No":
                    mtbFilter.Visible = true;
                    mtbFilter.Mask = "";
                    break;
                case "None":
                    mtbFilter.Visible = false;
                    break;


            }
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            if (mtbFilter.Text != "")
            {
                int personID;
                switch (cbFilter.SelectedItem.ToString())
                {

                    case "PersonID":
                        if (int.TryParse(mtbFilter.Text, out personID) && clsPeople.IsExistWithPersonID(personID))
                        {
                            PersonID = personID;
                        }
                        else 
                        {
                            MessageBox.Show("Enter Correct Info", "Wrong Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                            showPersonInfo1.SetData(PersonID);
                        break;
                    case "National No":
                        if (int.TryParse(clsPeople.GetPeopleWithNationalNo(mtbFilter.Text).Rows[0][0].ToString(), out personID) && clsPeople.IsExistWithPersonID(personID))
                        { 
                            PersonID = personID;
                        }
                        else 
                        {
                            MessageBox.Show("Enter Correct Info", "Wrong Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                            showPersonInfo1.SetData(PersonID);
                        break;
                    case "None":
                        break;

                }
            }
            else 
            {
                MessageBox.Show("Enter PersonID Or NationalNo First", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddEditPerson AddPerson = new frmAddEditPerson(-1);
            AddPerson.DataBack += showPersonInfo1.SetData;
            AddPerson.ShowDialog();

        }

        public void Update(int PersonID)
        {
            gbFilter.Enabled = false;
            cbFilter.SelectedIndex = 1;
            mtbFilter.Text = PersonID.ToString();
            showPersonInfo1.SetData(PersonID);
        }

    }
}