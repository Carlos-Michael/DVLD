using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void peopleManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmPeople = new frmPeople();
            frmPeople.ShowDialog();
        }
    }
}
