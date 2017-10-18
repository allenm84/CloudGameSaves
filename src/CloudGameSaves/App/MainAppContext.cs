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
    private readonly List<GameSaveWatcher> mWatchers = new List<GameSaveWatcher>();

    private NotifyIcon mTrayIcon;
    private ContextMenuStrip mTrayMenu;
    private DataContractFile<GameSavesSettings> mFile;
    private GameSavesSettings mSettings;

    public MainAppContext()
    {
      mTrayMenu = new ContextMenuStrip();
      mTrayMenu.Items.Add("Settings...", null, mnuShowSettings_Click);
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

      UpdateWatchers();
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
      }

      return settings;
    }

    private void UpdateWatchers()
    {
      var current = new Dictionary<string, GameSave>(StringComparer.Ordinal);
      foreach (var save in mSettings.Saves)
      {
        current[save.Data] = save;
      }

      for (int i = mWatchers.Count - 1; i > -1; --i)
      {
        var watcher = mWatchers[i];
        var save = watcher.Save.Data;
        if (!current.ContainsKey(save))
        {
          // the watcher is invalid
          watcher.Dispose();
          mWatchers.RemoveAt(i);
        }
        else
        {
          // the watcher exists in the current! Lets
          // remove it from the current
          current.Remove(save);
        }
      }

      foreach (var save in current.Values)
      {
        mWatchers.Add(new GameSaveWatcher(save));
      }
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
          UpdateWatchers();
        }
      }
    }

    public void Remove()
    {
      mTrayIcon.Visible = false;
      mWatchers.ForEach(w => w.Dispose());
      mWatchers.Clear();
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

    private void mnuExit_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }
  }
}
