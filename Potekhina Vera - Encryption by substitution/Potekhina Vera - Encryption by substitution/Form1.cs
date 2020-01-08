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

namespace Potekhina_Vera___Encryption_by_substitution
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StringBuilder lenta = new StringBuilder("");
            /*lenta.Append("abcdefghijklmnopqrstuvwxyz"); 
            lenta.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZ"); 
            lenta.Append("абвгдеёжзийклмнопрстуфхцчшщъыьэюя"); 
            lenta.Append("АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ"); 
            lenta.Append("0123456789"); 
            lenta.Append("!\"#$%^&*()+=-_'?.,|/`~№:;@[]{}");*/
            
            lenta.Append("!\"#$%&'-./");
            lenta.Append("0123456789");
            lenta.Append(":;<=?@");
            lenta.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            lenta.Append("[\\]^_`");
            lenta.Append("abcdefghijklmnopqrstuvwxyz");
            lenta.Append("{|}~<>");
            lenta.Append("Ёё№");
            lenta.Append("АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ");
            lenta.Append("абвгдеёжзийклмнопрстуфхцчшщъыьэюя");
            lentaCesar = lenta.ToString();
        }
        //ширфование при нажатии кнопки
        private void button1_Click(object sender, EventArgs e)
        {
            label10.Text = "";
            label5.Text = "";
            label7.Text = "";
            FileStream file1 = new FileStream("encryptedString.txt", FileMode.Create); //создаем файловый поток
            StreamWriter writer1 = new StreamWriter(file1); //создаем «потоковый писатель» и связываем его с файловым потоком 
            var str = textBox2.Text;
            var change = comboBox1.SelectedItem.ToString();
            if (change == "Одноалфавитная подстановка")
            {
                var shift = int.Parse(textBox1.Text);
                label5.Text = oneAlphabetSubstitution(str, shift);
                writer1.WriteLine(label5.Text); //записываем в файл
                MessageBox.Show("Строка зашифрована и записана в файл encryptedString");
            }
            else if (change == "Многоалфавитная подстановка")
            {
                var countAlphabet = int.Parse(textBox3.Text);
                int[] shifts = new int[countAlphabet];
                int i = 0;
                foreach(var el in textBox1.Text.Split(' '))
                {
                    shifts[i] = int.Parse(el);
                    i++;
                }
                label5.Text = polyalphabeticSubstitution(str, shifts);
                writer1.WriteLine(label5.Text); //записываем в файл
                MessageBox.Show("Строка зашифрована и записана в файл encryptedString");
            }
            else if (change == "Одноразовый блокнот")
            {
                var key = GeneratorDisposableNotebook(str.Length);
                label10.Text = key;
                label5.Text = DisposableNotebook(str, key);
                writer1.WriteLine(label5.Text); //записываем в файл
                MessageBox.Show("Строка зашифрована и записана в файл encryptedString");
            }
            else
                MessageBox.Show("Способ шифрования не выбран");
            writer1.Close();

        }
        //сдвиг символа
        private string ShiftSymbol(int indexOfChar, int shift)
        {
            var codeEncryptedSymbol = (indexOfChar + shift) % lentaCesar.Length;
            if (codeEncryptedSymbol < 0)
                codeEncryptedSymbol = codeEncryptedSymbol + lentaCesar.Length;
            var encryptedSymbol = lentaCesar.Substring(codeEncryptedSymbol, 1);
            return encryptedSymbol;
        }
        
        private readonly string lentaCesar;
        //шифр Цезаря
        private string oneAlphabetSubstitution(string userString, int shift)
        {
            StringBuilder encryptedString = new StringBuilder("");
            
            for (var i = 0; i < userString.Length; i++)
            {
                int indexOfChar = lentaCesar.IndexOf(userString[i]);
                if (indexOfChar != -1)
                    encryptedString.Append(ShiftSymbol(indexOfChar, shift));
                else
                    encryptedString.Append(userString[i]);
            }
            return encryptedString.ToString();
        }

        //многоалфавитная подстановка
        private string polyalphabeticSubstitution(string userString, int[] shifts)
        {
            StringBuilder encryptedString = new StringBuilder("");
            for (int i = 0, j = 0; i < userString.Length; i++, j++)
            {
                if (j == shifts.Length)
                    j = 0;
                int indexOfChar = lentaCesar.IndexOf(userString[i]);
                if (indexOfChar != -1)
                    encryptedString.Append(ShiftSymbol(indexOfChar, shifts[j]));
                else
                    encryptedString.Append(userString[i]);
            }
            return encryptedString.ToString();
        }
        //генератор одноразового блокнота
        private string GeneratorDisposableNotebook(int lengthText)
        {
            FileStream file3 = new FileStream("keyOfDisposableNotebook.txt", FileMode.Create); //создаем файловый поток
            StreamWriter writer3 = new StreamWriter(file3); //создаем «потоковый писатель» и связываем его с файловым потоком
            StringBuilder disposableNotebook = new StringBuilder("");
            Random rnd = new Random();
            for (var i = 0; i < lengthText; i++)
            {
                int value = rnd.Next(0, lentaCesar.Length-1);
                disposableNotebook.Append(lentaCesar[value]);
            }
            writer3.WriteLine(disposableNotebook.ToString()); //записываем в файл ключ
            writer3.Close();
            return disposableNotebook.ToString();
        }
        //одноразовый блокнот
        private string DisposableNotebook(string userString, string key)
        {
            StringBuilder encryptedString = new StringBuilder("");
            for (var i = 0; i < userString.Length; i++)
            {
                var indexEncryptedSymbol = (lentaCesar.IndexOf(userString[i]) + lentaCesar.IndexOf(key[i])) % lentaCesar.Length;
                encryptedString.Append(lentaCesar[indexEncryptedSymbol]);
            }
            return encryptedString.ToString();
        }
        //расшифровка одноразового блокнота
        private string DecryptionDisposableNotebook(string encryptedString, string key)
        {
            StringBuilder userString = new StringBuilder("");
            for (var i = 0; i < encryptedString.Length; i++)
            {
                var indexUserSymbol = (lentaCesar.Length + lentaCesar.IndexOf(encryptedString[i]) - lentaCesar.IndexOf(key[i])) % lentaCesar.Length;
                userString.Append(lentaCesar[indexUserSymbol]);
            }
            return userString.ToString();
        }
        //расшифровка при нажатии кнопки
        private void button1_Click_1(object sender, EventArgs e)
        {
            FileStream file2 = new FileStream("decryptedString.txt", FileMode.Create); //создаем файловый поток
            StreamWriter writer2 = new StreamWriter(file2); //создаем «потоковый писатель» и связываем его с файловым потоком 
            
            //чтение из программы
            var EncryptedString = label5.Text;
            
            //чтение из файла
            /*FileStream file1 = new FileStream("encryptedString.txt", FileMode.Open);
            StreamReader reader = new StreamReader(file1);
            var EncryptedString = reader.ReadToEnd(); //считываем все данные с потока и звписываем в переменную
            reader.Close(); //закрываем поток*/
            
            var change = comboBox1.SelectedItem.ToString();
            if (change == "Одноалфавитная подстановка")
            {
                var shift = int.Parse(textBox1.Text);
                label7.Text = oneAlphabetSubstitution(EncryptedString, -shift);
                writer2.WriteLine(label7.Text); //записываем в файл
                MessageBox.Show("Строка расшифрована и записана в файл decryptedString");
            }
            else if (change == "Многоалфавитная подстановка")
            {
                var countAlphabet = int.Parse(textBox3.Text);
                int[] shifts = new int[countAlphabet];
                int i = 0;
                foreach(var el in textBox1.Text.Split(' '))
                {
                    shifts[i] = int.Parse(el);
                    i++;
                }

                for (i = 0; i < shifts.Length; i++)
                    shifts[i] = -shifts[i];
                label7.Text = polyalphabeticSubstitution(EncryptedString, shifts);
                writer2.WriteLine(label7.Text); //записываем в файл
                MessageBox.Show("Строка расшифрована и записана в файл decryptedString");
            }
            else if (change == "Одноразовый блокнот")
            {
                var key = label10.Text;
                label7.Text = DecryptionDisposableNotebook(EncryptedString, key);
                writer2.WriteLine(label7.Text); //записываем в файл
                MessageBox.Show("Строка расшифрована и записана в файл decryptedString");
            }
            else
                MessageBox.Show("Способ расшифровки не выбран");
            writer2.Close();
        }
    }
}