using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Potekhin_Vera____Installer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //          C:\\рс\\INSTALLER\\program.exe

        private void button1_Click(object sender, EventArgs e)
        {
            string path1 = "";

            if (comboBox1.SelectedItem.ToString() == "Генератор стойких паролей")
            {
                //C:\Users\Вера\RiderProjects\Potekhina Vera - Password generator\Potekhina Vera - Password generator\obj\Debug
                path1 = "C:\\Users\\Вера\\RiderProjects\\Potekhina Vera - Password generator\\Potekhina Vera - Password generator\\obj\\Debug\\Potekhina_Vera___Password_generator.exe";
            }
            else if (comboBox1.SelectedItem.ToString() == "Шифрование методом подстановки")
            {
                path1 = "C:\\Users\\Вера\\RiderProjects\\Potekhina Vera - Encryption by substitution\\Potekhina Vera - Encryption by substitution\\obj\\Debug\\Potekhina_Vera___Encryption_by_substitution.exe";
            }
            else if (comboBox1.SelectedItem.ToString() == "Шифрование методом перестановки")
            {
                path1 = "C:\\Users\\Вера\\RiderProjects\\Potekhina Vera - Encrypted by permutation\\Potekhina Vera - Encrypted by permutation\\obj\\Debug\\Potekhina_Vera___Encrypted_by_permutation.exe";
            }
            else if (comboBox1.SelectedItem.ToString() == "Стеганография")
            {
                path1 = "C:\\Users\\Вера\\RiderProjects\\Potekhina Vera - Steganography\\Potekhina Vera - Steganography\\obj\\Debug\\Potekhina_Vera___Steganography.exe";
            }
            else if (comboBox1.SelectedItem.ToString() == "Контрольная сумма")
            {
                path1 = "C:\\Users\\Вера\\RiderProjects\\Potekhina Vera - Checksum\\Potekhina Vera - Checksum\\obj\\Debug\\Potekhina_Vera___Checksum.exe";
            }
            else
            {
                MessageBox.Show("Выберите программу для установки");
            }
            var fi1 = new FileInfo(path1);

            var path2 = textBox1.Text;
            fi1.CopyTo(path2);
            File.WriteAllText( "C:\\рс\\INSTALLER\\" +"key.txt", "green apple");
            MessageBox.Show($"Файл успешно установлен");

        }
    }
}