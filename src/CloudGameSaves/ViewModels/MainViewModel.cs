using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CloudGameSaves
{
  public class MainViewModel : BaseNotifyPropertyChanged
  {
    private static readonly Random Random = new();

    private bool _runAtStartup;

    public MainViewModel()
    {
      SaveCommand = new DelegateCommand(DoSave);

      DestinationEditor = new DestinationEditorViewModel(this);
      GameSaveEditor = new GameSaveEditorViewModel(this);
    }

    public bool RunAtStartup
    {
      get => _runAtStartup;
      set => SetField(ref _runAtStartup, value);
    }

    public DelegateCommand SaveCommand { get; }

    public DestinationEditorViewModel DestinationEditor { get; }
    public GameSaveEditorViewModel GameSaveEditor { get; }

    public async Task LoadSettings()
    {
      var model = await FirestoreService.FetchModelAsync();
      if (model == null)
      {
        return;
      }

      RunAtStartup = model.RunAtStartup;

      DestinationEditor.Load(model.Destinations);
      GameSaveEditor.Load(model.Saves);

      await WindowsService.UpdateStartupValue(RunAtStartup);
    }

    private async void DoSave()
    {
      var model = new MainModel
      {
        RunAtStartup = RunAtStartup,
        Destinations = DestinationEditor.Items.Select(CreateDestinationModel).ToList(),
        Saves = GameSaveEditor.Items.Select(CreateGameSaveModel).ToList()
      };

      await FirestoreService.PushModelAsync(model);

      await WindowsService.UpdateStartupValue(RunAtStartup);
    }

    private static byte CreateKey()
    {
      var keys = new byte[1];
      Random.NextBytes(keys);
      return keys[0];
    }

    private static DestinationModel CreateDestinationModel(string value)
    {
      var key = CreateKey();
      return new DestinationModel
      {
        Key = key,
        Value = Cipher.Encrypt(value, key)
      };
    }

    private static GameSaveModel CreateGameSaveModel(GameSaveViewModel value)
    {
      var key = CreateKey();
      return new GameSaveModel
      {
        Key = key,
        Name = Cipher.Encrypt(value.Name, key),
        Location = Cipher.Encrypt(value.Location, key)
      };
    }
  }
}
