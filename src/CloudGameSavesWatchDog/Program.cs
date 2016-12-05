using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTimer = System.Threading.Timer;

namespace CloudGameSavesWatchDog
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new Watchdog(args));
    }
  }

  public class Watchdog : ApplicationContext
  {
    const string logFile = "watchdog.log";

    private Process process;
    private volatile bool running = true;

    public Watchdog(string[] args)
    {
      if (File.Exists(logFile))
      {
        File.Delete(logFile);
      }

      Log("Watchdog started");

      int pid = int.Parse(args[0]);
      process = Process.GetProcessById(pid);

      var thread = new Thread(HeartBeatProc);
      thread.IsBackground = true;
      thread.Start();
    }

    private void HeartBeatProc()
    {
      string name = string.Format("CloudGameSavesWatchDog_{0}", process.Id);
      while (running)
      {
        Log("Waiting for connection...");
        using (var server = new NamedPipeServerStream(name))
        {
          var mre = new ManualResetEventSlim(false);
          SleepWith(mre);
          server.WaitForConnection();
          mre.Set();
          Log("Received");
        }
      }
    }

    private void SleepWith(ManualResetEventSlim mre)
    {
      var sleep = new Thread(() =>
      {
        if (!mre.Wait(30000))
        {
          Log("Client did not respond in time");
          running = false;

          if (process.HasExited)
          {
            // the process was exited outside the watchdog
          }
          else
          {
            Log("Attempting to restart process...");
            var info = process.StartInfo.FileName;
            process.Kill();
            process.WaitForExit();
            Thread.Sleep(1000);
            Process.Start(info);
          }

          Application.Exit();
        }
      });
      sleep.IsBackground = true;
      sleep.Start();
    }

    private void Log(string text)
    {
      File.AppendAllLines(logFile, new[] { string.Format("{0}: {1}", DateTime.Now, text) });
    }
  }
}
