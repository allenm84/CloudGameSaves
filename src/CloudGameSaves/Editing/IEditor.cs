using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudGameSaves
{
  public interface IEditor<T>
  {
    T Clone();
  }
}
