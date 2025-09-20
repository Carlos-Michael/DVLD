using DVLD___Logic_Layer;
using System;
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

            lblPersonID.Text = PersonID.ToString();
            lblName.Text = _Person.FirstName + " " + _Person.SecondName + " " + _Person.ThirdName + " " + _Person.LastName;
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
