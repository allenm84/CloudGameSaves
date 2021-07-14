using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;
using Application = System.Windows.Application;

namespace CloudGameSaves
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private const string TaskName = "Startup_CloudSaves";

    private ContextMenuStrip _contextMenu;
    private NotifyIcon _notifyIcon;

    public App()
    {
      _contextMenu = new();
      _contextMenu.Items.Add("Open Settings", null, OnOpenSettingsClick);
      _contextMenu.Items.Add("Quit Settings", null, OnQuitSettingsClick);

      _notifyIcon = new();
      _notifyIcon.Icon = CloudGameSaves.Resources.App;
      _notifyIcon.Visible = true;
      _notifyIcon.MouseDoubleClick += OnDoubleClickNotifyIcon;
      _notifyIcon.ContextMenuStrip = _contextMenu;
      _notifyIcon.Text = "Cloud Game Saves";

      MainViewModelProvider.Initialize();
    }

    private void App_OnStartup(object sender, StartupEventArgs e)
    {
      if (e.Args.Length > 0 && bool.TryParse(e.Args[0], out var add))
      {
        WindowsService.WriteStartupTask(add);
        Current.Shutdown();
      }
    }

    private void DoShowWindow()
    {
      if (Current.MainWindow != null)
      {
        return;
      }

      Current.MainWindow = new MainWindow();
      Current.MainWindow.Show();
    }

    private void DoExitApplication()
    {
      Current.Shutdown();
    }

    private void OnDoubleClickNotifyIcon(object sender, MouseEventArgs e)
    {
      DoShowWindow();
    }

    private void OnOpenSettingsClick(object sender, EventArgs e)
    {
      DoShowWindow();
    }

    private void OnQuitSettingsClick(object sender, EventArgs e)
    {
      DoExitApplication();
    }

    protected override void OnExit(ExitEventArgs e)
    {
      if (_notifyIcon != null)
      {
        _notifyIcon.Dispose();
        _notifyIcon = null;
      }

      base.OnExit(e);
    }
  }
}
