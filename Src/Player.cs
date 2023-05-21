using System.Media;

namespace Memorer.Src
{
    internal class Player : SoundPlayer
    {
        private const string DEFAULT_DIRECTORY = @"..\..\..\Data\Sounds";
        public bool IsPlayingLooping { get; private set; } = false;
        public enum Sounds
        {
            Success = 0,
            Notification = 1,
        }
        public readonly List<string> DefaultSoundFileNames = new List<string>()
        {
            "Success.wav",
            "Notification.wav",
        };

        public string?[] SoundFilePaths = new string?[2];

        public void SetSuccessSoundFilePath(string fileName)
        {
            if (SoundFilePaths == null) return;
            SoundFilePaths[0] = fileName;
        }

        public void SetNotificationSoundFilePath(string fileName)
        {
            if (SoundFilePaths == null) return;
            SoundFilePaths[1] = fileName;
        }

        public void ResetSuccessSoundFilePath()
        {
            if (SoundFilePaths == null) return;
            SoundFilePaths[0] = null;
        }
        public void ResetNotificationSoundFilePath()
        {
            if (SoundFilePaths == null) return;
            SoundFilePaths[1] = null;
        }

        public Player(string soundLocation) : base(soundLocation)
        {
        }
        public Player() : base()
        {
        }
        
        public void Play(Sounds sound)
        {
            try
            {
                if (SoundFilePaths[(int)sound] != null)
                {
                    SoundLocation = SoundFilePaths[(int)sound];
                    base.Play();
                    return;
                }
            }
            catch { }
            SoundLocation = Path.Combine(Directory.GetCurrentDirectory(), DEFAULT_DIRECTORY, DefaultSoundFileNames[(int)sound]);
            base.Play();
        }
        public void PlayLooping(Sounds sound)
        {
            try
            {
                if (SoundFilePaths != null && SoundFilePaths[(int)sound] != null)
                {
                    SoundLocation = SoundFilePaths[(int)sound];
                    IsPlayingLooping = true;
                    base.Play();
                    return;
                }
            }
            catch { }
            SoundLocation = Path.Combine(DEFAULT_DIRECTORY, DefaultSoundFileNames[(int)sound]);
            IsPlayingLooping = true;
            base.PlayLooping();
        }
        new public void Stop()
        {
            base.Stop();
            IsPlayingLooping = false;
        }
    }
}
