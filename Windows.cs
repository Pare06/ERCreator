using System.Runtime.InteropServices;

namespace ERCreator;

public class Windows
{
    [DllImport("kernel32.dll")]
    public static extern bool AllocConsole(); // alloca una console nel programma

    [DllImport("kernel32.dll")]
    public static extern IntPtr GetConsoleWindow(); // restituisce l'handle della console, se esiste

    [DllImport("user32.dll")]
    public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow); // mostra o nasconde la console

    public const int SW_HIDE = 0; // nascondi
    public const int SW_SHOW = 5; // mostra
}