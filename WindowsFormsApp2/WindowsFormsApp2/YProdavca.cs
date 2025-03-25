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
    public partial class YProdavca : Form
    {
        private string _phoneNumber;
        private string _password;
        public YProdavca(string phoneNumber, string password)
        {
            InitializeComponent();
            _phoneNumber = phoneNumber;
            _password = password;
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form6 = new Profile(_phoneNumber, _password);
            form6.Closed += (s, args) => this.Close();
            form6.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form6 = new Profile(_phoneNumber, _password);
            form6.Closed += (s, args) => this.Close();
            form6.Show();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form6 = new Profile(_phoneNumber, _password);
            form6.Closed += (s, args) => this.Close();
            form6.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
