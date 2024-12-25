namespace ERCreator
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            // crea una console e la nasconde
            Windows.AllocConsole();
            Windows.ShowWindow(Windows.GetConsoleWindow(), Windows.SW_HIDE);

            ApplicationConfiguration.Initialize();
            Application.Run(new ERForm());
        }
    }
}