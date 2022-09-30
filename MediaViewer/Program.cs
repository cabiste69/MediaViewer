using System.Diagnostics;

namespace MediaViewer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (Debugger.IsAttached)
            {
                args = new string[] { "D:\\Documents\\Coding\\c#\\MediaViewer\\MediaViewer\\bin\\Debug\\net6.0-windows\\rdL2nkzH_400x400.jpg" };
            }
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(args));
        }
    }
}