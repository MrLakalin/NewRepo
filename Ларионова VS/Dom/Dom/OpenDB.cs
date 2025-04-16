using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dom
{
    public partial class OpenDB : Form
    {
        public OpenDB()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Kvartiry newform = new Kvartiry();
            newform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Vid_oplat newform1 = new Vid_oplat();
            newform1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Oplata newform2 = new Oplata();
            newform2.Show();
        }
    }
}
