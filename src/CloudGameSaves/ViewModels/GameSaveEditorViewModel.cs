using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudGameSaves
{
  public class GameSaveEditorViewModel : BaseEditorViewModel<GameSaveViewModel, EditingGameSaveViewModel, GameSaveModel>
  {
    public GameSaveEditorViewModel(MainViewModel owner)
      : base(owner)
    {
    }

    protected override EditingGameSaveViewModel InitializeEditItem()
      => new();

    protected override EditingGameSaveViewModel CreateEditViewModel(GameSaveViewModel item)
      => new(item);

    protected override GameSaveViewModel CreateViewModel(GameSaveModel item)
      => new(this, item);

    protected override GameSaveViewModel CreateViewModel(EditingGameSaveViewModel item)
      => new(this, item.Name, item.Location);

    protected override bool CanAddChanges()
      => SelectedItem?.CheckIfValid() == true;

    protected override bool CanPushChanges()
      => SelectedItem?.Target != null && Items.Contains(SelectedItem.Target);

    protected override void DoPushChanges()
    {
      var target = SelectedItem?.Target;
      if (target == null)
      {
        return;
      }

      target.Name = SelectedItem.Name;
      target.Location = SelectedItem.Location;
    }
  }
}
