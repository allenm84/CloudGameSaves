using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace CloudGameSaves
{
  [FirestoreData]
  public class DestinationModel
  {
    [FirestoreProperty]
    public byte Key { get; set; }

    [FirestoreProperty]
    public string Value { get; set; }
  }
}
