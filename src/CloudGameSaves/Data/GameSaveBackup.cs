using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CloudGameSaves
{
  [DataContract(Name = "GameSaveBackup", Namespace = Program.Namespace)]
  public class GameSaveBackup : BaseExtensibleDataObject, IEditor<GameSaveBackup>
  {
    [DataMember(Order = 0)]
    public string Name { get; set; }

    [DataMember(Order = 1)]
    public string Location { get; set; }

    GameSaveBackup IEditor<GameSaveBackup>.Clone()
    {
      return base.dc_clone() as GameSaveBackup;
    }
  }
}
