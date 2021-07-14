using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudGameSaves
{
  public class DestinationEditorViewModel : BaseEditorViewModel<string, EditingDestinationViewModel, DestinationModel>
  {
    public DestinationEditorViewModel(MainViewModel owner)
      : base(owner)
    {
    }

    protected override EditingDestinationViewModel InitializeEditItem()
      => new();

    protected override EditingDestinationViewModel CreateEditViewModel(string item)
      => new(item);

    protected override string CreateViewModel(DestinationModel item)
      => Cipher.Decrypt(item.Value, item.Key);

    protected override string CreateViewModel(EditingDestinationViewModel item)
      => item.Value;

    protected override bool CanAddChanges()
      => !string.IsNullOrWhiteSpace(SelectedItem?.Value);

    protected override bool CanPushChanges()
    {
      var originalValue = SelectedItem?.OriginalValue;
      if (string.IsNullOrWhiteSpace(originalValue))
      {
        return false;
      }

      var value = SelectedItem?.Value;
      return !string.IsNullOrWhiteSpace(value);
    }

    protected override void DoPushChanges()
    {
      var item = SelectedItem?.OriginalValue;
      if (string.IsNullOrWhiteSpace(item))
      {
        return;
      }

      var value = SelectedItem?.Value;
      if (string.IsNullOrWhiteSpace(value))
      {
        return;
      }

      var index = Items.IndexOf(item);
      Items[index] = SelectedItem.Value;
    }
  }
}
