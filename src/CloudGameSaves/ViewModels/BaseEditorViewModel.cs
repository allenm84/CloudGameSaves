using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudGameSaves
{
  public abstract class BaseEditorViewModel<TViewModel, TEditViewModel, TModel> : BaseNotifyPropertyChanged
  {
    private TEditViewModel _selectedItem;

    protected BaseEditorViewModel(MainViewModel owner)
    {
      Owner = owner;

      AddChangesCommand = new DelegateCommand(DoAddChanges, CanAddChanges);
      PushChangesCommand = new DelegateCommand(DoPushChanges, CanPushChanges);
      CancelChangesCommand = new DelegateCommand(DoCancelChanges);

      ResetEditing();
    }

    public MainViewModel Owner { get; }
    public ObservableCollection<TViewModel> Items { get; } = new();

    public TEditViewModel SelectedItem
    {
      get => _selectedItem;
      set => SetField(ref _selectedItem, value);
    }

    public DelegateCommand AddChangesCommand { get; }
    public DelegateCommand PushChangesCommand { get; }
    public DelegateCommand CancelChangesCommand { get; }

    protected abstract TEditViewModel InitializeEditItem();
    protected abstract TEditViewModel CreateEditViewModel(TViewModel item);
    protected abstract TViewModel CreateViewModel(TModel item);
    protected abstract TViewModel CreateViewModel(TEditViewModel item);

    public void Load(IEnumerable<TModel> saves)
    {
      Items.Clear();
      foreach (var item in saves)
      {
        Items.Add(CreateViewModel(item));
      }
    }

    public void Select(TViewModel item)
    {
      SelectedItem = CreateEditViewModel(item);
    }

    public void Delete(TViewModel item)
    {
      Items.Remove(item);
    }

    private void ResetEditing()
    {
      SelectedItem = InitializeEditItem();
    }

    protected abstract bool CanAddChanges();

    private void DoAddChanges()
    {
      Items.Add(CreateViewModel(_selectedItem));
      ResetEditing();
    }

    protected abstract bool CanPushChanges();

    protected abstract void DoPushChanges();

    private void DoCancelChanges()
    {
      ResetEditing();
    }
  }
}
