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

namespace Potekhina_Vera___Steganography
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ReadWriteImageForEncrypting();
            MessageBox.Show("Текст помещен в графический контейнер");
        }

        private void ReadWriteImageForEncrypting()
        { 
            //считали картинку
            var bmp = new Bitmap("C:\\Users\\Вера\\RiderProjects\\Potekhina Vera - Steganography\\Potekhina Vera - Steganography\\verochka.bmp");
            pictureBox1.Image = Image.FromFile("C:\\Users\\Вера\\RiderProjects\\Potekhina Vera - Steganography\\Potekhina Vera - Steganography\\verochka.bmp");
            //переводим текст в бинарный код
            var arrayBinaryText = textIntoBinaryCode();
            //прячем текст в картинке
            bmp = EncryptingStringInImage(bmp, arrayBinaryText);
            //считываем имя для файла
            var nameFiles = textBox3.Text;
            //сохранили дубликат картинки
            bmp.Save("C:\\Users\\Вера\\RiderProjects\\Potekhina Vera - Steganography\\Potekhina Vera - Steganography\\" + nameFiles + ".bmp");
            pictureBox2.Image = Image.FromFile("C:\\Users\\Вера\\RiderProjects\\Potekhina Vera - Steganography\\Potekhina Vera - Steganography\\" + nameFiles + ".bmp");
        }
        
        //перевод текста в двоичный код - массив посимвольно
        private string[] textIntoBinaryCode()
        {
            var userString = textBox1.Text;
            string[] binaryText = new string[userString.Length];
            for (var i = 0; i < userString.Length; i++)
            {
                binaryText[i] = Convert.ToString(userString[i], 2);
                while (binaryText[i].Length < digitСapacity)
                {
                    binaryText[i] = "0" + binaryText[i];
                }
            }

            return binaryText;
        }

        private const int digitСapacity = 16;
        private string strForDecrypting;
        //засовывание картинки в текст
        private Bitmap EncryptingStringInImage(Bitmap image, string[] binaryText)
        {
            //i j должны меняться каждую итерацию, а х раз в три итерации
            var x = 0;
            var y = 0;
            var counterRGB = 0;
            int[] arrayForDecrypting = new int[digitСapacity * binaryText.Length];
            for (var i = 0; i < binaryText.Length; i++)
            {
                for (var j = 0; j < digitСapacity; j++)
                {
                    var pixel = image.GetPixel(x, y);
                    if (binaryText[i][j] != '0')
                    {
                        arrayForDecrypting[counterRGB] = 1;
                        
                    
                        var choiceOfColor = 0;
                        if (counterRGB % 3 == 0)
                            choiceOfColor = pixel.R;
                        else if (counterRGB % 3 == 1)
                            choiceOfColor = pixel.G;
                        else
                            choiceOfColor = pixel.B;   
                    
                        image.SetPixel(x, y, ColorChange(pixel, choiceOfColor, counterRGB));
                    }
                    else
                    {
                        arrayForDecrypting[counterRGB] = 0;
                    }
                    counterRGB++;
                    //шагаем по матрице изображения
                    if (x == image.Width - 1)
                    {
                        x = 0;
                        y++;
                    }
                    else if (counterRGB % 3 == 0)
                        x++;
                }
            }

            

            StringBuilder strDecr = new StringBuilder("");
            for (var i = 0; i < arrayForDecrypting.Length; i++)
                strDecr.Append(arrayForDecrypting[i]);
            strForDecrypting = strDecr.ToString();
            //textBox1.Text = strForDecrypting;
            return image;
        }

        private Color ColorChange(Color pixel, int choiceOfColor, int counterRGB)
        { 
            //изменение цвета
            var binaryColor = int.Parse(Convert.ToString(choiceOfColor, 2));
            if (binaryColor % 2 == 0)
                binaryColor++;
            else
                binaryColor--;

            var newBinaryColor = Convert.ToByte(binaryColor.ToString(), 2);
            var newColor = Color.FromArgb(0,0,0);

            if (counterRGB % 3 == 0)
                newColor = Color.FromArgb(newBinaryColor, pixel.G, pixel.B);
            else if (counterRGB % 3 == 1)
                newColor = Color.FromArgb(pixel.R, newBinaryColor, pixel.B);
            else
                newColor = Color.FromArgb(pixel.R, pixel.G, newBinaryColor);
            return newColor;
        }
        

        //достаем из картинки
        private string DecryptingStringInImage()
        {
            var decryptedString = new StringBuilder("");

            var i = 0;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap encryptedImage = new Bitmap(pictureBox2.Image);
            var str1 = new StringBuilder("");
            var str2 = new StringBuilder("");
            for (var y = 0; y < bmp.Height; y++)
            {
                for (var x = 0; x < bmp.Width; x++)
                {
                    if (i == strForDecrypting.Length/3 + 1)
                        break;
                    var pixel1 = bmp.GetPixel(x, y);
                    var pixel2 = encryptedImage.GetPixel(x, y);
                    

                    if (pixel1.R == pixel2.R)
                        decryptedString.Append("0");
                    else
                        decryptedString.Append("1");

                    if (pixel1.G == pixel2.G)
                        decryptedString.Append("0");
                    else
                        decryptedString.Append("1");

                    if (pixel1.B == pixel2.B)
                        decryptedString.Append("0");
                    else
                        decryptedString.Append("1");
                    i++;
                }
                if (i == strForDecrypting.Length/3 + 1)
                    break;
            }

            //textBox2.Text = str1.ToString();
            //textBox3.Text = str2.ToString();
            var decrString = decryptedString.ToString();

            //ГДЕ ТО ЗДЕСЬ КОСЯК
            var str = new StringBuilder("");
            var a = decrString.Length;
            for (i = 0; i < decrString.Length - decrString.Length % digitСapacity; i += digitСapacity)
            {
                var symbol = decrString.Substring(i, digitСapacity);
                str.Append((char) Convert.ToInt32(symbol, 2));
                //str.Append((char)Convert.ToByte(symbol, 2));
            }

            return str.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = DecryptingStringInImage();
            MessageBox.Show("Текст извлечен из графического контейнера");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            MessageBox.Show("Текстовые окна сброшены");
        }
    }
}