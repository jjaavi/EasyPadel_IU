using EasyPadel_IU_Server;

namespace EasyPadel
{
    internal static class EeasyPadelServerMain
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormIUServer());
        }
    }
}
