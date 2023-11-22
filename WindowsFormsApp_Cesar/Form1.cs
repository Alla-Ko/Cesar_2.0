using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp_Cesar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.SelectedIndex = 0;
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

        }
        SaveFileDialog saveFileDialog1=new SaveFileDialog();
        private void button1_Click(object sender, EventArgs e)
        {
            //зашифрувати
            String mal = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzабвгґдеєжзіїйклмнопрстуфхцчшщьюяАБВГҐДЕЄЖЗІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ0123456789";
            int len=mal.Length;
            String text1 = this.textBox1.Text;
            String text2 = "";

            int n = 0;
            
            if(Int32.TryParse(this.comboBox1.SelectedItem.ToString(), out n)!=null)
            {
                for (int i = 0; i < text1.Length; i++)
                {
                    if (mal.IndexOf(text1[i]) != -1)
                    {
                        text2 = text2 + mal[(mal.IndexOf(text1[i]) + n) % len];
                    }
                    else
                    {
                        text2 = text2 + text1[i];
                    }
                }
                this.textBox2.Text = text2;
            }
                
        }

 
        private void button_save_Click(object sender, EventArgs e)
        {
            //зберегти у файл
            if(textBox2.Text=="")
            {
                MessageBox.Show("Текст відсутній", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, textBox2.Text);
            MessageBox.Show("Файл збережено");

        }

        private void button_clean_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
