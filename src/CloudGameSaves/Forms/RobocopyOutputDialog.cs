using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudGameSaves
{
  public partial class RobocopyOutputDialog : BaseForm
  {
    private int mScrollId = int.MinValue;
    private SynchronizationContext mContext;

    public RobocopyOutputDialog()
    {
      InitializeComponent();
      mContext = SynchronizationContext.Current;

      foreach (var item in Robocopy.Output)
      {
        AddLine(item);
      }

      Robocopy.Output.ListChanged += Output_ListChanged;
    }

    public void Shutdown()
    {
      Program.Force = true;
      mContext.Post((x) => Close(), null);
    }

    private void AddLine(RobocopyOutputItem item)
    {
      AddLine(item?.Line ?? string.Empty);
    }

    private void AddLine(string line)
    {
      txtOutput.AppendText(line + Environment.NewLine);
      txtOutput.ScrollToCaret();
    }

    private async void ScrollToCaret()
    {
      int id = ++mScrollId;
      await Task.Yield();
      if (id == mScrollId)
      {
        txtOutput.ScrollToCaret();
      }
    }

    private void Output_ListChanged(object sender, ListChangedEventArgs e)
    {
      if (e.ListChangedType == ListChangedType.ItemAdded)
      {
        var item = Robocopy.Output[e.NewIndex];
        mContext.Send((x) => AddLine(item), null);
      }
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      if (!Program.Force)
      {
        e.Cancel = true;
        Hide();
      }
      base.OnFormClosing(e);
    }
  }
}
