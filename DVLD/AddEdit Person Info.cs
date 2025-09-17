using System;
using System.Windows.Forms;
using DVLD___Logic_Layer;
using System.Data;
using System.IO;
using System.ComponentModel;
using System.Globalization;

namespace DVLD
{
    public partial class AddEdit_Person_Info : UserControl
    {
        private enum _enMode { AddNew = 0, Edit = 1 }
        private _enMode _Mode;
        public static int PersonID;
        private clsPeople _Person;

        public AddEdit_Person_Info()
        {
            InitializeComponent();

        }

        private void _FillCountries()
        {
            DataTable dt = clsCountry.GetAllCountries();

            foreach (DataRow row in dt.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
        }

        private void _LoadData()
        {
            _FillCountries();

            if (_Mode == _enMode.AddNew)
            {
                _Person = new clsPeople();
                return;
            }
            _Person = clsPeople.FindWithPersonID(PersonID);

            tbFirstName.Text = _Person.FirstName;
            tbSecondName.Text = _Person.SecondName;
            tbThirdName.Text = _Person.ThirdName;
            tbLastName.Text = _Person.LastName;
            tbNationalNo.Text = _Person.NationalNo;
            if (_Person.Gender == 1)
            {
                rbMale.Checked = true;
            }
            else if (_Person.Gender == 0)
            { 
                rbFemale.Checked = true;

            }
            dateTimePicker1.Value = _Person.DateOfBirth;
            tbPhone.Text = _Person.Phone;
            tbEmail.Text = _Person.Email;
            tbAddress.Text = _Person.Address;
            cbCountry.SelectedIndex = cbCountry.FindString(clsCountry.Find(_Person.CountryID).CountryName);
            if (_Person.ImagePath != null)
            {
                pbImage.ImageLocation = _Person.ImagePath;
                lblRemove.Visible = true;
            }
        }
        private void AddEdit_Person_Info_Load(object sender, EventArgs e)
        {
            if (PersonID == -1)
            {
                _Mode = _enMode.AddNew;
            }
            else
            {
                _Mode = _enMode.Edit;
            }

            _LoadData();
            openFileDialog1.Filter = "Image Files | *.png; *.jpg; *.jpeg";
            dateTimePicker1.MaxDate = DateTime.Now.AddYears(-18);
            
        }

        private void lblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbImage.ImageLocation = openFileDialog1.FileName;
                lblRemove.Visible = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Person.FirstName = tbFirstName.Text;
            _Person.SecondName = tbSecondName.Text;
            _Person.ThirdName = tbThirdName.Text;
            _Person.LastName = tbLastName.Text;
            _Person.NationalNo = tbNationalNo.Text;
            if (rbMale.Checked)
            {
                _Person.Gender = 1;
            }
            else if (rbFemale.Checked)
            {
                _Person.Gender = 0;
            }
            _Person.DateOfBirth = dateTimePicker1.Value;
            _Person.Phone = tbPhone.Text;
            _Person.Email = tbEmail.Text;
            _Person.Address = tbAddress.Text;
            _Person.CountryID = clsCountry.Find(cbCountry.Text).CountryID;
            string ImageName = _Person.ImagePath;
            if (openFileDialog1.FileName != "")
            {
                if (_Mode == _enMode.Edit)
                {
                    File.Delete(ImageName);
                }
                ImageName = @"F:\development\C#\DVLD\DVLD Image\" + Guid.NewGuid().ToString() + Path.GetExtension(openFileDialog1.FileName);
            }
            _Person.ImagePath = ImageName;
            if (_Person.Save())
            {
                MessageBox.Show("Person Saved successfully", "Person Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                File.Copy(openFileDialog1.FileName, ImageName);
            }
            else
            {
                MessageBox.Show("Person Save Faild", "Person Save Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == rbMale)
            {
                pbImage.Image = Properties.Resources.Male_512;
            }
            else if (sender == rbFemale)
            {
                pbImage.Image = Properties.Resources.Female_512;
            }
        }

        
        private void MouseLeave(object sender, CancelEventArgs e)
        {
            if (sender == tbEmail && !tbEmail.Text.Contains("@"))
            {
                errorProvider1.SetError((MaskedTextBox)sender, "Wrong Email Format");
                return;
            }
            if (string.IsNullOrWhiteSpace(((Control)sender).Text))
            {
                errorProvider1.SetError((Control)sender, "Field Is Requierd");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
