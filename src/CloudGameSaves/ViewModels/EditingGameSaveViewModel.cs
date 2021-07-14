using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudGameSaves
{
  public class EditingGameSaveViewModel : BaseNotifyPropertyChanged
  {
    private string _name;
    private string _location;

    public EditingGameSaveViewModel()
    {
      Target = null;
    }

    public EditingGameSaveViewModel(GameSaveViewModel target)
    {
      Target = target;
      Name = target.Name;
      Location = target.Location;
    }

    public GameSaveViewModel Target { get; }

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

    public bool CheckIfValid()
    {
      return !string.IsNullOrWhiteSpace(Name) &&
             !string.IsNullOrWhiteSpace(Location) &&
             Directory.Exists(Location);
    }
  }
}
