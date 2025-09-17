using DVLD___Logic_Layer;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmAddEditPerson : Form
    {

        
        private enum _enMode { AddNew = 0, Edit = 1 }
        private _enMode _Mode;
        private int _PersonID;
        private clsPeople _Person;

        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();
            
            _PersonID = PersonID;

            if (PersonID == -1)
            {
                _Mode = _enMode.AddNew;
                lblMode.Text = "Add New Person";
                lblPersonID.Text = "??";
            }
            else
            {
                _Mode = _enMode.Edit;
                lblMode.Text = "Update Person Info";
                lblPersonID.Text = PersonID.ToString();
            }

            _LoadData();
            openFileDialog1.Filter = "Image Files | *.png; *.jpg; *.jpeg";
            dateTimePicker1.MaxDate = DateTime.Now.AddYears(-18);
            cbCountry.SelectedText = "Egypt";
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
            _Person = clsPeople.FindWithPersonID(_PersonID);

            tbFirstName.Text = _Person.FirstName;
            tbSecondName.Text = _Person.SecondName;
            tbThirdName.Text = _Person.ThirdName;
            tbLastName.Text = _Person.LastName;
            tbNationalNo.Text = _Person.NationalNo;
            if (_Person.Gender == 0)
            {
                rbMale.Checked = true;
            }
            else if (_Person.Gender == 1)
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
                _Person.Gender = 0;
            }
            else if (rbFemale.Checked)
            {
                _Person.Gender = 1;
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
                if (_Mode == _enMode.AddNew)
                {
                    File.Copy(openFileDialog1.FileName, ImageName);
                }
            }
            else
            {
                MessageBox.Show("Person Save Faild", "Person Save Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

       
        private void MouseLeave(object sender, CancelEventArgs e)
        {
            if (sender == tbEmail && !tbEmail.Text.Contains("@"))
            {
                errorProvider1.SetError((MaskedTextBox)sender, "Wrong Email Format");
                return;
            }
            else if (sender == tbEmail && tbEmail.Text.Contains("@"))
            {
                errorProvider1.SetError((Control)sender, "");
            }
            if (sender == tbNationalNo && clsPeople.IsExist(tbNationalNo.Text))
            {
                errorProvider1.SetError((MaskedTextBox)sender, "National Number Is Exist");
            }
            else if (string.IsNullOrWhiteSpace(((Control)sender).Text))
            {
                errorProvider1.SetError((Control)sender, "Field Is Requierd");
            }
            else
            {
                errorProvider1.SetError((Control)sender, "");
            }
        }

        private void lblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.FileName = "";
            pbImage.Image = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbMale_CheckedChanged_1(object sender, EventArgs e)
        {
            if (pbImage.ImageLocation == "")
            { 
                if (sender == rbMale)
                {
                    pbImage.Image = Properties.Resources.Male_512;
                
                }   
                else if(sender == rbFemale)
                {
                    pbImage.Image = Properties.Resources.Female_512;
                }
            }
        }
    }
}
