using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace CloudGameSaves
{
  [FirestoreData]
  public class MainModel
  {
    [FirestoreProperty] public bool RunAtStartup { get; set; }
    [FirestoreProperty] public List<DestinationModel> Destinations { get; set; } = new();
    [FirestoreProperty] public List<GameSaveModel> Saves { get; set; } = new();
  }
}
