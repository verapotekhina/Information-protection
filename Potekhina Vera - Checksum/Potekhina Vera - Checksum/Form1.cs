using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Potekhina_Vera___Checksum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Dictionary<string, string> dictionary = new Dictionary<string, string>();

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            var nameFile = textBox1.Text;

            if (File.Exists(nameFile) == false)
            {
                MessageBox.Show("Файл не найден");
                textBox1.Clear();
                return;
            }

            FileStream fs1 = File.OpenRead (nameFile);; // Только для чтения
            MD5 md5Hash = MD5.Create();
            var hash = md5Hash.ComputeHash(fs1);
            fs1.Close();
            StringBuilder str = new StringBuilder("");
            for (var i = 0; i < hash.Length; i++)
                str.Append(hash[i] + " ");

            if (dictionary.ContainsKey(nameFile))
            {
                textBox2.Text = dictionary[nameFile];
                textBox3.Text = str.ToString();
                if (dictionary[nameFile] == str.ToString())
                    MessageBox.Show("Файл не изменялся");
                else
                    MessageBox.Show("Файл был изменен");
            }
            else
            {
                dictionary.Add(nameFile, str.ToString());
                textBox2.Text = dictionary[nameFile];
            }
               
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            var lst = "";
            foreach (string str in dictionary.Keys)
            {
                lst = lst + str + "\r\n";
            }
            
            textBox4.Text = lst;

        }
    }
}