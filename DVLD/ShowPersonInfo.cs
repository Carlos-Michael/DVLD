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
    public partial class ShowPersonInfo : UserControl
    {
        static public int PersonID;
        private clsPeople _Person;

        public ShowPersonInfo()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {

            _Person = clsPeople.FindWithPersonID(PersonID);

            lblName.Text = _Person.FirstName;
            lblNationalNo.Text = _Person.NationalNo;
            
            if (_Person.Gender == 0)
            {
                lblGendor.Text = "Male";
            }
            else if (_Person.Gender == 1)
            {
                lblGendor.Text = "Female";
            }
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lblPhone.Text = _Person.Phone;
            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
            lblCountry.Text = clsCountry.Find(_Person.CountryID).CountryName;
            if (_Person.ImagePath != null)
            {
                pbImage.ImageLocation = _Person.ImagePath;
            }
        }

        private void ShowPersonInfo_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void lblEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form Edit = new frmAddEditPerson(PersonID);
            Edit.ShowDialog();
        }
    }
}
