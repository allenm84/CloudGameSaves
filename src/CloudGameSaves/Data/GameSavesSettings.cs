using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CloudGameSaves
{
  [DataContract(Name = "GameSavesSettings", Namespace = Program.Namespace)]
  public class GameSavesSettings : BaseExtensibleDataObject
  {
    [DataMember(Order = 0)]
    public List<GameSave> Saves { get; set; }

    public GameSavesSettings Clone()
    {
      return base.dc_clone() as GameSavesSettings;
    }
  }
}
