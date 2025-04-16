using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.PolzovatelDBTableAdapters;

namespace WindowsFormsApp1
{
    public partial class Kypit : Form
    {
        public Kypit()
        {
            InitializeComponent();
            SetRoundedCorners(panel1, 20);
        }
        private void SetRoundedCorners(Panel panel, int radius)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddArc(0, 0, radius * 2, radius * 2, 180, 90); // Верхний левый угол
            graphicsPath.AddArc(panel.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90); // Верхний правый угол
            graphicsPath.AddArc(panel.Width - radius * 2, panel.Height - radius * 2, radius * 2, radius * 2, 0, 90); // Нижний правый угол
            graphicsPath.AddArc(0, panel.Height - radius * 2, radius * 2, radius * 2, 90, 90); // Нижний левый угол
            graphicsPath.CloseFigure();

            panel.Region = new Region(graphicsPath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow newUserRow = polzovatelDB.Пользователь.NewRow();
            newUserRow[1] = textBox1.Text;
            newUserRow[2] = textBox2.Text;
            newUserRow[3] = textBox3.Text;
            polzovatelDB.Пользователь.Rows.Add(newUserRow);
            ПользовательBindingSource.ResetBindings(false);
            Validate();
            ПользовательBindingSource.EndEdit();
            ПользовательTableAdapter.Update(polzovatelDB.Пользователь);
            MessageBox.Show("Пользователь успешно добавлен!");
        }
    }
}
