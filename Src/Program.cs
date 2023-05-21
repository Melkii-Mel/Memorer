namespace Memorer.Src
{
    using MessagesClasses;
    internal static class Program
    {
        public static IOLogic iOLogic { get; private set; } = new();
        public static Messages? Messages { get; set; }
        public static DataGridViewHandler? DgvHandler { get; set; }
        public static Player? soundPlayer { get; set; } = new();
        public static Notificator Notificator { get; private set; } = new();
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public static Settings? settings { get; private set; }
        public static Form1 form1 { get; private set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            settings = iOLogic.GetStringsFromFile<Settings>(IOLogic.Files.Settings);
            if (settings == null)
            {
                settings = new();
            }
            form1 = new Form1();
            Application.Run(form1);
        }
    }
}