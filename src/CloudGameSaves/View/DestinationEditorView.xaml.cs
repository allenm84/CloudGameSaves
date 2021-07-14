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
  /// Interaction logic for DestinationEditorView.xaml
  /// </summary>
  public partial class DestinationEditorView : UserControl
  {
    public DestinationEditorView()
    {
      InitializeComponent();
    }

    private void lstItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      var items = e.AddedItems;
      if (items.Count > 0 && items[0] is string value && DataContext is DestinationEditorViewModel editor)
      {
        editor.Select(value);
      }
    }

    private void lstItems_PreviewKeyDown(object sender, KeyEventArgs e)
    {
      if (e.Key == Key.Delete && DataContext is DestinationEditorViewModel editor)
      {
        editor.Delete(LstItems.SelectedItem as string);
      }
    }
  }
}
