using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DVLD___Logic_Layer;


namespace DVLD
{
    public partial class ShowUserInfoWithFilter : UserControl
    {
        private int _PersonID;
        clsUser User;


        public ShowUserInfoWithFilter()
        {
            InitializeComponent();
        }

        private DataTable _Search()
        {
            switch (cbFilter.SelectedItem.ToString())
            {
                case "National No":
                    return (clsPeople.GetPeopleWithNationalNo(mtbFilter.Text));

                case "PersonID":
                    return (clsPeople.GetPeopleWithPersonID(mtbFilter.Text));


                default:
                    return null;

            }

        }
        
        private void SetPerson(object Sender, int PersonID)
        {
            showPersonInfo1.SetData(PersonID);
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            _PersonID = (int)_Search().Rows[0][0];
            SetPerson(this, _PersonID);
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFilter.SelectedItem.ToString())
            {
                case "National No":
                    mtbFilter.Visible = true;
                    break;
                case "PersonID":
                    mtbFilter.Visible = true;
                    mtbFilter.Mask = "099999";
                    break;
                case "None":
                    mtbFilter.Visible = false;
                    break;
            }

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddEditPerson AddPerson = new frmAddEditPerson(-1);
            AddPerson.DataBack += SetPerson;
            AddPerson.ShowDialog();


        }


    }
}
