using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace CloudGameSaves
{
  public class GameSaveViewModel : BaseNotifyPropertyChanged
  {
    private readonly DispatcherTimer _timer;

    private bool _isValid;
    private bool _isRunning;
    private string _name;
    private string _location;

    private GameSaveViewModel(GameSaveEditorViewModel owner)
    {
      SelectCommand = new DelegateCommand(DoSelect);
      DeleteCommand = new DelegateCommand(DoDelete);

      Owner = owner;

      _timer = new DispatcherTimer();
      _timer.Interval = TimeSpan.FromSeconds(10);
      _timer.Tick += OnCheckLocationTick;
      _timer.Start();
    }

    public GameSaveViewModel(GameSaveEditorViewModel owner, GameSaveModel model)
      : this(owner)
    {
      Name = Cipher.Decrypt(model.Name, model.Key);
      Location = Cipher.Decrypt(model.Location, model.Key);

      DoRun();
    }

    public GameSaveViewModel(GameSaveEditorViewModel owner, string name, string location)
      : this(owner)
    {
      Name = name;
      Location = location;

      DoRun();
    }

    public GameSaveEditorViewModel Owner { get; }

    public bool IsValid
    {
      get => _isValid;
      private set => SetField(ref _isValid, value);
    }

    public bool IsRunning
    {
      get => _isRunning;
      private set => SetField(ref _isRunning, value);
    }

    public string Name
    {
      get => _name;
      set => SetField(ref _name, value);
    }

    public string Location
    {
      get => _location;
      set => SetField(ref _location, value);
    }

    public DelegateCommand SelectCommand { get; }
    public DelegateCommand DeleteCommand { get; }

    private void DoSelect()
    {
      Owner.Select(this);
    }

    private void DoDelete()
    {
      Owner.Delete(this);

      _timer.Stop();
      _timer.Tick -= OnCheckLocationTick;
    }

    private void DoRun()
    {
      var location = Location;
      if (string.IsNullOrWhiteSpace(location) || !Directory.Exists(location))
      {
        IsValid = false;
      }
      else
      {
        IsValid = true;
        DoMirrorToDestinations(location);
      }
    }

    private string GetDestination(string parentDirectory)
    {
      return Path.Combine(parentDirectory, Name);
    }

    private async void DoMirrorToDestinations(string location)
    {
      if (IsRunning)
      {
        return;
      }

      var destinations = Owner.Owner.DestinationEditor.Items;
      IsRunning = true;
      var tasks = destinations.Select(it => Robocopy.Run(location, GetDestination(it)));
      await Task.WhenAll(tasks);
      IsRunning = false;
    }

    private void OnCheckLocationTick(object sender, EventArgs e)
    {
      DoRun();
    }
  }
}
