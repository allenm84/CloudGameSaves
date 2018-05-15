using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudGameSaves
{
  public static class Robocopy
  {
    private static void robocopy(string source, string destination)
    {
      var info = new ProcessStartInfo("robocopy.exe");
      info.Arguments = string.Format("\"{0}\" \"{1}\" /mir", source, destination);
      info.UseShellExecute = false;
      info.CreateNoWindow = true;

      using (var proc = Process.Start(info))
      {
        proc.WaitForExit();
      }
    }

    public static void Run(GameSave save)
    {
      Task.Factory.StartNew(()=>
      {
        foreach (var backup in save.Backups)
        {
          if (!Directory.Exists(save.Location))
          {
            continue;
          }

          robocopy(save.Location, backup.Location);
        }
      });
    }
  }
}
