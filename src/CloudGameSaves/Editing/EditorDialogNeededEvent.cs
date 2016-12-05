using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudGameSaves
{
  public delegate void EditorDialogNeededEventHandler<T>(object sender, EditorDialogNeededEventArgs<T> e);

  public class EditorDialogNeededEventArgs<T> : EventArgs
  {
    public EditorDialogNeededEventArgs(T item)
    {
      Item = item;
    }

    public T Item { get; private set; }
    public Form Dialog { get; set; }
  }
}
