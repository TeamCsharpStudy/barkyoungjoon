using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
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

        private void LOG_IN_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            Form_new form_new = new Form_new();
            DialogResult dlgResult = login.ShowDialog();

            if (dlgResult == DialogResult.OK)
            {
                
                this.Hide();
                form_new.Closed += (s, args) => this.Close();
                form_new.Show();
            }
        }

    }
}
