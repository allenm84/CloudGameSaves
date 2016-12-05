using CloudGameSaves.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudGameSaves
{
  public class MainAppContext : ApplicationContext
  {
    private string mPipeName;
    private Timer mPulseTimer;

    private RobocopyOutputDialog mOutput;

    private NotifyIcon mTrayIcon;
    private ContextMenuStrip mTrayMenu;
    private DataContractFile<GameSavesSettings> mFile;
    private GameSavesSettings mSettings;
    private Timer mScanTimer;

    public MainAppContext(string id)
    {
      mPipeName = string.Format("CloudGameSavesWatchDog_{0}", id);

      mPulseTimer = new Timer();
      mPulseTimer.Interval = 5000;
      mPulseTimer.Tick += mPulseTimer_Tick;
      mPulseTimer.Start();

      mTrayMenu = new ContextMenuStrip();
      mTrayMenu.Items.Add("Settings...", null, mnuShowSettings_Click);
      mTrayMenu.Items.Add("Output...", null, mnuShowOutput_Click);
      mTrayMenu.Items.Add("Exit", null, mnuExit_Click);

      mTrayIcon = new NotifyIcon();
      mTrayIcon.Icon = Resources.App;
      mTrayIcon.ContextMenuStrip = mTrayMenu;
      mTrayIcon.Text = "CloudGameSaves";
      mTrayIcon.Visible = true;
      mTrayIcon.MouseDoubleClick += trayIcon_MouseDoubleClick;

      Application.ApplicationExit += Application_ApplicationExit;

      mFile = new DataContractFile<GameSavesSettings>("settings.xml");
      mSettings = LoadSettings();

      mScanTimer = new Timer();
      mScanTimer.Interval = mSettings.ScanInterval;
      mScanTimer.Tick += mScanTimer_Tick;
      mScanTimer.Start();
    }

    private void mPulseTimer_Tick(object sender, EventArgs e)
    {
      using (var client = new NamedPipeClientStream(mPipeName))
      {
        try
        {
          client.Connect(2500);
        }
        catch
        {
          // couldn't connect?
        }
      }
    }

    ~MainAppContext()
    {
      Remove();
    }

    private GameSavesSettings LoadSettings()
    {
      GameSavesSettings settings;
      mFile.TryRead(out settings);
      if (settings == null)
      {
        settings = new GameSavesSettings();
        settings.Saves = new List<GameSave>();
        settings.ScanInterval = 30000;
      }

      return settings;
    }

    private void ShowSettings()
    {
      var original = mSettings;

      var edited = mSettings.Clone();
      edited.Saves.Sort((x, y) => string.CompareOrdinal(x.Name, y.Name));

      using (var dlg = new EditGaveSaveSettings(edited))
      {
        if (dlg.ShowDialog() == DialogResult.OK)
        {
          mSettings = edited;
          mFile.TryWrite(mSettings);
          mScanTimer.Interval = mSettings.ScanInterval;
        }
      }
    }

    public void Remove()
    {
      mOutput?.Shutdown();
      mScanTimer.Stop();
      mTrayIcon.Visible = false;
    }
    
    protected override void Dispose(bool disposing)
    {
      base.Dispose(disposing);
      Remove();
    }

    private void Application_ApplicationExit(object sender, EventArgs e)
    {
      Remove();
    }

    private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      ShowSettings();
    }

    private void mnuShowSettings_Click(object sender, EventArgs e)
    {
      ShowSettings();
    }

    private void mnuShowOutput_Click(object sender, EventArgs e)
    {
      if (mOutput == null)
      {
        mOutput = new RobocopyOutputDialog();
      }
      mOutput.Show();
    }

    private void mnuExit_Click(object sender, EventArgs e)
    {
      Program.Force = true;
      Application.Exit();
    }

    private void mScanTimer_Tick(object sender, EventArgs e)
    {
      if (!Robocopy.IsRunning)
      {
        var cloned = mSettings.Clone();
        Robocopy.Run(cloned.Saves);
      }
    }
  }
}
