using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;

namespace LegalHunt
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);
        public const int VK_RETURN = 0x0D;
        int questionsNumber = 1;
        SQLiteConnection dbConnection;

        public Form1()
        {
            InitializeComponent();
            Thread t = new Thread(new ThreadStart(startForm));
            t.Start();
            Thread.Sleep(3000);
            t.Abort();
        }

        private void startForm()
        {
            Application.Run(new SplaScreen());
        }
        private void Form1_Load(Object sender, EventArgs e)
        {
            button1.BackColor = ColorTranslator.FromHtml("#665338");
            button2.BackColor = ColorTranslator.FromHtml("#665338");
            button3.BackColor = ColorTranslator.FromHtml("#665338");
            button4.BackColor = ColorTranslator.FromHtml("#665338");
            richTextBox1.BackColor = ColorTranslator.FromHtml("#454545");
            //button1.BackColor = ColorTranslator.FromHtml("#2E942E");
            dbConnection = new SQLiteConnection("Data Source=./ExamExrcises.db;MultipleActiveResultSets=true");
            dbConnection.Open();
            richTextBox2.Text = questionsNumber.ToString();
            
            string sqlcommand = "SELECT question FROM [lh_qa_ca] WHERE _rowid_=" + questionsNumber;
            SQLiteCommand command = new SQLiteCommand(sqlcommand, dbConnection);
            SQLiteDataReader result = command.ExecuteReader();

            if (result.HasRows)
            {
                while (result.Read())
                {
                    string name = result.GetString(result.GetOrdinal("question"));
                    richTextBox1.Text = name;
                }
            }
            result.Close();
            //
            //button1
            //
            sqlcommand = "SELECT answer1 FROM [lh_qa_ca] WHERE _rowid_=" + questionsNumber;
            command = new SQLiteCommand(sqlcommand, dbConnection);
            result = command.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    string name = result.GetString(result.GetOrdinal("answer1"));
                    button1.Text = name;
                }
            }
            result.Close();
            //
            //button2
            //
            sqlcommand = "SELECT answer2 FROM [lh_qa_ca] WHERE _rowid_=" + questionsNumber;
            command = new SQLiteCommand(sqlcommand, dbConnection);
            result = command.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    string name = result.GetString(result.GetOrdinal("answer2"));
                    button2.Text = name;
                }
            }
            result.Close();
            //
            //button3
            //
            sqlcommand = "SELECT answer3 FROM [lh_qa_ca] WHERE _rowid_=" + questionsNumber;
            command = new SQLiteCommand(sqlcommand, dbConnection);
            result = command.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    string name = result.GetString(result.GetOrdinal("answer3"));
                    if (name != " ")
                        button3.Text = name;
                    else
                    {
                        button3.BackColor = Color.Transparent;
                        button3.Enabled = false;
                    }
                }
            }
            result.Close();
            //
            //button4
            //
            sqlcommand = "SELECT answer4 FROM [lh_qa_ca] WHERE _rowid_=" + questionsNumber;
            command = new SQLiteCommand(sqlcommand, dbConnection);
            result = command.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    string name = result.GetString(result.GetOrdinal("answer4"));
                    if (name != " ")
                        button4.Text = name;
                    else
                    {
                        button4.BackColor = Color.Transparent;
                        button4.Enabled = false;
                    }
                }
            }
            result.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            string sqlcommand = "SELECT correctanswer FROM [lh_qa_ca] WHERE _rowid_=" + questionsNumber;
            SQLiteCommand command = new SQLiteCommand(sqlcommand, dbConnection);
            SQLiteDataReader result = command.ExecuteReader();
            Int32 correctAnswer;
            //Color incorrect = (Color)ColorConverter.ConvertFromString("#F84545");

            if (result.Read())
            {
                correctAnswer = result.GetInt32(result.GetOrdinal("correctanswer"));
                if (correctAnswer == 1)
                    button1.BackColor = ColorTranslator.FromHtml("#2E942E");
                else
                    button1.BackColor = ColorTranslator.FromHtml("#F84545");
            } //if
        }//btn click

        private void button2_Click(object sender, EventArgs e)
        {
            
            string sqlcommand = "SELECT correctanswer FROM [lh_qa_ca] WHERE _rowid_=" + questionsNumber;
            SQLiteCommand command = new SQLiteCommand(sqlcommand, dbConnection);
            SQLiteDataReader result = command.ExecuteReader();
            Int32 correctAnswer;
            if (result.Read())
            {
                correctAnswer = result.GetInt32(result.GetOrdinal("correctanswer"));
                if (correctAnswer == 2)
                    button2.BackColor = ColorTranslator.FromHtml("#2E942E");
                else
                    button2.BackColor = ColorTranslator.FromHtml("#F84545");
            } //if
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            string sqlcommand = "SELECT correctanswer FROM [lh_qa_ca] WHERE _rowid_=" + questionsNumber;
            SQLiteCommand command = new SQLiteCommand(sqlcommand, dbConnection);
            SQLiteDataReader result = command.ExecuteReader();
            Int32 correctAnswer;
            if (result.Read())
            {
                if(button3.Text != " ")
                {
                    correctAnswer = result.GetInt32(result.GetOrdinal("correctanswer"));
                    if (correctAnswer == 3)
                        button3.BackColor = ColorTranslator.FromHtml("#2E942E");
                    else
                        button3.BackColor = ColorTranslator.FromHtml("#F84545");
                }
            } //if
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(button4.Text != " ")
            {
                
                string sqlcommand = "SELECT correctanswer FROM [lh_qa_ca] WHERE _rowid_=" + questionsNumber;
                SQLiteCommand command = new SQLiteCommand(sqlcommand, dbConnection);
                SQLiteDataReader result = command.ExecuteReader();
                Int32 correctAnswer;
                if (result.Read())
                {
                    correctAnswer = result.GetInt32(result.GetOrdinal("correctanswer"));
                    if (correctAnswer == 4)
                        button4.BackColor = ColorTranslator.FromHtml("#2E942E");
                    else
                        button4.BackColor = ColorTranslator.FromHtml("#F84545");
                } //if
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            button4.Enabled = true;
            button3.Text = " ";
            button4.Text = " ";
            if(questionsNumber == 150)
                questionsNumber = 0;
            button1.BackColor = ColorTranslator.FromHtml("#665338");
            button2.BackColor = ColorTranslator.FromHtml("#665338");
            button3.BackColor = ColorTranslator.FromHtml("#665338");
            button4.BackColor = ColorTranslator.FromHtml("#665338");
            questionsNumber++;
            richTextBox2.Text = questionsNumber.ToString();
            
            string sqlcommand = "SELECT question FROM [lh_qa_ca] WHERE _rowid_=" + questionsNumber;
            SQLiteCommand command = new SQLiteCommand(sqlcommand, dbConnection);
            SQLiteDataReader result = command.ExecuteReader();

            if (result.HasRows)
            {
                while (result.Read())
                {
                    string name = result.GetString(result.GetOrdinal("question"));
                    richTextBox1.Text = name;
                }
            }
            result.Close();
            //
            //button1
            //
            sqlcommand = "SELECT answer1 FROM [lh_qa_ca] WHERE _rowid_=" + questionsNumber;
            command = new SQLiteCommand(sqlcommand, dbConnection);
            result = command.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    string name = result.GetString(result.GetOrdinal("answer1"));
                    button1.Text = name;
                }
            }
            result.Close();
            //
            //button2
            //
            sqlcommand = "SELECT answer2 FROM [lh_qa_ca] WHERE _rowid_=" + questionsNumber;
            command = new SQLiteCommand(sqlcommand, dbConnection);
            result = command.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    string name = result.GetString(result.GetOrdinal("answer2"));
                    button2.Text = name;
                }
            }
            result.Close();
            //
            //button3
            //
            sqlcommand = "SELECT answer3 FROM [lh_qa_ca] WHERE _rowid_=" + questionsNumber;
            command = new SQLiteCommand(sqlcommand, dbConnection);
            result = command.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    string name = result.GetString(result.GetOrdinal("answer3"));
                    if (name != " ")
                        button3.Text = name;
                    else
                    {
                        button3.BackColor = Color.Transparent;
                        button3.Enabled = false;
                    }
                }
            }
            result.Close();
            //
            //button4
            //
            sqlcommand = "SELECT answer4 FROM [lh_qa_ca] WHERE _rowid_=" + questionsNumber;
            command = new SQLiteCommand(sqlcommand, dbConnection);
            result = command.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    string name = result.GetString(result.GetOrdinal("answer4"));
                    if (name != " ")
                        button4.Text = name;
                    else
                    {
                        button4.BackColor = Color.Transparent;
                        button4.Enabled = false;
                    }
                }
            }
            result.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            button4.Enabled = true;
            button3.Text = " ";
            button4.Text = " ";
            button1.BackColor = ColorTranslator.FromHtml("#665338");
            button2.BackColor = ColorTranslator.FromHtml("#665338");
            button3.BackColor = ColorTranslator.FromHtml("#665338");
            button4.BackColor = ColorTranslator.FromHtml("#665338");
            if (questionsNumber == 1)
                questionsNumber = 151;
            --questionsNumber;
            richTextBox2.Text = questionsNumber.ToString();
            
            string sqlcommand = "SELECT question FROM [lh_qa_ca] WHERE _rowid_=" + questionsNumber;
            SQLiteCommand command = new SQLiteCommand(sqlcommand, dbConnection);
            SQLiteDataReader result = command.ExecuteReader();

            if (result.HasRows)
            {
                while (result.Read())
                {
                    string name = result.GetString(result.GetOrdinal("question"));
                    richTextBox1.Text = name;
                }
            }
            result.Close();
            //
            //button1
            //
            sqlcommand = "SELECT answer1 FROM [lh_qa_ca] WHERE _rowid_=" + questionsNumber;
            command = new SQLiteCommand(sqlcommand, dbConnection);
            result = command.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    string name = result.GetString(result.GetOrdinal("answer1"));
                    button1.Text = name;
                }
            }
            result.Close();
            //
            //button2
            //
            sqlcommand = "SELECT answer2 FROM [lh_qa_ca] WHERE _rowid_=" + questionsNumber;
            command = new SQLiteCommand(sqlcommand, dbConnection);
            result = command.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    string name = result.GetString(result.GetOrdinal("answer2"));
                    button2.Text = name;
                }
            }
            result.Close();
            //
            //button3
            //
            sqlcommand = "SELECT answer3 FROM [lh_qa_ca] WHERE _rowid_=" + questionsNumber;
            command = new SQLiteCommand(sqlcommand, dbConnection);
            result = command.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    string name = result.GetString(result.GetOrdinal("answer3"));
                    if (name != " ")
                        button3.Text = name;
                    else
                    {
                        button3.BackColor = Color.Transparent;
                        button3.Enabled = false;
                    }
                }
            }
            result.Close();
            //
            //button4
            //
            sqlcommand = "SELECT answer4 FROM [lh_qa_ca] WHERE _rowid_=" + questionsNumber;
            command = new SQLiteCommand(sqlcommand, dbConnection);
            result = command.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    string name = result.GetString(result.GetOrdinal("answer4"));
                    if (name != " ")
                        button4.Text = name;
                    else
                    {
                        button4.BackColor = Color.Transparent;
                        button4.Enabled = false;
                    }
                }
            }
            result.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Exam Exam = new Exam();
            Exam.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {   
            if (textBox1.Text != "")
            {
                button3.Enabled = true;
                button4.Enabled = true;
                button1.BackColor = ColorTranslator.FromHtml("#665338");
                button2.BackColor = ColorTranslator.FromHtml("#665338");
                button3.BackColor = ColorTranslator.FromHtml("#665338");
                button4.BackColor = ColorTranslator.FromHtml("#665338");
                questionsNumber = Convert.ToInt32(textBox1.Text);
                if (questionsNumber > 150)
                    MessageBox.Show("შეყვანილი რიცხვი/ციფრი არ უნდა აღემატებოდეს 150-ს");
                else if (questionsNumber < 1)
                    MessageBox.Show("შეყვანილი რიცხვი/ციფრი მეტი უნდა იყოს 0-ზე");
                else if (questionsNumber <= 150 && questionsNumber >= 1)
                {
                    richTextBox2.Text = questionsNumber.ToString();

                    string sqlcommand = "SELECT question FROM [lh_qa_ca] WHERE _rowid_=" + questionsNumber;
                    SQLiteCommand command = new SQLiteCommand(sqlcommand, dbConnection);
                    SQLiteDataReader result = command.ExecuteReader();

                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            string name = result.GetString(result.GetOrdinal("question"));
                            richTextBox1.Text = name;
                        }
                    }
                    result.Close();
                    //
                    //button1
                    //
                    sqlcommand = "SELECT answer1 FROM [lh_qa_ca] WHERE _rowid_=" + questionsNumber;
                    command = new SQLiteCommand(sqlcommand, dbConnection);
                    result = command.ExecuteReader();
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            string name = result.GetString(result.GetOrdinal("answer1"));
                            button1.Text = name;
                        }
                    }
                    result.Close();
                    //
                    //button2
                    //
                    sqlcommand = "SELECT answer2 FROM [lh_qa_ca] WHERE _rowid_=" + questionsNumber;
                    command = new SQLiteCommand(sqlcommand, dbConnection);
                    result = command.ExecuteReader();
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            string name = result.GetString(result.GetOrdinal("answer2"));
                            button2.Text = name;
                        }
                    }
                    result.Close();
                    //
                    //button3
                    //
                    sqlcommand = "SELECT answer3 FROM [lh_qa_ca] WHERE _rowid_=" + questionsNumber;
                    command = new SQLiteCommand(sqlcommand, dbConnection);
                    result = command.ExecuteReader();
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            string name = result.GetString(result.GetOrdinal("answer3"));
                            if (name != " ")
                                button3.Text = name;
                            else
                                button4.Enabled = true;
                        }
                    }
                    result.Close();
                    //
                    //button4
                    //
                    sqlcommand = "SELECT answer4 FROM [lh_qa_ca] WHERE _rowid_=" + questionsNumber;
                    command = new SQLiteCommand(sqlcommand, dbConnection);
                    result = command.ExecuteReader();
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            string name = result.GetString(result.GetOrdinal("answer4"));
                            if (name != " ")
                                button4.Text = name;
                            else
                                button4.Enabled = false;
                        }
                    }
                    result.Close();
                }
            }
            else
            {
                MessageBox.Show("შეიყვანეთ ბილეთის ნომერი");
            }
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(!Char.IsDigit(ch) && ch != 8 && e.KeyChar != (char)13)
            {
                MessageBox.Show("შეიყვანე მხოლოდ ციფრები");
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About About = new About();
            About.Show();
        }

        private void authorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Author Author = new Author();
            Author.Show(); 
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button9_Click(this, new EventArgs());
        }

        private void richTextBox1_Enter_1(object sender, EventArgs e)
        {
            label1.Focus();
        }

        private void ონლაინვერსიაToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://inadire.ge/biletebi/");
            }
            catch (Win32Exception)
            {
                Process.Start("IExplore.exe", "https://inadire.ge/biletebi/");
            }
        }

        private void richTextBox2_Enter(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void richTextBox3_Enter(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}


