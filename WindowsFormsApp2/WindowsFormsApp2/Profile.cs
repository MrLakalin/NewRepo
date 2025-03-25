using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }
        public Profile(string phoneNumber, string password) : this()
        {
            label3.Text = phoneNumber;
            label5.Text = password;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form1 = new Nachalo();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
