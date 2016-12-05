using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudGameSaves
{
  public delegate void NewItemNeededEventHandler<T>(object sender, NewItemNeededEventArgs<T> e);

  public class NewItemNeededEventArgs<T> : EventArgs
  {
    public T Item { get; set; }
  }
}
