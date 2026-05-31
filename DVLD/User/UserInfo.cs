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
    public partial class UserInfo : UserControl
    {
        private int _UserID;
        private clsUser _User;
        public UserInfo()
        {
            InitializeComponent();
        }

        public void SetData(int UserID)
        {
            _UserID = UserID;
            _LoadData();
        }

        private void _LoadData()
        {
            _User = clsUser.FindUserWithUserID(_UserID);

            lblUserID.Text = _UserID.ToString();
            lblUsername.Text = _User.Username;
            lblIsActive.Text = (_User.IsActive) ? "True" : "False";

        }
    }
}
