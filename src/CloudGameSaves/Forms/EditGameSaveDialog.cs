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
  public partial class EditGameSaveDialog : BaseForm
  {
    private DataGridEditor<GameSaveBackup> mEditor;

    public EditGameSaveDialog(GameSave save)
    {
      InitializeComponent();
      txtName.DataBindings.Add(nameof(TextBox.Text), save, nameof(save.Name));
      txtLocation.DataBindings.Add(nameof(FolderBrowseBox.Text), save, nameof(save.Location));
      gameSaveBackupBindingSource.DataSource = save.Backups;

      nameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      locationDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

      mEditor = new DataGridEditor<GameSaveBackup>(gridLocations, gameSaveBackupBindingSource, btnAdd, btnEdit, btnRemove, btnClear);
      mEditor.Owner = this;
      mEditor.NewItemNeeded += editor_NewItemNeeded;
      mEditor.EditorDialogNeeded += editor_EditorDialogNeeded;
    }

    private void editor_NewItemNeeded(object sender, NewItemNeededEventArgs<GameSaveBackup> e)
    {
      e.Item = new GameSaveBackup
      {
        Location = "",
        Name = "<New Save Location>",
      };
    }

    private void editor_EditorDialogNeeded(object sender, EditorDialogNeededEventArgs<GameSaveBackup> e)
    {
      e.Dialog = new EditGameSaveBackupDialog(e.Item);
    }
  }
}
