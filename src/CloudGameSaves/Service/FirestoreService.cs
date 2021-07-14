using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace CloudGameSaves
{
  public static class FirestoreService
  {
    private const string ProjectId = "mapa-apps";
    private const string CollectionName = "appSettings";
    private const string CloudSavesDocId = "CloudSaves(E17E5A57-2F7C-4D38-A261-2BF0A41862AE)";

    public static async Task<MainModel> FetchModelAsync()
    {
      var db = await FirestoreDb.CreateAsync(ProjectId);
      var collectionRef = db.Collection(CollectionName);
      var settingsDocRef = collectionRef.Document(CloudSavesDocId);
      var docSnapshot = await settingsDocRef.GetSnapshotAsync();
      return docSnapshot.ConvertTo<MainModel>();
    }

    public static async Task PushModelAsync(MainModel model)
    {
      var db = await FirestoreDb.CreateAsync(ProjectId);
      var collectionRef = db.Collection(CollectionName);
      var settingsDocRef = collectionRef.Document(CloudSavesDocId);
      await settingsDocRef.SetAsync(model);
    }
  }
}
