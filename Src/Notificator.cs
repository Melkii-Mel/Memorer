using Memorer.Src.MessagesClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Message = Memorer.Src.MessagesClasses.Message;

namespace Memorer.Src
{
    internal class Notificator
    {
        private List<Message> uncheckedMessages = new();
        private Message _currentMessage;

        public void CheckMessages()
        {
            Messages? messages = Program.Messages;
            if (messages == null)
            {
                return;
            }
            Message? message = messages.CheckMessages();
            if (message == null)
            {
                return;
            }
            if (!uncheckedMessages.Contains(message))
            {
                uncheckedMessages.Add(message);
            }

            ShowUncheckedMessages();
            CheckWindowState();
        }
        private void ShowUncheckedMessages()
        {
            if (uncheckedMessages.Count == 0)
            {
                return;
            }
            _currentMessage = uncheckedMessages.First();
            ShowMessage(_currentMessage);
        }
        private void CheckWindowState()
        {
            if (Program.form1.WindowState != FormWindowState.Minimized)
            {
                StopNotificationSound();
                return;
            }
            PlayNotificationSound();
            return;
        }

        private void PlayNotificationSound()
        {
            if (Program.form1.WindowState != FormWindowState.Minimized)
            {
                return;
            }
            if (Program.soundPlayer == null || Program.soundPlayer.IsPlayingLooping)
            {
                return;
            }
            Program.soundPlayer.PlayLooping(Player.Sounds.Notification);
        }
        private void ShowMessage(Message message)
        {
            Program.form1.SetMessageBoxText($"Время: {message.DateTime}\r\nСобытие: {message.Content}");
            Program.form1.ShowMessageBoxAndButton();
        }
        
        public void StopNotificationSound()
        {
            Program.soundPlayer?.Stop();
        }

        public void DeleteMessage()
        {
            Program.Messages?.Remove(_currentMessage);
            uncheckedMessages.Remove(_currentMessage);
            Program.form1.HideMessageBoxAndButton();
            CheckMessages();
        }
    }
}
