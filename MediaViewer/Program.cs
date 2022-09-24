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
                args = new string[] { "C:\\Users\\sharkoon\\Pictures\\cabiste\\wallpaper\\wallhaven-13mk9v.jpg" };
            }
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(args));
        }
    }
}