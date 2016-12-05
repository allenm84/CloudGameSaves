using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CloudGameSaves
{
  [DataContract(Name = "GameSave", Namespace = Program.Namespace)]
  public class GameSave : BaseExtensibleDataObject, IEditor<GameSave>
  {
    [DataMember(Order = 1)]
    public string Name { get; set; }

    [DataMember(Order = 2)]
    public string Location { get; set; }

    [DataMember(Order = 3)]
    public List<GameSaveBackup> Backups { get; set; }

    GameSave IEditor<GameSave>.Clone()
    {
      return base.dc_clone() as GameSave;
    }
  }
}
