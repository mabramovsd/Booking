namespace Booking3
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.FilterPanel = new System.Windows.Forms.Panel();
            this.RatingComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.FilterButton = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CityComboBox = new System.Windows.Forms.ComboBox();
            this.AdminButton = new System.Windows.Forms.Button();
            this.HotelsPanel = new System.Windows.Forms.Panel();
            this.AuthPanel = new System.Windows.Forms.Panel();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.HelloLabel = new System.Windows.Forms.Label();
            this.AccountButton = new System.Windows.Forms.Button();
            this.FilterPanel.SuspendLayout();
            this.AuthPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // FilterPanel
            // 
            this.FilterPanel.Controls.Add(this.RatingComboBox);
            this.FilterPanel.Controls.Add(this.label6);
            this.FilterPanel.Controls.Add(this.button1);
            this.FilterPanel.Controls.Add(this.dateTimePicker2);
            this.FilterPanel.Controls.Add(this.label3);
            this.FilterPanel.Controls.Add(this.FilterButton);
            this.FilterPanel.Controls.Add(this.dateTimePicker1);
            this.FilterPanel.Controls.Add(this.label2);
            this.FilterPanel.Controls.Add(this.label1);
            this.FilterPanel.Controls.Add(this.CityComboBox);
            this.FilterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FilterPanel.Location = new System.Drawing.Point(0, 35);
            this.FilterPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FilterPanel.Name = "FilterPanel";
            this.FilterPanel.Size = new System.Drawing.Size(630, 114);
            this.FilterPanel.TabIndex = 0;
            // 
            // RatingComboBox
            // 
            this.RatingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RatingComboBox.FormattingEnabled = true;
            this.RatingComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.RatingComboBox.Location = new System.Drawing.Point(83, 82);
            this.RatingComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RatingComboBox.Name = "RatingComboBox";
            this.RatingComboBox.Size = new System.Drawing.Size(162, 28);
            this.RatingComboBox.TabIndex = 9;
            this.RatingComboBox.SelectedIndexChanged += new System.EventHandler(this.RatingComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 86);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Рейтинг";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(553, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 73);
            this.button1.TabIndex = 7;
            this.button1.Text = "Найти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Filter);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(372, 81);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(173, 26);
            this.dateTimePicker2.TabIndex = 6;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Дата выезда";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // FilterButton
            // 
            this.FilterButton.Location = new System.Drawing.Point(0, 0);
            this.FilterButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(112, 35);
            this.FilterButton.TabIndex = 4;
            this.FilterButton.Text = "Фильтр";
            this.FilterButton.UseVisualStyleBackColor = true;
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(372, 49);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(173, 26);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Дата заезда";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Город";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // CityComboBox
            // 
            this.CityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CityComboBox.FormattingEnabled = true;
            this.CityComboBox.Items.AddRange(new object[] {
            "Красноярск",
            "Ульяновск",
            "Хабаровск"});
            this.CityComboBox.Location = new System.Drawing.Point(83, 47);
            this.CityComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CityComboBox.Name = "CityComboBox";
            this.CityComboBox.Size = new System.Drawing.Size(162, 28);
            this.CityComboBox.TabIndex = 0;
            this.CityComboBox.SelectedIndexChanged += new System.EventHandler(this.CityComboBox_SelectedIndexChanged);
            // 
            // AdminButton
            // 
            this.AdminButton.Location = new System.Drawing.Point(486, 2);
            this.AdminButton.Name = "AdminButton";
            this.AdminButton.Size = new System.Drawing.Size(141, 33);
            this.AdminButton.TabIndex = 8;
            this.AdminButton.Text = "Вход в админку";
            this.AdminButton.UseVisualStyleBackColor = true;
            this.AdminButton.Visible = false;
            this.AdminButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // HotelsPanel
            // 
            this.HotelsPanel.AutoScroll = true;
            this.HotelsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HotelsPanel.Location = new System.Drawing.Point(0, 149);
            this.HotelsPanel.Name = "HotelsPanel";
            this.HotelsPanel.Size = new System.Drawing.Size(630, 202);
            this.HotelsPanel.TabIndex = 1;
            // 
            // AuthPanel
            // 
            this.AuthPanel.AutoScroll = true;
            this.AuthPanel.Controls.Add(this.AccountButton);
            this.AuthPanel.Controls.Add(this.PasswordLabel);
            this.AuthPanel.Controls.Add(this.LoginLabel);
            this.AuthPanel.Controls.Add(this.PasswordTextBox);
            this.AuthPanel.Controls.Add(this.LoginTextBox);
            this.AuthPanel.Controls.Add(this.LoginButton);
            this.AuthPanel.Controls.Add(this.AdminButton);
            this.AuthPanel.Controls.Add(this.HelloLabel);
            this.AuthPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AuthPanel.Location = new System.Drawing.Point(0, 0);
            this.AuthPanel.Name = "AuthPanel";
            this.AuthPanel.Size = new System.Drawing.Size(630, 35);
            this.AuthPanel.TabIndex = 2;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(171, 10);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(67, 20);
            this.PasswordLabel.TabIndex = 13;
            this.PasswordLabel.Text = "Пароль";
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Location = new System.Drawing.Point(4, 8);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(55, 20);
            this.LoginLabel.TabIndex = 12;
            this.LoginLabel.Text = "Логин";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(244, 3);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(100, 26);
            this.PasswordTextBox.TabIndex = 11;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Location = new System.Drawing.Point(65, 5);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(100, 26);
            this.LoginTextBox.TabIndex = 10;
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(350, 0);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 31);
            this.LoginButton.TabIndex = 9;
            this.LoginButton.Text = "Вход";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginClick);
            // 
            // HelloLabel
            // 
            this.HelloLabel.AutoSize = true;
            this.HelloLabel.Location = new System.Drawing.Point(171, 9);
            this.HelloLabel.Name = "HelloLabel";
            this.HelloLabel.Size = new System.Drawing.Size(51, 20);
            this.HelloLabel.TabIndex = 14;
            this.HelloLabel.Text = "label6";
            // 
            // AccountButton
            // 
            this.AccountButton.Location = new System.Drawing.Point(0, 2);
            this.AccountButton.Name = "AccountButton";
            this.AccountButton.Size = new System.Drawing.Size(157, 33);
            this.AccountButton.TabIndex = 15;
            this.AccountButton.Text = "Личный кабинет";
            this.AccountButton.UseVisualStyleBackColor = true;
            this.AccountButton.Visible = false;
            this.AccountButton.Click += new System.EventHandler(this.AccountButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 351);
            this.Controls.Add(this.HotelsPanel);
            this.Controls.Add(this.FilterPanel);
            this.Controls.Add(this.AuthPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Главная";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FilterPanel.ResumeLayout(false);
            this.FilterPanel.PerformLayout();
            this.AuthPanel.ResumeLayout(false);
            this.AuthPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel FilterPanel;
        private System.Windows.Forms.Button FilterButton;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CityComboBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel HotelsPanel;
        private System.Windows.Forms.Button AdminButton;
        private System.Windows.Forms.Panel AuthPanel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label HelloLabel;
        private System.Windows.Forms.ComboBox RatingComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button AccountButton;
    }
}

