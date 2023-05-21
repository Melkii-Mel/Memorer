using Memorer.Src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memorer
{
    public partial class Form2 : Form
    {
        private byte _buttonNumber;
        public Form2()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = openFileDialog1.FileName;
            if (Program.soundPlayer == null)
            {
                return;
            }
            if (Program.settings == null)
            {
                return;
            }
            if (_buttonNumber == 0)
            {
                Program.settings.SuccessSoundFileName = filePath;
                Program.soundPlayer.SetSuccessSoundFilePath(filePath);
            }
            else if (_buttonNumber == 1)
            {
                Program.settings.NotificationSoundFileName = filePath;
                Program.soundPlayer.SetNotificationSoundFilePath(filePath);
            }

            Program.settings.SaveSettingsToFile();
        }

        private void ChangeSuccessSound_Click(object sender, EventArgs e)
        {
            _buttonNumber = 0;
            openFileDialog1.ShowDialog();
        }

        private void ChangeNotificationSounButton_Click(object sender, EventArgs e)
        {
            _buttonNumber = 1;
            openFileDialog1.ShowDialog();
        }

        private void ResetSuccess_Click(object sender, EventArgs e)
        {
            if (Program.settings == null)
            {
                throw new Exception("Ошибка загрузки настроек");
            }
            Program.settings.SuccessSoundFileName = null;
            Program.soundPlayer?.ResetSuccessSoundFilePath();
            Program.settings.SaveSettingsToFile();
        }

        private void ResetNotification_Click(object sender, EventArgs e)
        {
            if (Program.settings == null)
            {
                throw new Exception("Ошибка загрузки настроек");
            }
            Program.settings.NotificationSoundFileName = null;
            Program.settings.SaveSettingsToFile();
            Program.soundPlayer?.ResetNotificationSoundFilePath();
        }
    }
}
