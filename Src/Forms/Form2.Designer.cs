namespace Memorer
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            openFileDialog1 = new OpenFileDialog();
            ChangeSuccessSound = new Button();
            ChangeNotificationSounButton = new Button();
            ResetSuccess = new Button();
            ResetNotification = new Button();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "Wave-файлы|*.wav";
            openFileDialog1.Title = "Выбор файла со звуком";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // ChangeSuccessSound
            // 
            ChangeSuccessSound.Location = new Point(12, 12);
            ChangeSuccessSound.Name = "ChangeSuccessSound";
            ChangeSuccessSound.Size = new Size(201, 35);
            ChangeSuccessSound.TabIndex = 0;
            ChangeSuccessSound.Text = "Изменить звук подтверждения...";
            ChangeSuccessSound.UseVisualStyleBackColor = true;
            ChangeSuccessSound.Click += ChangeSuccessSound_Click;
            // 
            // ChangeNotificationSounButton
            // 
            ChangeNotificationSounButton.Location = new Point(12, 53);
            ChangeNotificationSounButton.Name = "ChangeNotificationSounButton";
            ChangeNotificationSounButton.Size = new Size(201, 35);
            ChangeNotificationSounButton.TabIndex = 1;
            ChangeNotificationSounButton.Text = "Изменить звук уведомления...";
            ChangeNotificationSounButton.UseVisualStyleBackColor = true;
            ChangeNotificationSounButton.Click += ChangeNotificationSounButton_Click;
            // 
            // ResetSuccess
            // 
            ResetSuccess.Location = new Point(219, 12);
            ResetSuccess.Name = "ResetSuccess";
            ResetSuccess.Size = new Size(102, 35);
            ResetSuccess.TabIndex = 2;
            ResetSuccess.Text = "Сбросить";
            ResetSuccess.UseVisualStyleBackColor = true;
            ResetSuccess.Click += ResetSuccess_Click;
            // 
            // ResetNotification
            // 
            ResetNotification.Location = new Point(219, 53);
            ResetNotification.Name = "ResetNotification";
            ResetNotification.Size = new Size(102, 35);
            ResetNotification.TabIndex = 3;
            ResetNotification.Text = "Сбросить";
            ResetNotification.UseVisualStyleBackColor = true;
            ResetNotification.Click += ResetNotification_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 408);
            Controls.Add(ResetNotification);
            Controls.Add(ResetSuccess);
            Controls.Add(ChangeNotificationSounButton);
            Controls.Add(ChangeSuccessSound);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form2";
            Text = "Настройки";
            ResumeLayout(false);
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private Button ChangeSuccessSound;
        private Button ChangeNotificationSounButton;
        private Button ResetSuccess;
        private Button ResetNotification;
    }
}