using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudGameSaves
{
  public class GameSaveWatcher : IDisposable
  {
    private GameSave mSave;
    private FileSystemWatcher mWatcher;

    public GameSaveWatcher(GameSave save)
    {
      mSave = save;
      CreateWatcher();
      Run();
    }

    public GameSave Save
    {
      get { return mSave; }
    }

    public void Run()
    {
      Robocopy.Run(mSave);
    }

    public void Dispose()
    {
      DestroyWatcher();
      mSave = null;
    }

    private void CreateWatcher()
    {
      mWatcher = new FileSystemWatcher();
      mWatcher.Path = mSave.Location;
      mWatcher.IncludeSubdirectories = true;
      mWatcher.Changed += watcher_Changed;
      mWatcher.Created += mWacthcer_Created;
      mWatcher.Deleted += mWatcher_Deleted;
      mWatcher.Error += mWatcher_Error;
      mWatcher.Renamed += mWatcher_Renamed;
      mWatcher.EnableRaisingEvents = true;
    }

    private void DestroyWatcher()
    {
      mWatcher.EnableRaisingEvents = false;
      mWatcher.Changed -= watcher_Changed;
      mWatcher.Created -= mWacthcer_Created;
      mWatcher.Deleted -= mWatcher_Deleted;
      mWatcher.Error -= mWatcher_Error;
      mWatcher.Renamed -= mWatcher_Renamed;
      mWatcher.Dispose();
    }

    private void mWatcher_Renamed(object sender, RenamedEventArgs e)
    {
      Run();
    }

    private void mWatcher_Error(object sender, ErrorEventArgs e)
    {
      DestroyWatcher();
      CreateWatcher();
    }

    private void mWatcher_Deleted(object sender, FileSystemEventArgs e)
    {
      Run();
    }

    private void mWacthcer_Created(object sender, FileSystemEventArgs e)
    {
      Run();
    }

    private void watcher_Changed(object sender, FileSystemEventArgs e)
    {
      Run();
    }
  }
}
