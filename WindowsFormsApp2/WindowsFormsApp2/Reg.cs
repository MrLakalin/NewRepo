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

namespace WindowsFormsApp2
{
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var form3 = new Vxod();
            form3.Closed += (s, args) => this.Close();
            form3.Show();
        }

        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\Users\MrLak\OneDrive\Рабочий стол\PO\PhoneDB.accdb;Persist Security Info=False;";

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка на пустые поля
                if (string.IsNullOrEmpty(maskedTextBox1.Text) ||
                    string.IsNullOrEmpty(textBox1.Text) ||
                    string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Проверка совпадения паролей
                if (textBox1.Text != textBox2.Text)
                {
                    MessageBox.Show("Пароли не совпадают!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = "INSERT INTO Users (PhoneNumber, [Password]) VALUES (@PhoneNumber, @Password)";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PhoneNumber", maskedTextBox1.Text);
                        command.Parameters.AddWithValue("@Password", textBox1.Text);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Вы успешно зарегистрировались!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            var form3 = new Vxod();
                            form3.Closed += (s, args) => this.Close();
                            form3.Show();
                        }
                        else
                        {
                            MessageBox.Show("Не удалось сохранить данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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