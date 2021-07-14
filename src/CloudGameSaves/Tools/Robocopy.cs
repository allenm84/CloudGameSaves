using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudGameSaves
{
  public static class Robocopy
  {
    public static async Task Run(string source, string destination)
    {
      var info = new ProcessStartInfo("robocopy.exe")
      {
        Arguments = $"\"{source}\" \"{destination}\" /mir",
        UseShellExecute = false,
        CreateNoWindow = true
      };
      using var proc = Process.Start(info);
      if (proc != null)
      {
        await proc.WaitForExitAsync();
      }
    }
  }
}
