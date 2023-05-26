using Memorer.Src;
using Memorer.Src.MessagesClasses;
using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;
using System.DirectoryServices.ActiveDirectory;
using System.Media;
using System.Xml.Linq;
using Message = Memorer.Src.MessagesClasses.Message;

namespace Memorer
{
    public partial class Form1 : Form
    {
        private Modes.Mode _mode;
        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.CustomFormat = "HH:mm (чч:мм)";
            dateTimePicker1.Format = DateTimePickerFormat.Long;
            dateTimePicker2.Visible = false;
            dateTimePicker2.CustomFormat = "HH:mm (чч:мм)";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Value = System.DateTime.ParseExact("00:00", "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            dateTimePicker2.ShowUpDown = true;
            DateTime.Visible = false;
            DateOnly.Visible = false;
            notifyIcon1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            uint triesCounter = 0;
            while (Program.Messages == null && triesCounter <= 100)
            {
                Program.Messages = Program.iOLogic.GetStringsFromFile<Messages>(IOLogic.Files.Messages);
                triesCounter++;
            }
            if (Program.Messages == null)
            {
                Program.Messages = new();
            }
            Program.DgvHandler = new(Data, Program.Messages);
            Program.Notificator.CheckMessages();
            new AutorunHandler().Init();
            if (Program.settings != null)
            {
                if (Program.settings.SuccessSoundFileName != null)
                {
                    Program.soundPlayer?.SetSuccessSoundFilePath(Program.settings.SuccessSoundFileName);
                }
                if (Program.settings.NotificationSoundFileName != null)
                {
                    Program.soundPlayer?.SetNotificationSoundFilePath(Program.settings.NotificationSoundFileName);
                }
            }
        }

        private void SetIsCalendarActiveFalse_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = false;
            dateTimePicker1.Format = DateTimePickerFormat.Long;
            dateTimePicker1.ShowUpDown = false;
            SetIsCalendarActiveFalse.Enabled = false;
            SetIsCalendarActiveTrue.Enabled = true;
            DateTime.Enabled = true;
            DateOnly.Enabled = true;
            DateTime.Visible = true;
            DateOnly.Visible = true;
            label1.Text = "Режим: Упоминание в конкретный день...";
            _mode = Modes.Mode.DateOnly;
            textBox1.Visible = false;
        }

        private void SetIsCalendarActiveTrue_Click(object sender, EventArgs e)
        {
            dateTimePicker2.Visible = false;
            dateTimePicker1.Visible = true;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Value = System.DateTime.ParseExact("00:00", "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            dateTimePicker1.ShowUpDown = true;
            SetIsCalendarActiveTrue.Enabled = false;
            SetIsCalendarActiveFalse.Enabled = true;
            DateTime.Visible = false;
            DateOnly.Visible = false;
            label1.Text = "Режим: Упоминание сегодня.";
            _mode = Modes.Mode.TimeOnly;
            textBox1.Visible = true;
        }

        private void DateTime_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            DateTime.Enabled = false;
            DateOnly.Enabled = true;
            label1.Text = "Режим: Упоминание в конкретный день и время";
            _mode = Modes.Mode.DateTime;
            textBox1.Visible = true;
            dateTimePicker1.Focus();
        }

        private void DateOnly_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = false;
            DateOnly.Enabled = false;
            DateTime.Enabled = true;
            label1.Text = "Режим: Упоминание в конкретный день";
            textBox1.Visible = true;
            dateTimePicker1.Focus();
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Поле для ввода текста")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Поле для ввода текста";
                textBox1.ForeColor = SystemColors.InactiveCaption;
            }
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            DateTime datetime;
            if (_mode == Modes.Mode.DateTime)
            {
                datetime = dateTimePicker1.Value.Date;
                datetime += dateTimePicker2.Value.TimeOfDay;
            }
            else if (_mode == Modes.Mode.TimeOnly)
            {
                datetime = dateTimePicker1.Value;
            }
            else
            {
                datetime = dateTimePicker1.Value.Date;
            }
            while (Program.Messages == null)
            {
                Program.Messages = Program.iOLogic.GetStringsFromFile<Messages>(IOLogic.Files.Messages);
            }
            Program.Messages.Add(new Message(text, datetime));
            AcceptButton.Enabled = false;
            if (Program.soundPlayer == null)
            {
                throw new Exception("Sound player didn't load");
            }
            Program.soundPlayer.Play(Player.Sounds.Success);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            SetAcceptButtonState();
        }

        private void ShowDataGridViewButton_Click(object sender, EventArgs e)
        {
            Close.Visible = true;
            Data.Visible = true;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close.Visible = false;
            Data.Visible = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            HideOrShow();
        }

        private void HideOrShow()
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            ShowForm(sender, e);
        }

        public void ShowForm(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Form1_Resize(sender, e);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Program.Notificator.CheckMessages();
        }

        private void Data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Program.DgvHandler?.HandleCellClick(e);
        }

        public void ShowMessageBoxAndButton()
        {
            GotItButton.Visible = true;
            NotificationTextBox.Visible = true;
        }

        public void HideMessageBoxAndButton()
        {
            GotItButton.Visible = false;
            NotificationTextBox.Visible = false;
        }

        public void SetMessageBoxText(string text)
        {
            NotificationTextBox.Text = text;
        }

        private void GotItButton_Click(object sender, EventArgs e)
        {
            Program.Notificator.DeleteMessage();
        }

        private void SetAcceptButtonState()
        {
            if (textBox1.Text == "" || textBox1.Text == "Поле для ввода текста")
            {
                AcceptButton.Enabled = false;
                return;
            }
            if (GetDateTime() <= System.DateTime.Now)
            {
                AcceptButton.Enabled = false;
                return;
            }
            AcceptButton.Enabled = true;
            return;
        }

        private DateTime GetDateTime()
        {
            DateTime datetime;
            if (_mode == Modes.Mode.DateTime)
            {
                datetime = dateTimePicker1.Value.Date;
                datetime += dateTimePicker2.Value.TimeOfDay;
                return datetime;
            }
            if (_mode == Modes.Mode.TimeOnly)
            {
                datetime = dateTimePicker1.Value;
                return datetime;
            }
            datetime = dateTimePicker1.Value.Date;
            return datetime;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SetAcceptButtonState();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            SetAcceptButtonState();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift || Control.ModifierKeys == Keys.Control)
            {
                return;
            }
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
            HideOrShow();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            Form2 form2 = new();
            form2.ShowDialog();
        }
    }
}