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

/*
 * 1.	Написать программу, генерирующую стойкие пароли.
 * Программа по запросу пользователя генерирует один пароль или список паролей заданной длины.
 * Элементы пароля – случайные или псевдослучайные, длина пароля задается пользователем.
 * В алфавит включить латинские буквы (строчные и прописные), цифры от 0 до 9 и спецсимволы %, #, -, &, $.
 * Список паролей помещается в текстовый файл в зашифрованном виде. Предусмотреть возможность чтения и дешифровки паролей из файла.
 *
 * Нам нужно:
 * поле для длины пароля
 * поле для количества паролей
 * кнопка выполнения
 *
 * потом:
 * кнопка открыть файл с паролями
 */
namespace Potekhina_Vera___Password_generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int passwordLength = 0;
        private int passwordCount = 0;
        private int[] arr;
        private Dictionary<char, int> dictionaryCharCode;
        private Dictionary<int, char> dictionaryCodeChar;
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists("key.txt") == false)
                return;
            else
            {
                FileStream file3 = new FileStream("key.txt", FileMode.Open);
                StreamReader reader = new StreamReader(file3);
                var key = reader.ReadLine(); //считываем ключ
                if (key != "green apple")
                    return;
            }
            passwordLength = int.Parse(textBox1.Text);
            passwordCount = int.Parse(textBox2.Text);
            arr = new int[67];
            int k = 0;
            dictionaryCharCode = new Dictionary<char, int>(67);
            dictionaryCodeChar = new Dictionary<int, char>(67);
            for (var i = 35; i < 123; i++)
            {
                if ((i == 45) || ((i >= 35) && (i <= 38)) || ((i >= 48) && (i <= 57)) || ((i >= 65) && (i <= 90)) || ((i >= 97) && (i <= 122)))
                {
                    arr[k] = i;
                    k++;
                    dictionaryCharCode.Add((char)i, i);
                    dictionaryCodeChar.Add(i, (char)i);
                    
                }
            }
            var rnd = new Random();
            StringBuilder password = new StringBuilder("");
            StringBuilder encryptedPassword = new StringBuilder("");
            
            FileStream file1 = new FileStream("output.txt", FileMode.Create); //создаем файловый поток
            StreamWriter writer1 = new StreamWriter(file1); //создаем «потоковый писатель» и связываем его с файловым потоком 
            FileStream file2 = new FileStream("encryptedPassword.txt", FileMode.Create); //создаем файловый поток
            StreamWriter writer2 = new StreamWriter(file2); //создаем «потоковый писатель» и связываем его с файловым потоком 

            for (var i = 0; i < passwordCount; i++)
            {
                for (var j = 0; j < passwordLength; j++)
                {
                    var value = rnd.Next(0, 66);
                    password.Append(dictionaryCodeChar[arr[value]]);
                    //шифр Цезаря
                    var shift = 4;
                    encryptedPassword.Append(dictionaryCodeChar[arr[(value + shift) % 67]]);
                }
                writer1.WriteLine(password); //записываем в файл
                writer2.WriteLine(encryptedPassword); 
                
                password = new StringBuilder("");
                encryptedPassword = new StringBuilder("");
            }
            
            writer1.Close(); //закрываем поток
            writer2.Close();
            MessageBox.Show("Генерация паролей выполнена");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            FileStream file2 = new FileStream("encryptedPassword.txt", FileMode.Open);
            StreamReader reader = new StreamReader(file2);
            label4.Text = reader.ReadToEnd(); //считываем все данные с потока и выводим на экран
            reader.Close(); //закрываем поток
            MessageBox.Show("Список зашифрованных паролей выведен");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private static int BinarySearch(int searchValue, int[] arr)
        {

            var leftBorder = -1;
            var rightBorder = arr.Length;
            var middle = (rightBorder + leftBorder) / 2;

            while ((searchValue != arr[middle]) && (leftBorder < rightBorder - 1))
            {
                if (searchValue > arr[middle])
                {
                    leftBorder = middle;
                }
                else
                    rightBorder = middle;

                middle = (rightBorder + leftBorder) / 2;
            }

            return middle;
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream file2 = new FileStream("encryptedPassword.txt", FileMode.Open);
            StreamReader reader = new StreamReader(file2);
            StringBuilder decryptedPassword = new StringBuilder("");
            for (var i = 0; i < passwordCount; i++)
            {
                string encryptedPassword = reader.ReadLine(); //считываем пароль
                
                for (var j = 0; j < passwordLength; j++)
                {
                    //расшифровываем Цезаря
                    var shift = 4;
                    var valueEncrCode = dictionaryCharCode[encryptedPassword[j]];
                    var valueDecrCode = BinarySearch(valueEncrCode, arr) - shift;
                    if (valueDecrCode < 0)
                        valueDecrCode = 66 + valueDecrCode;
                    
                    decryptedPassword.Append(dictionaryCodeChar[arr[valueDecrCode]]);
                }
                decryptedPassword.Append('\n');
            }
            label6.Text = decryptedPassword.ToString();
            reader.Close(); //закрываем поток
            MessageBox.Show("Список расшифрованных паролей выведен");
        }
    }
}