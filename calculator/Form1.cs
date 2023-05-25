using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // textBox1.Text = "0";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 2;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 6;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 5;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 7;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 8;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 9;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "+";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "-";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "x";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + ":";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + ".";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string functie = textBox1.Text;
            Regex regex = new Regex(@"^[0-9+\-x/.:]+$");
            if (regex.IsMatch(functie))
            {
                List<double> lista = new List<double>();
                List<char> listasim = new List<char>();
                List<char> paranteze = new List<char>();
                string[] parentez = new string[] { "(", ")"};
                string[] operatori = new string[] { "+" , "-", "x", ":" };
                string[] cuvinte = functie.Split(operatori, StringSplitOptions.RemoveEmptyEntries);
                string[] simboluri = functie.Split(cuvinte, StringSplitOptions.RemoveEmptyEntries);
                

                foreach (string cuvant in cuvinte)
                {
                    lista.Add(double.Parse(cuvant));
                }

                foreach (string simbol in simboluri)
                {
                    listasim.Add(simbol[0]);
                }
               

                int index = 0;
                while (index < listasim.Count)
                {
                    if (listasim[index] == 'x' || listasim[index] == ':')
                    {
                        double a = lista[index];
                        double b = lista[index + 1];
                        if (listasim[index] == 'x')
                        {
                            lista[index] = a * b;
                        }
                        else
                        {
                            if (b == 0)
                            {
                                throw new DivideByZeroException("Impartire la zero!");
                            }
                            lista[index] = a / b;
                        }
                        lista.RemoveAt(index + 1);
                        listasim.RemoveAt(index);
                    }
                    else
                    {
                        index++;
                    }
                }

                double rezultat = lista[0];
                for (int i = 1; i < lista.Count; i++)
                {
                    switch (listasim[i - 1])
                    {
                        case '+':
                            rezultat += lista[i];
                            break;
                        case '-':
                            rezultat -= lista[i];
                            break;
                    }
                }

                textBox1.Text = rezultat.ToString();
            }
            else
            {
                MessageBox.Show("valorine sunt incorecte");
                textBox1.Text = string.Empty;
            }

        }
        private void button19_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            if (a != string.Empty)
            {
                char[] sep = a.ToCharArray();
                Array.Resize(ref sep, sep.Length - 1);
                string myString = new string(sep);
                textBox1.Text = myString;
            }
            else { }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "(";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + ")";
        }
    }
}
