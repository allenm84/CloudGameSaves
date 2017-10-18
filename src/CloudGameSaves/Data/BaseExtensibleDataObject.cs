using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CloudGameSaves
{
  [DataContract(Name = "BaseExtensibleDataObject", Namespace = Program.Namespace)]
  public abstract class BaseExtensibleDataObject : IExtensibleDataObject
  {
    ExtensionDataObject IExtensibleDataObject.ExtensionData { get; set; }

    public virtual string Data
    {
      get
      {
        var dcs = new DataContractSerializer(GetType());
        using (var stream = new MemoryStream())
        {
          dcs.WriteObject(stream, this);
          return Convert.ToBase64String(stream.ToArray());
        }
      }
    }

    protected object dc_clone()
    {
      var dcs = new DataContractSerializer(GetType());
      using (var stream = new MemoryStream())
      {
        dcs.WriteObject(stream, this);
        stream.Position = 0;
        return dcs.ReadObject(stream);
      }
    }
  }
}
