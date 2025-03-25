using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Vxod : Form
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\Users\MrLak\OneDrive\Рабочий стол\PO\PhoneDB.accdb;Persist Security Info=False;";
        public Vxod()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var form4 = new Reg();
            form4.Closed += (s, args) => this.Close();
            form4.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(maskedTextBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string phoneNumber = maskedTextBox1.Text;
                string password = textBox2.Text;

                string query = "SELECT COUNT(*) FROM Users WHERE PhoneNumber = @PhoneNumber AND [Password] = @Password";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@Password", password);

                        int count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                            if (phoneNumber == "+7(111)111-1111" && password == "1")
                            {
                                MessageBox.Show("Вы вошли в профиль!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                var form2 = new YProdavca(phoneNumber, password);
                                form2.Closed += (s, args) => this.Close();
                                form2.Show();
                            }
                            else
                            {
                                MessageBox.Show("Вы вошли в профиль!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                var form5 = new YPokypatelya(phoneNumber, password);
                                form5.Closed += (s, args) => this.Close();
                                form5.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Неверный номер телефона или пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
