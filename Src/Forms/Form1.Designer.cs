namespace Memorer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            SetIsCalendarActiveTrue = new Button();
            SetIsCalendarActiveFalse = new Button();
            dateTimePicker1 = new DateTimePicker();
            DateTime = new Button();
            DateOnly = new Button();
            dateTimePicker2 = new DateTimePicker();
            label1 = new Label();
            textBox1 = new TextBox();
            AcceptButton = new Button();
            button1 = new Button();
            Close = new Button();
            notifyIcon1 = new NotifyIcon(components);
            timer1 = new System.Windows.Forms.Timer(components);
            Data = new DataGridView();
            NotificationTextBox = new TextBox();
            GotItButton = new Button();
            SettingsButton = new Button();
            ((System.ComponentModel.ISupportInitialize)Data).BeginInit();
            SuspendLayout();
            // 
            // SetIsCalendarActiveTrue
            // 
            SetIsCalendarActiveTrue.Location = new Point(12, 93);
            SetIsCalendarActiveTrue.Name = "SetIsCalendarActiveTrue";
            SetIsCalendarActiveTrue.Size = new Size(120, 23);
            SetIsCalendarActiveTrue.TabIndex = 1;
            SetIsCalendarActiveTrue.Text = "Кратковременный";
            SetIsCalendarActiveTrue.UseVisualStyleBackColor = true;
            SetIsCalendarActiveTrue.Click += SetIsCalendarActiveTrue_Click;
            // 
            // SetIsCalendarActiveFalse
            // 
            SetIsCalendarActiveFalse.Location = new Point(138, 93);
            SetIsCalendarActiveFalse.Name = "SetIsCalendarActiveFalse";
            SetIsCalendarActiveFalse.Size = new Size(177, 23);
            SetIsCalendarActiveFalse.TabIndex = 1;
            SetIsCalendarActiveFalse.Text = "Долговременный";
            SetIsCalendarActiveFalse.UseVisualStyleBackColor = true;
            SetIsCalendarActiveFalse.Click += SetIsCalendarActiveFalse_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(12, 12);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 2;
            dateTimePicker1.Visible = false;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // DateTime
            // 
            DateTime.Location = new Point(138, 120);
            DateTime.Name = "DateTime";
            DateTime.Size = new Size(88, 23);
            DateTime.TabIndex = 3;
            DateTime.Text = "Дата+Время";
            DateTime.UseVisualStyleBackColor = true;
            DateTime.Click += DateTime_Click;
            // 
            // DateOnly
            // 
            DateOnly.Location = new Point(232, 120);
            DateOnly.Name = "DateOnly";
            DateOnly.Size = new Size(83, 23);
            DateOnly.TabIndex = 4;
            DateOnly.Text = "Дата";
            DateOnly.UseVisualStyleBackColor = true;
            DateOnly.Click += DateOnly_Click;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(12, 41);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 5;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // label1
            // 
            label1.Location = new Point(12, 152);
            label1.Name = "label1";
            label1.Size = new Size(303, 23);
            label1.TabIndex = 6;
            label1.Text = "Режим: N/A";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            textBox1.ForeColor = SystemColors.InactiveCaption;
            textBox1.Location = new Point(12, 178);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(303, 148);
            textBox1.TabIndex = 7;
            textBox1.Text = "Поле для ввода текста";
            textBox1.Visible = false;
            textBox1.TextChanged += TextBox1_TextChanged;
            textBox1.Enter += TextBox1_Enter;
            textBox1.Leave += TextBox1_Leave;
            // 
            // AcceptButton
            // 
            AcceptButton.Enabled = false;
            AcceptButton.Location = new Point(12, 332);
            AcceptButton.Name = "AcceptButton";
            AcceptButton.Size = new Size(303, 25);
            AcceptButton.TabIndex = 8;
            AcceptButton.Text = "Применить";
            AcceptButton.UseVisualStyleBackColor = true;
            AcceptButton.Click += AcceptButton_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 363);
            button1.Name = "button1";
            button1.Size = new Size(303, 33);
            button1.TabIndex = 9;
            button1.Text = "Открыть созданные напоминания";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ShowDataGridViewButton_Click;
            // 
            // Close
            // 
            Close.Location = new Point(12, 363);
            Close.Name = "Close";
            Close.Size = new Size(303, 33);
            Close.TabIndex = 11;
            Close.Text = "Close";
            Close.UseVisualStyleBackColor = true;
            Close.Visible = false;
            Close.Click += Close_Click;
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipText = "Проверь приложение";
            notifyIcon1.BalloonTipTitle = "Новое упоминание";
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Memorer";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseClick += NotifyIcon1_MouseClick;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += Timer1_Tick;
            // 
            // Data
            // 
            Data.AllowUserToAddRows = false;
            Data.AllowUserToDeleteRows = false;
            Data.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Data.EditMode = DataGridViewEditMode.EditOnEnter;
            Data.Location = new Point(12, 12);
            Data.Name = "Data";
            Data.ReadOnly = true;
            Data.RowTemplate.Height = 25;
            Data.Size = new Size(303, 345);
            Data.TabIndex = 12;
            Data.Visible = false;
            Data.CellClick += Data_CellClick;
            // 
            // NotificationTextBox
            // 
            NotificationTextBox.Location = new Point(12, 12);
            NotificationTextBox.Multiline = true;
            NotificationTextBox.Name = "NotificationTextBox";
            NotificationTextBox.ReadOnly = true;
            NotificationTextBox.Size = new Size(303, 345);
            NotificationTextBox.TabIndex = 13;
            NotificationTextBox.TextAlign = HorizontalAlignment.Center;
            NotificationTextBox.Visible = false;
            // 
            // GotItButton
            // 
            GotItButton.Location = new Point(12, 363);
            GotItButton.Name = "GotItButton";
            GotItButton.Size = new Size(303, 33);
            GotItButton.TabIndex = 14;
            GotItButton.Text = "Понял";
            GotItButton.UseVisualStyleBackColor = true;
            GotItButton.Visible = false;
            GotItButton.Click += GotItButton_Click;
            // 
            // SettingsButton
            // 
            SettingsButton.Location = new Point(218, 14);
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Size = new Size(97, 50);
            SettingsButton.TabIndex = 15;
            SettingsButton.Text = "Настройки";
            SettingsButton.UseVisualStyleBackColor = true;
            SettingsButton.Click += SettingsButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 408);
            Controls.Add(GotItButton);
            Controls.Add(NotificationTextBox);
            Controls.Add(Data);
            Controls.Add(Close);
            Controls.Add(button1);
            Controls.Add(AcceptButton);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(dateTimePicker2);
            Controls.Add(DateOnly);
            Controls.Add(DateTime);
            Controls.Add(dateTimePicker1);
            Controls.Add(SetIsCalendarActiveFalse);
            Controls.Add(SetIsCalendarActiveTrue);
            Controls.Add(SettingsButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "Memorer";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            Resize += Form1_Resize;
            ((System.ComponentModel.ISupportInitialize)Data).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button SetIsCalendarActiveTrue;
        private Button SetIsCalendarActiveFalse;
        private DateTimePicker dateTimePicker1;
        private Button DateTime;
        private Button DateOnly;
        private DateTimePicker dateTimePicker2;
        private Label label1;
        private TextBox textBox1;
        new private Button AcceptButton;
        private Button button1;
        new private Button Close;
        private System.Windows.Forms.Timer timer1;
        private DataGridView Data;
        private TextBox NotificationTextBox;
        private Button GotItButton;
        private Button SettingsButton;
        public NotifyIcon notifyIcon1;
    }
}