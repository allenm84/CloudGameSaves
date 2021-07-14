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
using Microsoft.Win32;
using Ookii.Dialogs.Wpf;

namespace CloudGameSaves
{
  /// <summary>
  /// Interaction logic for BrowseTextBox.xaml
  /// </summary>
  public partial class BrowseTextBox : UserControl
  {
    public static readonly DependencyProperty TextProperty
      = DependencyProperty.Register(
        nameof(Text),
        typeof(string),
        typeof(BrowseTextBox),
        new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
      );

    public static readonly DependencyProperty ShowNewFolderButtonProperty
      = DependencyProperty.Register(
        nameof(ShowNewFolderButton),
        typeof(bool),
        typeof(BrowseTextBox),
        new PropertyMetadata(false)
      );

    public BrowseTextBox()
    {
      InitializeComponent();
    }

    public string Text
    {
      get => (string)GetValue(TextProperty);
      set => SetValue(TextProperty, value);
    }

    public bool ShowNewFolderButton
    {
      get => (bool)GetValue(ShowNewFolderButtonProperty);
      set => SetValue(ShowNewFolderButtonProperty, value);
    }

    private void OnBrowseFilesystem(object sender, RoutedEventArgs e)
    {
      var dlg = new VistaFolderBrowserDialog();
      dlg.ShowNewFolderButton = ShowNewFolderButton;
      if (dlg.ShowDialog() == true)
      {
        Text = dlg.SelectedPath;
      }
    }
  }
}
