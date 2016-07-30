using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Login : Form
    {
        JOIN join = new JOIN();
        
        public Login()
        {
            InitializeComponent();
        }
        public string sID
        {
            get
            {
                return this.ID_Box.Text;
            }
            set
            {
                ID_Box.Text = value;
            }
        }
        public string sPASSWORD
        {
            get
            {
                return this.Password_Box.Text;
            }
            set
            {
                Password_Box.Text = value;
            }
        }
        private void OK_Click(object sender, EventArgs e)
        {
            try
            {
                if ( join.f_reader("member_data.txt",sID,sPASSWORD) )
                {
                    MessageBox.Show("ID :" + join.person.ID + "\r\nNAME :" + join.person.Name + "\r\nAGE : " + join.person.Age +
                        "\r\nEMAIL : " + join.person.EMAIL);
       
                    this.DialogResult = DialogResult.OK;
                    
                }
            }
            catch ( Exception ex )
            {
                MessageBox.Show(ex.Message, "[ERROR]", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Join_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = join.ShowDialog();
        }
    }
}
