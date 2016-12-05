using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ookii.Dialogs;

namespace CloudGameSaves
{
  public partial class FolderBrowseBox : UserControl
  {
    static string SelectedPath;
    static FolderBrowseBox()
    {
      SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
    }

    public FolderBrowseBox()
    {
      InitializeComponent();
    }

    [Bindable(true)]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public override string Text
    {
      get { return textBox1.Text; }
      set { textBox1.Text = value; }
    }

    protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
    {
      height = textBox1.Height;
      base.SetBoundsCore(x, y, width, height, specified);
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      OnTextChanged(e);
    }

    private void btnBrowse_Click(object sender, EventArgs e)
    {
      using (var dlg = new VistaFolderBrowserDialog())
      {
        dlg.ShowNewFolderButton = true;
        dlg.SelectedPath = SelectedPath;
        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
          Text = dlg.SelectedPath;
          SelectedPath = dlg.SelectedPath;
        }
      }
    }
  }
}
