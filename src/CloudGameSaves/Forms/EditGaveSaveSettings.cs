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
  public partial class EditGaveSaveSettings : BaseForm
  {
    private DataGridEditor<GameSave> mEditor;

    public EditGaveSaveSettings(GameSavesSettings settings)
    {
      InitializeComponent();

      numScanInterval.Minimum = 0;
      numScanInterval.Maximum = int.MaxValue;
      numScanInterval.DataBindings.Add(nameof(NumericUpDown.Value), settings, nameof(settings.ScanInterval));
      gameSaveBindingSource.DataSource = settings.Saves;

      nameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      locationDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

      mEditor = new DataGridEditor<GameSave>(gridSaves, gameSaveBindingSource, btnAdd, btnEdit, btnRemove, btnClear);
      mEditor.Owner = this;
      mEditor.NewItemNeeded += editor_NewItemNeeded;
      mEditor.EditorDialogNeeded += editor_EditorDialogNeeded;
    }

    private void editor_NewItemNeeded(object sender, NewItemNeededEventArgs<GameSave> e)
    {
      e.Item = new GameSave
      {
        Backups = new List<GameSaveBackup>(),
        Location = string.Empty,
        Name = "<New Game>",
      };
    }

    private void editor_EditorDialogNeeded(object sender, EditorDialogNeededEventArgs<GameSave> e)
    {
      e.Item.Backups.Sort((x, y) => string.CompareOrdinal(x.Name, y.Name));
      e.Dialog = new EditGameSaveDialog(e.Item);
    }
  }
}
