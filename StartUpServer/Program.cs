using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StartUpServer
{
    class Program
    {
        [DllImport("Kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();
        [DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int cmdShow);

        public async Task StartUp()
        {
            try
            {
                await Task.Delay(700);
                Process process = new Process();
                process.StartInfo.WorkingDirectory = @"C:\tools\dart-sdk\bin";
                process.StartInfo.FileName = "dart.exe";
                process.StartInfo.Arguments = @"C:\Users\Administrador\Desktop\rutero_server\bin\main.dart";
                process.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                await Task.Delay(1000);
                await StartUp();
            }
        }

        static void Main(string[] args)
        {
            IntPtr hWnd = GetConsoleWindow();
            if (hWnd != IntPtr.Zero)
            {
                ShowWindow(hWnd, 0);
            }
            Program pr = new Program();
            Task.Run(async () => await pr.StartUp());
            Console.ReadKey();
        }
    }
}
