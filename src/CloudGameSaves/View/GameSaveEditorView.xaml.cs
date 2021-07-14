using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CloudGameSaves
{
  /// <summary>
  /// Interaction logic for GameSaveEditorView.xaml
  /// </summary>
  public partial class GameSaveEditorView : UserControl
  {
    public GameSaveEditorView()
    {
      InitializeComponent();
    }

    private void lstSaves_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      var items = e.AddedItems;
      if (items.Count > 0 && items[0] is GameSaveViewModel value && DataContext is GameSaveEditorViewModel editor)
      {
        editor.Select(value);
      }
    }

    private void lstSaves_PreviewKeyDown(object sender, KeyEventArgs e)
    {
      if (e.Key == Key.Delete && DataContext is GameSaveEditorViewModel editor)
      {
        editor.Delete(LstSaves.SelectedItem as GameSaveViewModel);
      }
    }
  }
}
