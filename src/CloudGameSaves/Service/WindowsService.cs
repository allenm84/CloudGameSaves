using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.TaskScheduler;
using Task = System.Threading.Tasks.Task;

namespace CloudGameSaves
{
  public static class WindowsService
  {
    public const string TaskName = "Startup_CloudSaves";

    private static bool RunAtStartup => TaskService.Instance.GetTask(TaskName)?.Enabled == true;

    private static string GetAppPath()
    {
      var curAssembly = Assembly.GetExecutingAssembly();
      var name = Path.GetFileNameWithoutExtension(curAssembly.Location);
      var dir = Path.GetDirectoryName(curAssembly.Location);
      return Path.Combine(dir, $"{name}.exe");
    }

    public static async Task UpdateStartupValue(bool desired)
    {
      if (RunAtStartup == desired)
      {
        return;
      }

      var info = new ProcessStartInfo(GetAppPath())
      {
        Verb = "runas",
        Arguments = $"{desired}",
        UseShellExecute = true
      };
      using var proc = Process.Start(info);
      await proc.WaitForExitAsync();
    }

    public static void WriteStartupTask(bool add)
    {
      var service = TaskService.Instance;
      var existingTask = service.GetTask(TaskName);
      if (existingTask != null)
      {
        service.RootFolder.DeleteTask(TaskName);
      }

      if (!add)
      {
        return;
      }
      
      var file = new FileInfo(GetAppPath());

      var action = new ExecAction();
      action.Path = file.FullName;
      action.WorkingDirectory = file.Directory.FullName;

      var task = service.NewTask();
      task.Actions.Add(action);
      task.Triggers.Add(new LogonTrigger());

      service.RootFolder.RegisterTaskDefinition(TaskName, task);
    }
  }
}
