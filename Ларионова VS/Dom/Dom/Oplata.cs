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
    public partial class Oplata : Form
    {
        public Oplata()
        {
            InitializeComponent();
        }

        private void Oplata_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "opalataDB.Оплаты". При необходимости она может быть перемещена или удалена.
            this.оплатыTableAdapter.Fill(this.opalataDB.Оплаты);

        }
    }
}
