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
    public partial class Vid_oplat : Form
    {
        public Vid_oplat()
        {
            InitializeComponent();
        }

        private void Vid_oplat_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "vidoplatDB.Виды_оплаты". При необходимости она может быть перемещена или удалена.
            this.виды_оплатыTableAdapter.Fill(this.vidoplatDB.Виды_оплаты);

        }
    }
}
