using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudGameSaves
{
  static class Program
  {
    public const string AppId = "8D35DEC9-F71C-4A07-B2BB-C535540D1430";
    public const string Namespace = "http://www.mapa.com/mike/cloudGameSaves";

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      bool createdMutex;
      using (var mutex = new Mutex(true, AppId, out createdMutex))
      {
        if (createdMutex)
        {
          var proc = Process.GetCurrentProcess();
          var id = proc.Id.ToString();
          Process.Start("CloudGameSavesWatchDog.exe", id);

          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
          using (var context = new MainAppContext(id))
          {
            Application.Run(context);
          }
        }
      }
    }

    public static bool Force = false;
  }
}
