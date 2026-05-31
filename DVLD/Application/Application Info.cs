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
    public partial class Application_Info : UserControl
    {
        private clsApplication _Application;
        private clsPeople _Person;
        public Application_Info()
        {
            InitializeComponent();
        }

        public void SetData(int ApplicationID)
        {

            _Application = clsApplication.FindApplicationByID(ApplicationID);
            _Person = clsPeople.FindWithPersonID(_Application.ApplicantPersonID);

            _LoadData();
        }
        private void _LoadData()
        {
            lblID.Text = _Application.ApplicationID.ToString();
            lblFees.Text = _Application.PaidFees.ToString();
            lblApplicant.Text = _Application.ApplicantPersonID.ToString();
            lblDate.Text = _Application.ApplicationDate.ToString();
            lblStatusDate.Text = _Application.LastStatusDate.ToString();
            lblType.Text = clsApplicationTypes.FindAppliationTypeByID( _Application.ApplicationTypeID).ApplicationTypeTitel;
            lblApplicant.Text = _Person.FirstName + ' ' + _Person.SecondName + ' ' + _Person.ThirdName + ' ' + _Person.LastName;
            lblCreatedBy.Text = clsUser.FindUserWithUserID(_Application.CreatedByUserID).Username;
            lblStatus.Text = _Application.ApplicationStatus.ToString();
        }

        private void lblPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo showPersonInfo = new frmShowPersonInfo(_Person.PersonID);
            showPersonInfo.ShowDialog();
        }
    }
}
