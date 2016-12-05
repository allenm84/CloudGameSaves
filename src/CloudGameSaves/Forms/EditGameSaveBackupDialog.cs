using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudGameSaves
{
  public partial class EditGameSaveBackupDialog : BaseForm
  {
    public EditGameSaveBackupDialog(GameSaveBackup backup)
    {
      InitializeComponent();
      txtName.DataBindings.Add(nameof(TextBox.Text), backup, nameof(backup.Name));
      txtLocation.DataBindings.Add(nameof(FolderBrowseBox.Text), backup, nameof(backup.Location));
    }
  }
}
