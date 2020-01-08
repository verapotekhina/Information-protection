using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Potekhina_Vera___Encrypted_by_permutation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //сделать запись в файл
        //попробовать Кордано

         private void encryptedButton_Click(object sender, EventArgs e)
        {
            textBox_encryptedString.Text = "";
            textBox_decryptedString.Text = "";
            FileStream file1 = new FileStream("encryptedString.txt", FileMode.Create); //создаем файловый поток
            StreamWriter writer1 = new StreamWriter(file1); //создаем «потоковый писатель» и связываем его с файловым потоком 
            var str = userString.Text;
            var change = listOfEncryptionOptions.SelectedItem.ToString();
            var encryptedString = "";
            
            if (change == "Линейная перестановка")
            {
                var countPermutation = int.Parse(textBox_countPermutations.Text);
                int[] permutations = new int[countPermutation];
                int i = 0;
                foreach(var el in textBox_listOfPermutations.Text.Split(' '))
                {
                    permutations[i] = int.Parse(el);
                    i++;
                }
                encryptedString = LinearPermutation(str, countPermutation, permutations);
            }
            else if (change == "Решетка Кардано")
            {
                var sizeGrid = int.Parse(listOfGridSizes.SelectedItem.ToString());
                encryptedString = CardanoGrid(str, sizeGrid);
            }
            else if (change == "Табличная маршрутная перестановка")
            {
                var countOfColumns = int.Parse(textBox_countOfColumns.Text);
                encryptedString = RoutePermutation(str, countOfColumns);
            }
            else
                MessageBox.Show("Способ шифрования не выбран");
            writer1.WriteLine(encryptedString); //записываем в файл encryptedString
            writer1.Close();
            textBox_encryptedString.Text = encryptedString;
        }
         
        private void decryptedButton_Click(object sender, EventArgs e)
        {
            FileStream file1 = new FileStream("encryptedString.txt", FileMode.Open);
            StreamReader reader = new StreamReader(file1);
            var encryptedString = reader.ReadToEnd(); //считываем все данные с потока и звписываем в переменную
            reader.Close(); //закрываем поток
            var change = listOfEncryptionOptions.SelectedItem.ToString();
            var decryptedString = "";

            if (change == "Линейная перестановка")
            {
                var countPermutation = int.Parse(textBox_countPermutations.Text);
                int[] permutations = new int[countPermutation];
                int i = 0;
                foreach(var el in textBox_listOfPermutations.Text.Split(' '))
                {
                    permutations[i] = int.Parse(el);
                    i++;
                }
                decryptedString = DecryptedLinearPermutation(encryptedString, countPermutation, permutations);
            }
            
            else if (change == "Решетка Кардано")
            {
                var sizeGrid = int.Parse(listOfGridSizes.SelectedItem.ToString());
                decryptedString = DecryptedCardanoGrid(encryptedString, sizeGrid);
            }
            
            else if (change == "Табличная маршрутная перестановка")
            {
                var countOfColumns = int.Parse(textBox_countOfColumns.Text);
                decryptedString = DecryptedRoutePermutation(encryptedString, countOfColumns);
            }
            else
                MessageBox.Show("Способ шифрования не выбран");

            textBox_decryptedString.Text = decryptedString;
            FileStream file2= new FileStream("deryptedString.txt", FileMode.Create); //создаем файловый поток
            StreamWriter writer2 = new StreamWriter(file2); //создаем «потоковый писатель» и связываем его с файловым потоком 
            writer2.WriteLine(decryptedString); //записываем в файл decryptedString
            writer2.Close(); //закрываем поток

        }
        private string LinearPermutation(string userString, int countPermutation, int[] permutations)
        {
            StringBuilder encryptedString = new StringBuilder("");
            while (userString.Length % countPermutation != 0)
            {
                userString = userString + " ";
            }
            
            for (var i = 0; i < userString.Length / countPermutation; i++)
            {
                var subStr = userString.Substring(i * countPermutation, countPermutation);
                for (var j = 0; j < countPermutation; j++)
                {
                    encryptedString.Append(subStr[permutations[j]-1]);
                }
            } 
            return encryptedString.ToString();
        }

        
        
        private string CardanoGrid(string userString, int sizeGrid)
        {
            StringBuilder encryptedString = new StringBuilder("");
            
            //дополнили пробелами до кратного квадрату размера решетки
            while (userString.Length % (sizeGrid*sizeGrid) != 0)
            {
                userString = userString + " ";
            }
            //создали массив строк длины размера решетки
            string[] arrString = new string[userString.Length / sizeGrid];

            //заполнили массив
            var startPos = 0;
            for (var i = 0; i < userString.Length / sizeGrid; i++)
            {
                arrString[i] = userString.Substring(startPos, sizeGrid);
                startPos += sizeGrid;
            }

            for (var i = 0; i < userString.Length / (sizeGrid * sizeGrid); i++)
            {
                for (var j = 0; j < sizeGrid * sizeGrid; j++)
                {
                    var item1 = 0;
                    var item2 = 0;
                    if (sizeGrid == 2)
                    {
                        item1 = gridCardano2[j].Item1;
                        item2 = gridCardano2[j].Item2;
                    }
                    else if (sizeGrid == 4)
                    {
                        item1 = gridCardano4[j].Item1;
                        item2 = gridCardano4[j].Item2;
                    }
                    else if (sizeGrid == 6)
                    {
                        item1 = gridCardano6[j].Item1;
                        item2 = gridCardano6[j].Item2;
                    }
                    else if (sizeGrid == 8)
                    {
                        item1 = gridCardano8[j].Item1;
                        item2 = gridCardano8[j].Item2;
                    }
                    else if (sizeGrid == 10)
                    {
                        item1 = gridCardano10[j].Item1;
                        item2 = gridCardano10[j].Item2;
                    }
                    else
                    {
                        MessageBox.Show("Выберите корректный размер решетки");
                    }
                    
                    var el = arrString[item1 + (i*sizeGrid)][item2];
                    encryptedString.Append(el);   
                }
            }
            return encryptedString.ToString();
        }

        private string RoutePermutation(string userString, int countColumns)
        {
            StringBuilder encryptedString = new StringBuilder("");
            
            //дополнили исходную строку пробелами до кратного количеству столбцов
            while (userString.Length % countColumns != 0)
            {
                userString = userString + " ";
            }
            //создали массив строк с введенным количеством столбцов
            string[] arrString = new string[userString.Length / countColumns];

            //заполнили массив - записали исходную строку слева направо последовательно по строкам
            var startPos = 0;
            for (var i = 0; i < userString.Length / countColumns; i++)
            {
                arrString[i] = userString.Substring(startPos, countColumns);
                startPos += countColumns;
            }
            
            //читаем массив по другому маршруту и записываем в строку
            for (var j  = countColumns; j > 0; j--)
            {
                for (var i = 0; i < userString.Length / countColumns; i++)
                {
                    encryptedString.Append(arrString[i][j - 1]);
                }
            }
            return encryptedString.ToString();
        }
        
        private string DecryptedLinearPermutation(string encryptedString, int countPermutation, int[] permutations)
        {
            StringBuilder decryptedString = new StringBuilder("");

            for (var i = 0; i < encryptedString.Length/countPermutation; i++)
            {
                var subStr = encryptedString.Substring(i * countPermutation, countPermutation);
                var decSubStr = new StringBuilder("");
                for (var j = 0; j < subStr.Length; j++)
                    decSubStr.Append(" ");
                for (var j = 0; j < countPermutation; j++)
                {
                    var value = permutations[j] - 1;
                    decSubStr[value] = subStr[j];
                }

                decryptedString.Append(decSubStr);
            } 
            return decryptedString.ToString();
        }
        
        private string DecryptedCardanoGrid(string encryptedString, int sizeGrid)
        {
            StringBuilder decryptedString = new StringBuilder("");
            
            //создали массив строк длины размера решетки
           var arrString = new StringBuilder[encryptedString.Length / sizeGrid];

            //заполнили массив
            for (var i = 0; i < encryptedString.Length / sizeGrid; i++)
            {
                arrString[i] = new StringBuilder("");
                for (var j = 0; j < sizeGrid; j++)
                    arrString[i].Append(" ");
            }
                
            for (var i = 0; i < encryptedString.Length / (sizeGrid * sizeGrid); i++)
            {
                for (var j = 0; j < sizeGrid * sizeGrid; j++)
                {
                    var item1 = 0;
                    var item2 = 0;
                    if (sizeGrid == 2)
                    {
                        item1 = gridCardano2[j].Item1;
                        item2 = gridCardano2[j].Item2;
                    }
                    else if (sizeGrid == 4)
                    {
                        item1 = gridCardano4[j].Item1;
                        item2 = gridCardano4[j].Item2;
                    }
                    else if (sizeGrid == 6)
                    {
                        item1 = gridCardano6[j].Item1;
                        item2 = gridCardano6[j].Item2;
                    }
                    else if (sizeGrid == 8)
                    {
                        item1 = gridCardano8[j].Item1;
                        item2 = gridCardano8[j].Item2;
                    }
                    else if (sizeGrid == 10)
                    {
                        item1 = gridCardano10[j].Item1;
                        item2 = gridCardano10[j].Item2;
                    }
                    else
                    {
                        MessageBox.Show("Выберите корректный размер решетки");
                    }
                    arrString[item1][item2] = encryptedString[j + (i*sizeGrid*sizeGrid)];
                }

                for (var j = 0; j < sizeGrid; j++)
                    decryptedString.Append(arrString[j]);
            }
            return decryptedString.ToString();
        }
        
        private string DecryptedRoutePermutation(string encryptedString, int countColumns)
        {
            StringBuilder decryptedString = new StringBuilder("");
            
            //создали массив строк с введенным количеством столбцов
            var arrString = new StringBuilder[encryptedString.Length / countColumns];
            
            //заполнили массив - записали пустую строку слева направо последовательно по строкам
            for (var i = 0; i < encryptedString.Length / countColumns; i++)
            {
                arrString[i] = new StringBuilder("");
                for (var j = 0; j < countColumns; j++)
                    arrString[i].Append(" ");
            }

            var position = 0;
            
            //заполняем массив по второму маршруту (по вертикали)
            for (var j  = countColumns; j > 0; j--)
            {
                for (var i = 0; i < encryptedString.Length / countColumns; i++)
                {
                    arrString[i][j - 1] = encryptedString[position];
                    position++;
                }
            }
            //читаем массив по первому маршруту (по горизонтали)
            for (var i = 0; i < encryptedString.Length / countColumns; i++)
            {
                decryptedString.Append(arrString[i]);
            }
            return decryptedString.ToString();
        }

        //таблицы Кардано
        private readonly List<(int, int)> gridCardano2 = new List<(int, int)>
        {
            (0, 0),
            (1, 1),
            (1, 0),
            (0, 1)
        };
        
        private readonly List<(int, int)> gridCardano4 = new List<(int, int)>
        {
            (0, 1),
            (1, 0),
            (2, 1),
            (3, 3),
            (0, 2),
            (1, 1),
            (1, 3),
            (3, 0),
            (0, 0),
            (1, 2),
            (2, 3),
            (3, 2),
            (0, 3),
            (2, 0),
            (2, 2),
            (3, 1)
        };

        private readonly List<(int, int)> gridCardano6 = new List<(int, int)>
        {
            (0, 1),
            (0, 3),
            (1, 2),
            (2, 1),
            (2, 5),
            (3, 2),
            (4, 1),
            (4, 5),
            (5, 0),

            (0, 0),
            (1, 1),
            (1, 3),
            (1, 5),
            (2, 2),
            (2, 4),
            (3, 5),
            (5, 1),
            (5, 3),

            (0, 5),
            (1, 0),
            (1, 4),
            (2, 3),
            (3, 0),
            (3, 4),
            (4, 3),
            (5, 2),
            (5, 4),

            (0, 2),
            (0, 4),
            (2, 0),
            (3, 1),
            (3, 3),
            (4, 0),
            (4, 2),
            (4, 4),
            (5, 5)
        };
        
        private readonly List<(int, int)> gridCardano8 = new List<(int, int)>
        {
            (0, 1),
            (0, 5),
            (0, 7),
            (1, 0),
            (1, 3),
            (2, 2),
            (2, 4),
            (2, 7),
            (3, 1),
            (3, 5),
            (4, 3),
            (4, 7),
            (5, 1),
            (5, 6),
            (6, 1),
            (7, 4),

            (0, 6),
            (1, 1),
            (1, 2),
            (1, 4),
            (1, 7),
            (2, 5),
            (3, 3),
            (3, 6),
            (4, 0),
            (4, 5),
            (5, 4),
            (5, 7),
            (6, 2),
            (7, 3),
            (7, 5),
            (7, 7),

            (0, 3),
            (1, 6),
            (2, 1),
            (2, 6),
            (3, 0),
            (3, 4),
            (4, 2),
            (4, 6),
            (5, 0),
            (5, 3),
            (5, 5),
            (6, 4),
            (6, 7),
            (7, 0),
            (7, 2),
            (7, 6),

            (0, 0),
            (0, 2),
            (0, 4),
            (1, 5),
            (2, 0),
            (2, 3),
            (3, 2),
            (3, 7),
            (4, 1),
            (4, 4),
            (5, 2),
            (6, 0),
            (6, 3),
            (6, 5),
            (6, 6),
            (7, 1)
        };

        private readonly List<(int, int)> gridCardano10 = new List<(int, int)>
        {
            (0, 1),
            (0, 6),
            (0, 8),
            (1, 2),
            (1, 5),
            (2, 3),
            (2, 6),
            (2, 9),
            (3, 1),
            (3, 4),
            (3, 8),
            (4, 0),
            (4, 7),
            (5, 0),
            (5, 4),
            (5, 6),
            (6, 3),
            (7, 4),
            (7, 7),
            (7, 9),
            (8, 3),
            (8, 5),
            (8, 8),
            (9, 0),
            (9, 6),	

            (0, 0),
            (0, 4),
            (0, 5),
            (1, 6),
            (1, 9),
            (2, 1),
            (2, 8),
            (3, 3),
            (3, 7),
            (4, 2),
            (4, 4),
            (4, 6),
            (5, 1),
            (5, 8),
            (6, 0),
            (6, 4),
            (6, 7),
            (6, 9),
            (7, 2),
            (7, 5),
            (8, 1),
            (8, 6),
            (8, 9),
            (9, 2),
            (9, 7),	

            (0, 3),
            (0, 9),
            (1, 1),
            (1, 4),
            (1, 7),
            (2, 0),
            (2, 2),
            (2, 5),
            (3, 6),
            (4, 3),
            (4, 5),
            (4, 9),
            (5, 2),
            (5, 9),
            (6, 1),
            (6, 5),
            (6, 8),
            (7, 0),
            (7, 3),
            (7, 6),
            (8, 4),
            (8, 7),
            (9, 1),
            (9, 3),
            (9, 8),	

            (0, 2),
            (0, 7),
            (1, 0),
            (1, 3),
            (1, 8),
            (2, 4),
            (2, 7),
            (3, 0),
            (3, 2),
            (3, 5),
            (3, 9),
            (4, 1),
            (4, 8),
            (5, 3),
            (5, 5),
            (5, 7),
            (6, 2),
            (6, 6),
            (7, 1),
            (7, 8),
            (8, 0),
            (8, 3),
            (9, 4),
            (9, 5),
            (9, 9)
        };

    }
}