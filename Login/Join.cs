using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{

    public partial class JOIN : Form
    {
        public Person person;
   
        public JOIN()
        {
            InitializeComponent();
        }

        private bool f_writer(string filepath)
        {
            FileStream fstream = File.Open(filepath, FileMode.Append);
            StringBuilder sPerson_Info = new StringBuilder();

            if (fstream == null)
            {
                MessageBox.Show("file open failed");
                return false;
            }

            StreamWriter writer = new StreamWriter(fstream);
            
            sPerson_Info.Append( 
                  NAME_BOX.Text + " " 
                + AGE_BOX.Text + " "
                + ID_BOX.Text + " " 
                + EMAIL_BOX.Text + " "
                + PW_BOX.Text + " ");

            writer.WriteLine(sPerson_Info);
            
            writer.Close();
            fstream.Close();
            return true;

        }

        public bool f_reader(string filepath)
        {
            FileStream fstream = File.Open(filepath, FileMode.OpenOrCreate);
            String[] Temp_line;
            char[] Token = {' '};
            if ( fstream == null ) 
            {
                MessageBox.Show("file open failed");
                fstream.Close();
                return false;
            }

            StreamReader reader = new StreamReader(fstream);

            while(!reader.EndOfStream) // ID중복 체크
            {
                Temp_line = reader.ReadLine().Split(Token);
                if(Temp_line[2].Equals( ID_BOX.Text ) )
                {
                    MessageBox.Show("아이디가 중복 되었습니다.");
                    reader.Close();
                    fstream.Close();
                    return false;
                }
            }

            reader.Close();
            fstream.Close();
            return true;

        }
        public bool f_reader(string filepath, string sID, string sPW ) // 회원 정보 유무 체크
        {
            FileStream fstream = File.Open(filepath, FileMode.OpenOrCreate);
            String[] Temp_line;
            char[] Token = { ' ' };
            if (fstream == null)
            {
                MessageBox.Show("file open failed");
                return false;
            }

            StreamReader reader = new StreamReader(fstream);
            
            while (!reader.EndOfStream) 
            {
                Temp_line = reader.ReadLine().Split(Token);
                if (Temp_line[2].Equals(sID))
                {
                    if (Temp_line[4].Equals(sPW))
                    {
                        person = new Person(Temp_line);
                        reader.Close();
                        fstream.Close();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("비밀번호가 틀렸습니다.");
                        reader.Close();
                        fstream.Close();
                        return false;
                    }
                }
            }
            
            MessageBox.Show("아이디가 존재하지 않습니다.");
            reader.Close();
            fstream.Close();
            return false;

        }
        private void Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                bool overcheck = f_reader("member_data.txt");

                if( overcheck == true )
                {
                    bool filecheck = f_writer("member_data.txt");
                    if (filecheck == true)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                } 
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "[ERROR]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }

    public class Person
    {
        private string sName;
        private string sAge;
        private string sID;
        private string sPW;
        private string sEmail;

        public string Name
        {
            get
            {
                return this.sName;
            }
            set
            {
                sName = value;
            }
        }

        public string Age
        {
            get
            {
                return this.sAge;
            }
            set
            {
                sAge = value;
            }
        }

        public string ID
        {
            get
            {
                return this.sID;
            }
            set
            {
                sID = value;
            }
        }

        public string PW
        {
            get
            {
                return this.sPW;
            }
            set
            {
                sPW = value;
            }
        }

        public string EMAIL
        {
            get
            {
                return this.sEmail;
            }
            set
            {
                sEmail = value;
            }
        }

        public Person(String[] Temp)
        {
            this.Name   = Temp[0];
            this.Age    = Temp[1];
            this.ID     = Temp[2];
            this.EMAIL  = Temp[3];
            this.PW     = Temp[4];
        }
    }
}
