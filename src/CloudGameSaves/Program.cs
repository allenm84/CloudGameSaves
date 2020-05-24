using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;
using Task = System.Threading.Tasks.Task;

namespace CloudGameSaves
{
  static class Program
  {
    public const string RegistryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

    public const string AppId = "8D35DEC9-F71C-4A07-B2BB-C535540D1430";
    public const string Namespace = "http://www.mapa.com/mike/cloudGameSaves";

    public const string TaskName = "Startup_CloudSaves";

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
      if (args.Length == 1)
      {
        if (bool.TryParse(args[0], out var add))
        {
          SetStartup(add);
          return;
        }
      }

      using (var mutex = new Mutex(true, AppId, out var createdMutex))
      {
        if (createdMutex)
        {
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
          using (var context = new MainAppContext())
          {
            Application.Run(context);
            context.Remove();
          }
        }
      }
    }

    static void SetStartup(bool add)
    {
      var service = TaskService.Instance;
      var existingTask = service.GetTask(TaskName);
      if (existingTask != null)
      {
        service.RootFolder.DeleteTask(TaskName);
      }

      if (add)
      {
        var file = new FileInfo(Application.ExecutablePath);

        var action = new ExecAction();
        action.Path = file.FullName;
        action.WorkingDirectory = file.Directory.FullName;

        var task = service.NewTask();
        task.Actions.Add(action);
        task.Triggers.Add(new LogonTrigger());

        service.RootFolder.RegisterTaskDefinition(TaskName, task);
      }
    }

    public static bool RunAtStartup => TaskService.Instance.GetTask(TaskName)?.Enabled == true;

    public static void UpdateStartup(bool add)
    {
      var info = new ProcessStartInfo(Application.ExecutablePath);
      info.Verb = "runas";
      info.Arguments = $"{add}";
      info.UseShellExecute = true;
      Process.Start(info);
    }
  }
}
