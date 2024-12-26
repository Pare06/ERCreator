using System.Management;
using System.Net.Sockets;
using System.Text;

namespace ERCreator;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        // controllo anti-pirateria
        string productKey = "cf9f0a56-5ce6-4089-97dc-35fa8a04e4d1"; // chiave hard-coded - non penso di fixarla ma nel dubbio TODO

        // ottiene il serial n. del primo hard disk
        ManagementObjectSearcher searcher = new("SELECT * FROM Win32_PhysicalMedia");
        string serial = "";
        foreach (ManagementObject disk in searcher.Get())
        {
            serial = disk["SerialNumber"]?.ToString()!;
            if (!string.IsNullOrEmpty(serial))
            {
                break;
            }
        }

        // cambiare
        string host = "5.tcp.eu.ngrok.io";
        int port = 14184;

        TcpClient? client = null;
        try
        {
            client = new(host, port);
            client.Client.Send(Encoding.UTF8.GetBytes($"{serial} {productKey}\n"));
            byte[] responseBuffer = new byte[1];
            client.Client.Receive(responseBuffer);

            if (responseBuffer[0] == 0)
            {
                MessageBox.Show("");
                return;
            }
        }
        catch
        {
            MessageBox.Show("Il server anti-pirateria è offline :(");
        }
        finally
        {
            client?.Dispose();
        }

        // crea una console e la nasconde
        Windows.AllocConsole();
        Windows.ShowWindow(Windows.GetConsoleWindow(), Windows.SW_HIDE);

        ApplicationConfiguration.Initialize();
        Application.Run(new ERForm());
    }
}