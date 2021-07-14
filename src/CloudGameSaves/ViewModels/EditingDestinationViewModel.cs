using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudGameSaves
{
  public class EditingDestinationViewModel : BaseNotifyPropertyChanged
  {
    private string _value;

    public EditingDestinationViewModel()
    {
      OriginalValue = null;
    }

    public EditingDestinationViewModel(string value)
    {
      OriginalValue = value;
      Value = value;
    }

    internal string OriginalValue { get; }

    public string Value
    {
      get => _value;
      set => SetField(ref _value, value);
    }
  }
}
