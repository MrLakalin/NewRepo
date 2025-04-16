using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Instalyazya : Form
    {
        public Instalyazya()
        {
            InitializeComponent();
        }

        private void Instalyazya_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "instalyazyaDB.Инсталляция". При необходимости она может быть перемещена или удалена.
            this.инсталляцияTableAdapter.Fill(this.instalyazyaDB.Инсталляция);
        }
    }
}
