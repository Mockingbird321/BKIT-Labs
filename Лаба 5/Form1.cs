using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;


namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> list = new List<string>();

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileDownload = new OpenFileDialog();
            FileDownload.Filter = "текстовые файлы |*.txt";
            if (FileDownload.ShowDialog() == DialogResult.OK)
            {
                Stopwatch t = new Stopwatch();
                t.Start();
                string text = File.ReadAllText(FileDownload.FileName);
                char[] separators = new char[] { ' ', '.', ',', '!', '?', '/', '\t', '\n' };
                string[] textArray = text.Split(separators);
                foreach (string strTemp in textArray)
                {
                    string str = strTemp.Trim();
                    if (!list.Contains(str)) list.Add(str);
                }
                t.Stop();
                this.textBoxFileReadTime.Text = t.Elapsed.ToString();
                this.textBoxFileReadCount.Text = list.Count.ToString();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать файл");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string word = this.textBoxFind.Text.Trim();

            if (!string.IsNullOrWhiteSpace(word) && list.Count > 0)
            {

                string wordUpper = word.ToUpper();

                List<string> tempList = new List<string>();
                Stopwatch t = new Stopwatch();
                t.Start();
                foreach (string str in list)
                {
                    if (str.ToUpper().Contains(wordUpper))
                    {
                        tempList.Add(str);
                    }
                }
                t.Stop();
                this.textBoxExactTime.Text = t.Elapsed.ToString();
                this.listBoxResult.BeginUpdate();

                this.listBoxResult.Items.Clear();

                foreach (string str in tempList)
                {
                    this.listBoxResult.Items.Add(str);
                }
                this.listBoxResult.EndUpdate();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать файл и ввести слово для поиска");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string word = this.textBoxFind.Text.Trim();

            if (!string.IsNullOrWhiteSpace(word) && list.Count > 0)
            {
                int maxDist;

                if (!int.TryParse(this.textBox2.Text.Trim(), out maxDist))
                {
                    {
                        MessageBox.Show("Необходимо указать максимальное расстояние");
                        return;
                    }
                    if (maxDist < 1 || maxDist > 5)
                    {
                        MessageBox.Show("Максимальное расстояние должно быть в диапазоне от 1 до 5");
                        return;
                    }
                }

                string WordUpper = word.ToUpper();

                List<Tuple<string, int>> tempList = new List<Tuple<string, int>>();
                Stopwatch timer = new Stopwatch();

                timer.Start();

                foreach (string str in list)
                {
                    int dist = EditDistance.Distance(str.ToUpper(), WordUpper);

                    if (dist <= maxDist)
                    {
                        tempList.Add(new Tuple<string, int>(str, dist));
                    }
                }

                timer.Stop();

                this.textBox1.Text = timer.Elapsed.ToString();
                this.listBoxResult.BeginUpdate();
                this.listBoxResult.Items.Clear();

                foreach (var x in tempList)
                {
                    string temp = x.Item1 + " (р.Левенштайна : " + x.Item2.ToString() + ")";
                    this.listBoxResult.Items.Add(temp);
                }
                this.listBoxResult.EndUpdate();
            }

            else
            {
                MessageBox.Show("Отсутсвуют данные");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

    }
}
