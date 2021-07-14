using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace CloudGameSaves
{
  public static class MainViewModelProvider
  {
    private static readonly TaskCompletionSource ViewModelSource = new();

    public static MainViewModel ViewModel { get; } = new();

    public static async void Initialize()
    {
      await ViewModel.LoadSettings();
      ViewModelSource.TrySetResult();
    }

    public static async Task Fetch()
    {
      await ViewModelSource.Task;
    }
  }
}
