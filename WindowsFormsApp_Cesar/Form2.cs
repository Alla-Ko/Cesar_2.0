using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_Cesar
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.SelectedIndex = 0;
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }
        OpenFileDialog openFileDialog1=new OpenFileDialog();
        private void button2_Click(object sender, EventArgs e)
        {
            //розшифрувати
            String mal = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzабвгґдеєжзіїйклмнопрстуфхцчшщьюяАБВГҐДЕЄЖЗІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ0123456789";
            int len = mal.Length;
            String text1 = this.textBox1.Text;
            String text2 = "";
            int n = 0;
            if (Int32.TryParse(this.comboBox1.SelectedItem.ToString(), out n) != null)
            {
                for (int i = 0; i < text1.Length; i++)
                {
                    if (mal.IndexOf(text1[i]) != -1)
                    {
                        text2 = text2 + mal[(mal.IndexOf(text1[i]) - n + len) % len];
                    }
                    else
                    {
                        text2 = text2 + text1[i];
                    }
                }
                this.textBox2.Text = text2;

            }
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            //відкрити з файла
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            textBox1.Text = fileText;
            //MessageBox.Show("Файл відкрито");
            if(textBox1.Text=="") MessageBox.Show("Файл порожній","Попередження", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_clean_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
