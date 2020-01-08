namespace Potekhina_Vera___Encrypted_by_permutation
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_decryptedString = new System.Windows.Forms.TextBox();
            this.label_decryptedString = new System.Windows.Forms.Label();
            this.userString = new System.Windows.Forms.TextBox();
            this.listOfEncryptionOptions = new System.Windows.Forms.ComboBox();
            this.label_selectEncryptionOption = new System.Windows.Forms.Label();
            this.textBox_countPermutations = new System.Windows.Forms.TextBox();
            this.label_countPermutations = new System.Windows.Forms.Label();
            this.label_listOfPermutations = new System.Windows.Forms.Label();
            this.textBox_listOfPermutations = new System.Windows.Forms.TextBox();
            this.listOfGridSizes = new System.Windows.Forms.ComboBox();
            this.label_selectSizeOfGrid = new System.Windows.Forms.Label();
            this.label_encryptedString = new System.Windows.Forms.Label();
            this.encryptedButton = new System.Windows.Forms.Button();
            this.decryptedButton = new System.Windows.Forms.Button();
            this.textBox_encryptedString = new System.Windows.Forms.TextBox();
            this.label_userString = new System.Windows.Forms.Label();
            this.label_LinearPermutation = new System.Windows.Forms.Label();
            this.label_CardanoGrid = new System.Windows.Forms.Label();
            this.label_RoutePermutation = new System.Windows.Forms.Label();
            this.label_countOfColumns = new System.Windows.Forms.Label();
            this.textBox_countOfColumns = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_decryptedString
            // 
            this.textBox_decryptedString.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBox_decryptedString.Location = new System.Drawing.Point(510, 499);
            this.textBox_decryptedString.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_decryptedString.Multiline = true;
            this.textBox_decryptedString.Name = "textBox_decryptedString";
            this.textBox_decryptedString.Size = new System.Drawing.Size(470, 126);
            this.textBox_decryptedString.TabIndex = 15;
            // 
            // label_decryptedString
            // 
            this.label_decryptedString.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label_decryptedString.Location = new System.Drawing.Point(510, 467);
            this.label_decryptedString.Name = "label_decryptedString";
            this.label_decryptedString.Size = new System.Drawing.Size(300, 30);
            this.label_decryptedString.TabIndex = 16;
            this.label_decryptedString.Text = "Расшифрованная строка:";
            // 
            // userString
            // 
            this.userString.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.userString.Location = new System.Drawing.Point(20, 42);
            this.userString.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userString.Multiline = true;
            this.userString.Name = "userString";
            this.userString.Size = new System.Drawing.Size(960, 90);
            this.userString.TabIndex = 17;
            // 
            // listOfEncryptionOptions
            // 
            this.listOfEncryptionOptions.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listOfEncryptionOptions.FormattingEnabled = true;
            this.listOfEncryptionOptions.Items.AddRange(new object[]
                {"Линейная перестановка", "Решетка Кардано", "Табличная маршрутная перестановка"});
            this.listOfEncryptionOptions.Location = new System.Drawing.Point(20, 166);
            this.listOfEncryptionOptions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listOfEncryptionOptions.Name = "listOfEncryptionOptions";
            this.listOfEncryptionOptions.Size = new System.Drawing.Size(960, 31);
            this.listOfEncryptionOptions.TabIndex = 19;
            // 
            // label_selectEncryptionOption
            // 
            this.label_selectEncryptionOption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label_selectEncryptionOption.Location = new System.Drawing.Point(20, 134);
            this.label_selectEncryptionOption.Name = "label_selectEncryptionOption";
            this.label_selectEncryptionOption.Size = new System.Drawing.Size(300, 30);
            this.label_selectEncryptionOption.TabIndex = 20;
            this.label_selectEncryptionOption.Text = "Выберите способ шифрования:";
            // 
            // textBox_countPermutations
            // 
            this.textBox_countPermutations.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBox_countPermutations.Location = new System.Drawing.Point(19, 281);
            this.textBox_countPermutations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_countPermutations.Multiline = true;
            this.textBox_countPermutations.Name = "textBox_countPermutations";
            this.textBox_countPermutations.Size = new System.Drawing.Size(300, 30);
            this.textBox_countPermutations.TabIndex = 21;
            // 
            // label_countPermutations
            // 
            this.label_countPermutations.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label_countPermutations.Location = new System.Drawing.Point(20, 249);
            this.label_countPermutations.Name = "label_countPermutations";
            this.label_countPermutations.Size = new System.Drawing.Size(300, 30);
            this.label_countPermutations.TabIndex = 22;
            this.label_countPermutations.Text = "Введите количество перестановок:";
            // 
            // label_listOfPermutations
            // 
            this.label_listOfPermutations.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label_listOfPermutations.Location = new System.Drawing.Point(20, 323);
            this.label_listOfPermutations.Name = "label_listOfPermutations";
            this.label_listOfPermutations.Size = new System.Drawing.Size(300, 30);
            this.label_listOfPermutations.TabIndex = 23;
            this.label_listOfPermutations.Text = "Введите схему перестановок:";
            // 
            // textBox_listOfPermutations
            // 
            this.textBox_listOfPermutations.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBox_listOfPermutations.Location = new System.Drawing.Point(20, 355);
            this.textBox_listOfPermutations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_listOfPermutations.Multiline = true;
            this.textBox_listOfPermutations.Name = "textBox_listOfPermutations";
            this.textBox_listOfPermutations.Size = new System.Drawing.Size(300, 30);
            this.textBox_listOfPermutations.TabIndex = 24;
            // 
            // listOfGridSizes
            // 
            this.listOfGridSizes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listOfGridSizes.FormattingEnabled = true;
            this.listOfGridSizes.Items.AddRange(new object[] {"2", "4", "6", "8", "10"});
            this.listOfGridSizes.Location = new System.Drawing.Point(348, 282);
            this.listOfGridSizes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listOfGridSizes.Name = "listOfGridSizes";
            this.listOfGridSizes.Size = new System.Drawing.Size(300, 31);
            this.listOfGridSizes.TabIndex = 25;
            // 
            // label_selectSizeOfGrid
            // 
            this.label_selectSizeOfGrid.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label_selectSizeOfGrid.Location = new System.Drawing.Point(348, 249);
            this.label_selectSizeOfGrid.Name = "label_selectSizeOfGrid";
            this.label_selectSizeOfGrid.Size = new System.Drawing.Size(300, 30);
            this.label_selectSizeOfGrid.TabIndex = 26;
            this.label_selectSizeOfGrid.Text = "Выберите размер решетки Кардано:";
            // 
            // label_encryptedString
            // 
            this.label_encryptedString.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label_encryptedString.Location = new System.Drawing.Point(20, 467);
            this.label_encryptedString.Name = "label_encryptedString";
            this.label_encryptedString.Size = new System.Drawing.Size(300, 30);
            this.label_encryptedString.TabIndex = 27;
            this.label_encryptedString.Text = "Зашифрованная строка:";
            // 
            // encryptedButton
            // 
            this.encryptedButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.encryptedButton.Location = new System.Drawing.Point(20, 407);
            this.encryptedButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.encryptedButton.Name = "encryptedButton";
            this.encryptedButton.Size = new System.Drawing.Size(470, 58);
            this.encryptedButton.TabIndex = 28;
            this.encryptedButton.Text = "Зашифровать";
            this.encryptedButton.UseVisualStyleBackColor = true;
            this.encryptedButton.Click += new System.EventHandler(this.encryptedButton_Click);
            // 
            // decryptedButton
            // 
            this.decryptedButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.decryptedButton.Location = new System.Drawing.Point(510, 407);
            this.decryptedButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.decryptedButton.Name = "decryptedButton";
            this.decryptedButton.Size = new System.Drawing.Size(470, 58);
            this.decryptedButton.TabIndex = 29;
            this.decryptedButton.Text = "Расшифровать";
            this.decryptedButton.UseVisualStyleBackColor = true;
            this.decryptedButton.Click += new System.EventHandler(this.decryptedButton_Click);
            // 
            // textBox_encryptedString
            // 
            this.textBox_encryptedString.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBox_encryptedString.Location = new System.Drawing.Point(20, 499);
            this.textBox_encryptedString.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_encryptedString.Multiline = true;
            this.textBox_encryptedString.Name = "textBox_encryptedString";
            this.textBox_encryptedString.Size = new System.Drawing.Size(470, 126);
            this.textBox_encryptedString.TabIndex = 30;
            // 
            // label_userString
            // 
            this.label_userString.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label_userString.Location = new System.Drawing.Point(20, 10);
            this.label_userString.Name = "label_userString";
            this.label_userString.Size = new System.Drawing.Size(300, 30);
            this.label_userString.TabIndex = 31;
            this.label_userString.Text = "Введите текст для шифрования:";
            // 
            // label_LinearPermutation
            // 
            this.label_LinearPermutation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label_LinearPermutation.Location = new System.Drawing.Point(20, 219);
            this.label_LinearPermutation.Name = "label_LinearPermutation";
            this.label_LinearPermutation.Size = new System.Drawing.Size(300, 30);
            this.label_LinearPermutation.TabIndex = 32;
            this.label_LinearPermutation.Text = "Линейная перестановка";
            // 
            // label_CardanoGrid
            // 
            this.label_CardanoGrid.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label_CardanoGrid.Location = new System.Drawing.Point(348, 219);
            this.label_CardanoGrid.Name = "label_CardanoGrid";
            this.label_CardanoGrid.Size = new System.Drawing.Size(300, 30);
            this.label_CardanoGrid.TabIndex = 33;
            this.label_CardanoGrid.Text = "Решетка Кардано";
            // 
            // label_RoutePermutation
            // 
            this.label_RoutePermutation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label_RoutePermutation.Location = new System.Drawing.Point(680, 219);
            this.label_RoutePermutation.Name = "label_RoutePermutation";
            this.label_RoutePermutation.Size = new System.Drawing.Size(300, 30);
            this.label_RoutePermutation.TabIndex = 34;
            this.label_RoutePermutation.Text = "Маршрутная перестановка";
            // 
            // label_countOfColumns
            // 
            this.label_countOfColumns.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label_countOfColumns.Location = new System.Drawing.Point(680, 249);
            this.label_countOfColumns.Name = "label_countOfColumns";
            this.label_countOfColumns.Size = new System.Drawing.Size(300, 30);
            this.label_countOfColumns.TabIndex = 35;
            this.label_countOfColumns.Text = "Введите количество столбцов:";
            // 
            // textBox_countOfColumns
            // 
            this.textBox_countOfColumns.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBox_countOfColumns.Location = new System.Drawing.Point(680, 282);
            this.textBox_countOfColumns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_countOfColumns.Multiline = true;
            this.textBox_countOfColumns.Name = "textBox_countOfColumns";
            this.textBox_countOfColumns.Size = new System.Drawing.Size(300, 30);
            this.textBox_countOfColumns.TabIndex = 36;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (192)))), ((int) (((byte) (255)))),
                ((int) (((byte) (192)))));
            this.ClientSize = new System.Drawing.Size(1002, 652);
            this.Controls.Add(this.textBox_countOfColumns);
            this.Controls.Add(this.label_countOfColumns);
            this.Controls.Add(this.label_RoutePermutation);
            this.Controls.Add(this.label_CardanoGrid);
            this.Controls.Add(this.label_LinearPermutation);
            this.Controls.Add(this.label_userString);
            this.Controls.Add(this.textBox_encryptedString);
            this.Controls.Add(this.decryptedButton);
            this.Controls.Add(this.encryptedButton);
            this.Controls.Add(this.label_encryptedString);
            this.Controls.Add(this.label_selectSizeOfGrid);
            this.Controls.Add(this.listOfGridSizes);
            this.Controls.Add(this.textBox_listOfPermutations);
            this.Controls.Add(this.label_listOfPermutations);
            this.Controls.Add(this.label_countPermutations);
            this.Controls.Add(this.textBox_countPermutations);
            this.Controls.Add(this.label_selectEncryptionOption);
            this.Controls.Add(this.listOfEncryptionOptions);
            this.Controls.Add(this.userString);
            this.Controls.Add(this.label_decryptedString);
            this.Controls.Add(this.textBox_decryptedString);
            this.Location = new System.Drawing.Point(19, 19);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Potekhina Vera - Encrypted by permutation";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        
        private System.Windows.Forms.Label label_encryptedString;
        private System.Windows.Forms.Label label_selectSizeOfGrid;
        private System.Windows.Forms.ComboBox listOfGridSizes;
        private System.Windows.Forms.TextBox textBox_listOfPermutations;
        private System.Windows.Forms.Label label_listOfPermutations;
        private System.Windows.Forms.Label label_countPermutations;
        private System.Windows.Forms.TextBox textBox_countPermutations;
        private System.Windows.Forms.Label label_selectEncryptionOption;
        private System.Windows.Forms.ComboBox listOfEncryptionOptions;
        private System.Windows.Forms.Label label_userString;
        private System.Windows.Forms.TextBox userString;
        private System.Windows.Forms.Label label_decryptedString;
        private System.Windows.Forms.TextBox textBox_decryptedString;
        private System.Windows.Forms.Button encryptedButton;
        private System.Windows.Forms.Button decryptedButton;
/*
        private System.Windows.Forms.TextBox textBox_encryptedString;
*/
        private System.Windows.Forms.TextBox textBox_encryptedString;
        private System.Windows.Forms.Label label_CardanoGrid;
        private System.Windows.Forms.Label label_LinearPermutation;
        private System.Windows.Forms.Label label_RoutePermutation;
        private System.Windows.Forms.TextBox textBox_countOfColumns;
        private System.Windows.Forms.Label label_countOfColumns;
    }
}