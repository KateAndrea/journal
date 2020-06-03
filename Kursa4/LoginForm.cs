using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursa4
{
    public partial class LoginForm : Form
    {
        char user;
        string pass;
        int phone;
        int id;
        public LoginForm()
        {
            InitializeComponent();

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            button1.Visible = false; 
            label1.Visible = false; label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false;
            textBox1.Visible = false; textBox2.Visible = false;
            comboBox1.Visible = false; comboBox2.Visible = false; comboBox3.Visible = false;
            for (int i = 1; i < 5; i++)
            {
                comboBox2.Items.Add(i);
                comboBox3.Items.Add(i);
            }
            MySqlConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            try
            {
                MySqlCommand command = connection.CreateCommand();
                    command.CommandText = $"Select * from specialties";
                MySqlDataReader mySqlDataReader = command.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    comboBox1.Items.Add($"{mySqlDataReader["ab_spec"].ToString()}");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string surname = textBox1.Text;
            MessageBox.Show(user.ToString());
            if (user=='d' || user == 't' || user == 's' || user=='c')
            {
                if (user == 'd' && textBox2.Text == "")
                    MessageBox.Show("Enter your password");
                else
                {
                    if ((user == 't' || user == 's' || user == 'c') && textBox1.Text == "" && textBox2.Text == "")
                        MessageBox.Show("Введіть ваш номер телефону і пароль", "Message");
                    else if (textBox2.Text == "")
                        MessageBox.Show("Enter your password");
                    else
                        if ((user == 't' || user == 's' || user == 'c') && textBox1.Text == "")
                        MessageBox.Show("Enter your surname");
                    else
                    {
                        MySqlConnection connection = DBUtils.GetDBConnection();
                        connection.Open();
                        try
                        {
                            MySqlCommand command = connection.CreateCommand();

                            if (user == 't' || user == 'c')
                                command.CommandText = $"Select * from teachers where surname = \"{surname}\"";
                            if (user == 's')
                                command.CommandText = $"Select * from students where surname = \"{surname}\"";
                            MySqlDataReader mySqlDataReader = command.ExecuteReader();
                            while (mySqlDataReader.Read())
                            {
                                pass = $"{mySqlDataReader["password"].ToString()}";
                                id = int.Parse($"{mySqlDataReader["id"].ToString()}");
                            }
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show(exc.Message);
                        }
                        finally
                        {
                            connection.Close();
                        }
                        if (id == 0)
                            MessageBox.Show("Wrong surname");
                        else if (pass != textBox2.Text)
                            MessageBox.Show("Wrong password");
                        else
                        {
                            if (user == 'd')
                            {

                            }
                            if (user == 't') ;
                            if (user == 's')
                            {
                                Student student = new Student();
                                student.ShowDialog();
                            }
                        }

                    }
                }
            }
            else MessageBox.Show("Choose user");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        int p = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (p % 2 == 0)
                textBox2.UseSystemPasswordChar = false;
            else
                textBox2.UseSystemPasswordChar = true;
            p++;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Visible = false;
            label1.Visible = false; label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false;
            textBox1.Visible = false; textBox2.Visible = false;
            comboBox1.Visible = false; comboBox2.Visible = false; comboBox3.Visible = false;
            user = 'd';
            label3.Visible = true;
            textBox2.Visible = true;
            button1.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = false; label4.Visible = false; label5.Visible = false;
            textBox1.Visible = false;
            comboBox1.Visible = false; comboBox2.Visible = false; comboBox3.Visible = false;
            user = 't';
            label1.Visible = true;
            textBox1.Visible = true;
            label3.Visible = true;
            textBox2.Visible = true;
            button1.Visible = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = false; label4.Visible = false; label5.Visible = false;
            textBox1.Visible = false;
            comboBox1.Visible = false; comboBox2.Visible = false; comboBox3.Visible = false;
            user = 's';
            label1.Visible = true;
            textBox1.Visible = true;
            label3.Visible = true;
            textBox2.Visible = true;
            button1.Visible = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            user = 'c';
            button1.Visible = true;
            label1.Visible = true; label2.Visible = true; label3.Visible = true; label4.Visible = true; label5.Visible = true;
            textBox1.Visible = true; textBox2.Visible = true;
            comboBox1.Visible = true; comboBox2.Visible = true; comboBox3.Visible = true;
        }

    }
}
