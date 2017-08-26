using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Timers;

namespace LegalHunt
{
    public partial class Exam : Form
    {
        SQLiteConnection dbConnection;
        
        public Exam()
        {
            InitializeComponent();
            button5.Enabled = false;
        }

        int rowIdIndex = -1;
        int row_id;
        int question = 0;
        int correct = 0;
        int wrong = 0;
        int[] showQuestion = new int[150];
        public List<int> rowIds = new List<int>();
        Calculation calculation = new Calculation();
        System.Timers.Timer t;
        int h = 0, m = 29, s = 60;
        private void Exam_Load(object sender, EventArgs e)
        {
            richTextBox5.BackColor = ColorTranslator.FromHtml("#F84545");
            richTextBox4.BackColor = ColorTranslator.FromHtml("#2E942E");
            dbConnection = new SQLiteConnection("Data Source=./ExamExrcises.db;MultipleActiveResultSets=true");
            dbConnection.Open();
            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {

            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    if (m == 0 && s == 0)
                    {
                        t.Stop();
                        DialogResult dialog = MessageBox.Show("დრო ამოიწურა, თქვენ ვერ ჩააბარეთ გამოცდა");
                        if (dialog == DialogResult.OK)
                        {
                            t.Stop();
                            button5.Enabled = false;
                            button1.Text = " ";
                            button1.Enabled = false;
                            button1.BackColor = Color.Transparent;
                            button2.Text = " ";
                            button2.Enabled = false;
                            button2.BackColor = Color.Transparent;
                            button3.Text = " ";
                            button3.Enabled = false;
                            button3.BackColor = Color.Transparent;
                            button4.Text = " ";
                            button4.Enabled = false;
                            button4.BackColor = Color.Transparent;
                            richTextBox1.Text = "                                 დრო ამოიწურა, გამოცდა დასლურლდა";
                            richTextBox3.Text = " ";
                            richTextBox4.Text = " ";
                            richTextBox5.Text = " ";
                            textBox1.Text = "";
                        }
                    }
                    if (s == 0 && m !=0)
                    {
                        s = 60;
                        if(m != 0)
                            m = m - 1;
                    }
                    if(s != 0)
                        s = s - 1;
                    
                    if (m == 0 && h != 0)
                    {
                        m = 0;
                        h += 1;
                    }
                    textBox1.Text = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));

                }));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string sqlcommand = "SELECT correctanswer FROM [lh_qa_ca] WHERE _rowid_=" + showQuestion[rowIdIndex];
            SQLiteCommand command = new SQLiteCommand(sqlcommand, dbConnection);
            SQLiteDataReader result = command.ExecuteReader();
            Int32 correctAnswer;
            if (result.Read())
            {
                correctAnswer = result.GetInt32(result.GetOrdinal("correctanswer"));
                if (correctAnswer == 1)
                {
                    correct += 1;
                    button1.BackColor = ColorTranslator.FromHtml("#2E942E");
                    button2.BackColor = ColorTranslator.FromHtml("#F84545");
                    if (button3.Enabled == true)
                        button3.BackColor =ColorTranslator.FromHtml("#F84545");
                    else button3.Enabled = false;
                    if (button4.Enabled == true)
                        button4.BackColor = ColorTranslator.FromHtml("#F84545");
                    else button4.Enabled = false;
                }
                else if (correctAnswer == 2)
                {
                    wrong += 1;
                    button1.BackColor = ColorTranslator.FromHtml("#F84545");
                    button2.BackColor = ColorTranslator.FromHtml("#2E942E");
                    if (button3.Enabled == true)
                        button3.BackColor = ColorTranslator.FromHtml("#F84545");
                    else
                        button3.Enabled = false;
                    if (button4.Enabled == true)
                        button4.BackColor = ColorTranslator.FromHtml("#F84545");
                    else
                        button4.Enabled = false;
                }
                else if (correctAnswer == 3)
                {
                    wrong += 1;
                    button1.BackColor = ColorTranslator.FromHtml("#F84545");
                    button2.BackColor = ColorTranslator.FromHtml("#F84545");
                    if (button3.Enabled == true)
                        button3.BackColor = ColorTranslator.FromHtml("#2E942E");
                    else button3.Enabled = false;
                    if (button4.Enabled == true)
                        button4.BackColor = ColorTranslator.FromHtml("#F84545");
                    else button4.Enabled = false;
                }
                else if (correctAnswer == 4)
                {
                    wrong += 1;
                    button1.BackColor = ColorTranslator.FromHtml("#F84545");
                    button2.BackColor = ColorTranslator.FromHtml("#F84545");
                    if (button3.Enabled == true)
                        button3.BackColor = ColorTranslator.FromHtml("#F84545");
                    else
                        button3.Enabled = false;
                    if (button4.Enabled == true)
                        button4.BackColor = ColorTranslator.FromHtml("#2E942E");
                    else button4.Enabled = false;
                }
                richTextBox5.Text = "  " + wrong.ToString();
                richTextBox4.Text = "  " + correct.ToString();
            } //if
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }//btn click

        private void button2_Click(object sender, EventArgs e)
        {
            
            string sqlcommand = "SELECT correctanswer FROM [lh_qa_ca] WHERE _rowid_=" + showQuestion[rowIdIndex];
            SQLiteCommand command = new SQLiteCommand(sqlcommand, dbConnection);
            SQLiteDataReader result = command.ExecuteReader();
            Int32 correctAnswer;
            if (result.Read())
            {
                correctAnswer = result.GetInt32(result.GetOrdinal("correctanswer"));
                if (correctAnswer == 1)
                {
                    wrong += 1;
                    button1.BackColor = ColorTranslator.FromHtml("#2E942E");
                    button2.BackColor = ColorTranslator.FromHtml("#F84545");
                    if (button3.Enabled == true)
                        button3.BackColor = ColorTranslator.FromHtml("#F84545");
                    else button3.Enabled = false;
                    if (button4.Enabled == true)
                        button4.BackColor = ColorTranslator.FromHtml("#F84545");
                    else button4.Enabled = false;
                }
                else if (correctAnswer == 2)
                {
                    correct += 1;
                    button1.BackColor = ColorTranslator.FromHtml("#F84545");
                    button2.BackColor = ColorTranslator.FromHtml("#2E942E");
                    if (button3.Enabled == true)
                        button3.BackColor = ColorTranslator.FromHtml("#F84545");
                    else
                        button3.Enabled = false;
                    if (button4.Enabled == true)
                        button4.BackColor = ColorTranslator.FromHtml("#F84545");
                    else
                        button4.Enabled = false;
                }
                else if (correctAnswer == 3)
                {
                    wrong += 1;
                    button1.BackColor = ColorTranslator.FromHtml("#F84545");
                    button2.BackColor = ColorTranslator.FromHtml("#F84545");
                    if (button3.Enabled == true)
                        button3.BackColor = ColorTranslator.FromHtml("#2E942E");
                    else button3.Enabled = false;
                    if (button4.Enabled == true)
                        button4.BackColor = ColorTranslator.FromHtml("#F84545");
                    else button4.Enabled = false;
                }
                else if (correctAnswer == 4)
                {
                    wrong += 1;
                    button1.BackColor = ColorTranslator.FromHtml("#F84545");
                    button2.BackColor = ColorTranslator.FromHtml("#F84545");
                    if (button3.Enabled == true)
                        button3.BackColor = ColorTranslator.FromHtml("#F84545");
                    else
                        button3.Enabled = false;
                    if (button4.Enabled == true)
                        button4.BackColor = ColorTranslator.FromHtml("#2E942E");
                    else button4.Enabled = false;
                }
                richTextBox5.Text = "  " + wrong.ToString();
                richTextBox4.Text = "  " + correct.ToString();
            } //if
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            string sqlcommand = "SELECT correctanswer FROM [lh_qa_ca] WHERE _rowid_=" + showQuestion[rowIdIndex];
            SQLiteCommand command = new SQLiteCommand(sqlcommand, dbConnection);
            SQLiteDataReader result = command.ExecuteReader();
            Int32 correctAnswer;
            if (result.Read())
            {
                correctAnswer = result.GetInt32(result.GetOrdinal("correctanswer"));
                if (correctAnswer == 1)
                {
                    wrong += 1;
                    button1.BackColor = ColorTranslator.FromHtml("#2E942E");
                    button2.BackColor = ColorTranslator.FromHtml("#F84545");
                    if (button3.Enabled == true)
                        button3.BackColor = ColorTranslator.FromHtml("#F84545");
                    else button3.Enabled = false;
                    if (button4.Enabled == true)
                        button4.BackColor = ColorTranslator.FromHtml("#F84545");
                    else button4.Enabled = false;
                }
                else if (correctAnswer == 2)
                {
                    wrong += 1;
                    button1.BackColor = ColorTranslator.FromHtml("#F84545");
                    button2.BackColor = ColorTranslator.FromHtml("#2E942E");
                    if (button3.Enabled == true)
                        button3.BackColor = ColorTranslator.FromHtml("#F84545");
                    else
                        button3.Enabled = false;
                    if (button4.Enabled == true)
                        button4.BackColor = ColorTranslator.FromHtml("#F84545");
                    else
                        button4.Enabled = false;
                }
                else if (correctAnswer == 3)
                {
                    correct += 1;
                    button1.BackColor = ColorTranslator.FromHtml("#F84545");
                    button2.BackColor = ColorTranslator.FromHtml("#F84545");
                    if (button3.Enabled == true)
                        button3.BackColor = ColorTranslator.FromHtml("#2E942E");
                    else button3.Enabled = false;
                    if (button4.Enabled == true)
                        button4.BackColor = ColorTranslator.FromHtml("#F84545");
                    else button4.Enabled = false;
                }
                else if (correctAnswer == 4)
                {
                    wrong += 1;
                    button1.BackColor = ColorTranslator.FromHtml("#F84545");
                    button2.BackColor = ColorTranslator.FromHtml("#F84545");
                    if (button3.Enabled == true)
                        button3.BackColor = ColorTranslator.FromHtml("#F84545");
                    else
                        button3.Enabled = false;
                    if (button4.Enabled == true)
                        button4.BackColor = ColorTranslator.FromHtml("#2E942E");
                    else button4.Enabled = false;
                }
                richTextBox5.Text = "  " + wrong.ToString();
                richTextBox4.Text = "  " + correct.ToString();
            } //if
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            string sqlcommand = "SELECT correctanswer FROM [lh_qa_ca] WHERE _rowid_=" + showQuestion[rowIdIndex];
            SQLiteCommand command = new SQLiteCommand(sqlcommand, dbConnection);
            SQLiteDataReader result = command.ExecuteReader();
            Int32 correctAnswer;
            if (result.Read())
            {
                correctAnswer = result.GetInt32(result.GetOrdinal("correctanswer"));
                if (correctAnswer == 1)
                {
                    wrong += 1;
                    button1.BackColor = ColorTranslator.FromHtml("#2E942E");
                    button2.BackColor = ColorTranslator.FromHtml("#F84545");
                    if (button3.Enabled == true)
                        button3.BackColor = ColorTranslator.FromHtml("#F84545");
                    else button3.Enabled = false;
                    if (button4.Enabled == true)
                        button4.BackColor = ColorTranslator.FromHtml("#F84545");
                    else button4.Enabled = false;
                }
                else if (correctAnswer == 2)
                {
                    wrong += 1;
                    button1.BackColor = ColorTranslator.FromHtml("#F84545");
                    button2.BackColor = ColorTranslator.FromHtml("#2E942E");
                    if (button3.Enabled == true)
                        button3.BackColor = ColorTranslator.FromHtml("#F84545");
                    else
                        button3.Enabled = false;
                    if (button4.Enabled == true)
                        button4.BackColor = ColorTranslator.FromHtml("#F84545");
                    else
                        button4.Enabled = false;
                }
                else if (correctAnswer == 3)
                {
                    wrong += 1;
                    button1.BackColor = ColorTranslator.FromHtml("#F84545");
                    button2.BackColor = ColorTranslator.FromHtml("#F84545");
                    if (button3.Enabled == true)
                        button3.BackColor = ColorTranslator.FromHtml("#2E942E");
                    else button3.Enabled = false;
                    if (button4.Enabled == true)
                        button4.BackColor = ColorTranslator.FromHtml("#F84545");
                    else button4.Enabled = false;
                }
                else if (correctAnswer == 4)
                {
                    correct += 1;
                    button1.BackColor = ColorTranslator.FromHtml("#F84545");
                    button2.BackColor = ColorTranslator.FromHtml("#F84545");
                    if (button3.Enabled == true)
                        button3.BackColor = ColorTranslator.FromHtml("#F84545");
                    else
                        button3.Enabled = false;
                    if (button4.Enabled == true)
                        button4.BackColor = ColorTranslator.FromHtml("#2E942E");
                    else button4.Enabled = false;
                }
                richTextBox5.Text = "  " + wrong.ToString();
                richTextBox4.Text = "  " + correct.ToString();
            } //if
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            button5.Focus();
        }

        private void richTextBox3_Enter(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void richTextBox4_Enter(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void richTextBox5_Enter(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (correct == 18)
            {
                t.Stop();
                DialogResult dialog = MessageBox.Show("თქვენ წარმათტებით ჩააბარეთ გამოცდა");
                if (dialog == DialogResult.OK)
                {
                    button5.Enabled = false;
                    button1.Text = " ";
                    button1.Enabled = false;
                    button1.BackColor = Color.Transparent;
                    button2.Text = " ";
                    button2.Enabled = false;
                    button2.BackColor = Color.Transparent;
                    button3.Text = " ";
                    button3.Enabled = false;
                    button3.BackColor = Color.Transparent;
                    button4.Text = " ";
                    button4.Enabled = false;
                    button4.BackColor = Color.Transparent;
                    richTextBox1.Text = "                         თქვენ წარმათტებით ჩააბარეთ გამოცდა";
                    richTextBox3.Text = " ";
                    richTextBox4.Text = " ";
                    richTextBox5.Text = " ";
                }
            }
            else if (wrong > 2)
            {
                DialogResult dialog = MessageBox.Show("თქვენ ვერ ჩააბარეთ გამოცდა, არასწორი პასუხების მაქსიმალური რაოდენობაა 2");
                if (dialog == DialogResult.OK)
                {
                    button5.Enabled = false;
                    t.Stop();
                    button1.Text = " ";
                    button1.Enabled = false;
                    button1.BackColor = Color.Transparent;
                    button2.Text = " ";
                    button2.Enabled = false;
                    button2.BackColor = Color.Transparent;
                    button3.Text = " ";
                    button3.Enabled = false;
                    button3.BackColor = Color.Transparent;
                    button4.Text = " ";
                    button4.Enabled = false;
                    button4.BackColor = Color.Transparent;
                    richTextBox1.Text = " თქვენ ვერ ჩააბარეთ გამოცდა, არასწორი პასუხების მაქსიმალური რაოდენობაა 2";
                    richTextBox3.Text = " ";
                    richTextBox4.Text = " ";
                    richTextBox5.Text = " ";
                    textBox1.Text = "";
                }
            }
            else
            {
                rowIdIndex++;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button3.Text = " ";
                button4.Text = " ";
                question += 1;
                richTextBox3.Text = " " + question.ToString();
                if (question == 21)
                {
                    MessageBox.Show("გამოცდა დასრულდა");
                    t.Stop();
                }
                button1.BackColor = ColorTranslator.FromHtml("#665338");
                button2.BackColor = ColorTranslator.FromHtml("#665338");
                button3.BackColor = ColorTranslator.FromHtml("#665338");
                button4.BackColor = ColorTranslator.FromHtml("#665338");
                Random r = new Random();
                int rInt = r.Next(1, 4);
                row_id = rInt;
                
                string sqlcommand = "SELECT question FROM [lh_qa_ca] WHERE _rowid_=" + showQuestion[rowIdIndex];
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
                sqlcommand = "SELECT answer1 FROM [lh_qa_ca] WHERE _rowid_=" + showQuestion[rowIdIndex];
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
                sqlcommand = "SELECT answer2 FROM [lh_qa_ca] WHERE _rowid_=" + showQuestion[rowIdIndex];
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
                sqlcommand = "SELECT answer3 FROM [lh_qa_ca] WHERE _rowid_=" + showQuestion[rowIdIndex];
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
                            button3.Enabled = false;
                            button3.BackColor = Color.Transparent;
                        }
                    }
                }
                result.Close();
                //
                //button4
                //
                sqlcommand = "SELECT answer4 FROM [lh_qa_ca] WHERE _rowid_=" + showQuestion[rowIdIndex];
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
                            button4.Enabled = false;
                            button4.BackColor = Color.Transparent;
                        }
                    }
                }
                result.Close();
            }
            

        }

        private void button6_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button1.BackColor = ColorTranslator.FromHtml("#665338");
            button2.BackColor = ColorTranslator.FromHtml("#665338");
            button3.BackColor = ColorTranslator.FromHtml("#665338");
            button4.BackColor = ColorTranslator.FromHtml("#665338");
            t.Start();
            rowIdIndex++;
            rowIds = calculation.GenerateDistinctNumbersRandomOrder(0, 149, 150, rowIds);
            for (int i = 0; i < 150; i++)
            {
                showQuestion[i] = rowIds[i];
            }
            button5.Enabled = true;
            button6.Enabled = false;
            question += 1;
            richTextBox3.Text = " " + question.ToString();
            
            string sqlcommand = "SELECT question FROM [lh_qa_ca] WHERE _rowid_=" + showQuestion[rowIdIndex];
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
            sqlcommand = "SELECT answer1 FROM [lh_qa_ca] WHERE _rowid_=" + showQuestion[rowIdIndex];
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
            sqlcommand = "SELECT answer2 FROM [lh_qa_ca] WHERE _rowid_=" + showQuestion[rowIdIndex];
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
            sqlcommand = "SELECT answer3 FROM [lh_qa_ca] WHERE _rowid_=" + showQuestion[rowIdIndex];
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
                        button3.Enabled = false;
                        button3.BackColor = Color.Transparent;
                    }
                }
            }
            result.Close();
            //
            //button4
            //
            sqlcommand = "SELECT answer4 FROM [lh_qa_ca] WHERE _rowid_=" + showQuestion[rowIdIndex];
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
                        button4.Enabled = false;
                        button4.BackColor = Color.Transparent;
                    }
                }
            }
            result.Close();
        }
    }
}
