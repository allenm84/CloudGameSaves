using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudGameSaves
{
  public enum OutputType
  {
    Output,
    Error,
  }

  public class RobocopyOutputItem
  {
    public RobocopyOutputItem(string line, OutputType type)
    {
      Line = line;
      Type = type;
    }

    public string Line { get; private set; }
    public OutputType Type { get; private set; }
  }

  public static class Robocopy
  {
    private static readonly BindingList<RobocopyOutputItem> mOutput;
    private static bool mIsRunning = false;

    static Robocopy()
    {
      mOutput = new BindingList<RobocopyOutputItem>();
    }

    public static bool IsRunning
    {
      get { return mIsRunning; }
    }

    public static BindingList<RobocopyOutputItem> Output
    {
      get { return mOutput; }
    }

    private static void robocopy(string source, string destination)
    {
      var info = new ProcessStartInfo("robocopy.exe");
      info.Arguments = string.Format("\"{0}\" \"{1}\" /mir", source, destination);
      info.UseShellExecute = false;
      info.CreateNoWindow = true;
      info.RedirectStandardOutput = true;
      info.RedirectStandardError = true;

      using (var proc = new Process())
      {
        proc.StartInfo = info;
        proc.ErrorDataReceived += errorDataReceived;
        proc.OutputDataReceived += outputDataReceived;

        proc.Start();
        proc.BeginErrorReadLine();
        proc.BeginOutputReadLine();
        proc.WaitForExit();
      }
    }

    private static void errorDataReceived(object sender, DataReceivedEventArgs e)
    {
      mOutput.Add(new RobocopyOutputItem(e.Data, OutputType.Error));
    }

    private static void outputDataReceived(object sender, DataReceivedEventArgs e)
    {
      mOutput.Add(new RobocopyOutputItem(e.Data, OutputType.Output));
    }

    public static async void Run(List<GameSave> saves)
    {
      mIsRunning = true;
      await Task.Run(() =>
      {
        foreach (var item in saves)
        {
          mOutput.Add(new RobocopyOutputItem(string.Format("* Running for {0}", item.Name), OutputType.Output));
          foreach (var backup in item.Backups)
          {
            mOutput.Add(new RobocopyOutputItem(string.Format("** {0} => {1}", item.Name, backup.Name), OutputType.Output));
            robocopy(item.Location, backup.Location);
          }
        }
      });
      mIsRunning = false;
    }
  }
}
