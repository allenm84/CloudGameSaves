using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudGameSaves
{
  public class DataGridEditor<T>
    where T : class, IEditor<T>
  {
    private Button btnAdd;
    private Button btnClear;
    private Button btnEdit;
    private Button btnRemove;
    private BindingSource source;
    private DataGridView grid;

    public DataGridEditor(DataGridView grid, BindingSource source, Button btnAdd, Button btnEdit, Button btnRemove, Button btnClear)
    {
      this.grid = grid;
      this.source = source;
      this.btnAdd = btnAdd;
      this.btnEdit = btnEdit;
      this.btnRemove = btnRemove;
      this.btnClear = btnClear;

      this.grid.CellMouseDoubleClick += grid_CellMouseDoubleClick;
      this.grid.KeyDown += grid_KeyDown;
      this.grid.SelectionChanged += grid_SelectionChanged;
      this.grid.CurrentCellChanged += grid_SelectionChanged;

      this.source.ListChanged += source_ListChanged;

      this.btnAdd.Click += this.btnAdd_Click;
      this.btnEdit.Click += this.btnEdit_Click;
      this.btnRemove.Click += this.btnRemove_Click;
      this.btnClear.Click += this.btnClear_Click;

      UpdateButtons();
    }

    public IWin32Window Owner { get; set; }

    public event NewItemNeededEventHandler<T> NewItemNeeded;
    public event EditorDialogNeededEventHandler<T> EditorDialogNeeded;

    private void UpdateButtons()
    {
      btnEdit.Enabled = (grid.CurrentRow != null);
      btnRemove.Enabled = (grid.SelectedRows.Count > 0);
      btnClear.Enabled = source.Count > 0;
    }

    private T CreateNewItem()
    {
      var args = new NewItemNeededEventArgs<T>();
      NewItemNeeded?.Invoke(this, args);
      return args.Item;
    }

    private Form CreateDialog(T item)
    {
      var args = new EditorDialogNeededEventArgs<T>(item);
      EditorDialogNeeded?.Invoke(this, args);
      return args.Dialog;
    }

    private bool Confirm(string message)
    {
      return MessageBox.Show(Owner, message, "Confirm", 
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
    }

    private void grid_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Delete)
      {
        btnRemove.PerformClick();
      }
    }

    private void grid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      btnEdit.PerformClick();
    }

    private void grid_SelectionChanged(object sender, EventArgs e)
    {
      UpdateButtons();
    }

    private void source_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
    {
      UpdateButtons();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      var item = CreateNewItem();
      using (var dlg = CreateDialog(item))
      {
        if (dlg.ShowDialog(Owner) == DialogResult.OK)
        {
          source.Add(item);
        }
      }
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
      var original = grid?.CurrentRow?.DataBoundItem as T;
      if (original != null)
      {
        var edited = original.Clone();
        using (var dlg = CreateDialog(edited))
        {
          if (dlg.ShowDialog(Owner) == DialogResult.OK)
          {
            var index = source.IndexOf(original);
            source[index] = edited;
            source.ResetItem(index);
          }
        }
      }
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
      if (Confirm("Are you sure you want to remove the selected items?"))
      {
        var selected = grid.SelectedRows
          .OfType<DataGridViewRow>()
          .Select(r => r.DataBoundItem)
          .OfType<T>()
          .ToArray();

        foreach (var item in selected)
        {
          source.Remove(item);
        }
      }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      if (Confirm("Are you sure you want to remove all of the items?"))
      {
        source.Clear();
      }
    }
  }
}
