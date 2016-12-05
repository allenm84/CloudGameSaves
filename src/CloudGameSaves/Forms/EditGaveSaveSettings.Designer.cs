﻿namespace CloudGameSaves
{
  partial class EditGaveSaveSettings
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.gridSaves = new System.Windows.Forms.DataGridView();
      this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.locationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.gameSaveBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.btnAdd = new System.Windows.Forms.Button();
      this.btnEdit = new System.Windows.Forms.Button();
      this.btnRemove = new System.Windows.Forms.Button();
      this.btnClear = new System.Windows.Forms.Button();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.label1 = new System.Windows.Forms.Label();
      this.numScanInterval = new System.Windows.Forms.NumericUpDown();
      this.label2 = new System.Windows.Forms.Label();
      this.tableLayoutPanel1.SuspendLayout();
      this.tableLayoutPanel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridSaves)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gameSaveBindingSource)).BeginInit();
      this.tableLayoutPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numScanInterval)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
      this.tableLayoutPanel1.Controls.Add(this.gridSaves, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.btnAdd, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.btnEdit, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.btnRemove, 1, 2);
      this.tableLayoutPanel1.Controls.Add(this.btnClear, 1, 3);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 70);
      this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 5;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(533, 236);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // tableLayoutPanel3
      // 
      this.tableLayoutPanel3.ColumnCount = 3;
      this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
      this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
      this.tableLayoutPanel3.Controls.Add(this.btnOK, 1, 0);
      this.tableLayoutPanel3.Controls.Add(this.btnCancel, 2, 0);
      this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 306);
      this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
      this.tableLayoutPanel3.Name = "tableLayoutPanel3";
      this.tableLayoutPanel3.RowCount = 1;
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel3.Size = new System.Drawing.Size(533, 30);
      this.tableLayoutPanel3.TabIndex = 7;
      // 
      // btnOK
      // 
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btnOK.Location = new System.Drawing.Point(376, 3);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(74, 24);
      this.btnOK.TabIndex = 0;
      this.btnOK.Text = "Save";
      this.btnOK.UseVisualStyleBackColor = true;
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btnCancel.Location = new System.Drawing.Point(456, 3);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(74, 24);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // gridSaves
      // 
      this.gridSaves.AllowUserToAddRows = false;
      this.gridSaves.AllowUserToDeleteRows = false;
      this.gridSaves.AllowUserToResizeColumns = false;
      this.gridSaves.AllowUserToResizeRows = false;
      this.gridSaves.AutoGenerateColumns = false;
      this.gridSaves.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.gridSaves.BackgroundColor = System.Drawing.SystemColors.Window;
      this.gridSaves.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.gridSaves.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
      this.gridSaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gridSaves.ColumnHeadersVisible = false;
      this.gridSaves.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.locationDataGridViewTextBoxColumn});
      this.gridSaves.DataSource = this.gameSaveBindingSource;
      this.gridSaves.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridSaves.Location = new System.Drawing.Point(3, 3);
      this.gridSaves.Name = "gridSaves";
      this.gridSaves.ReadOnly = true;
      this.gridSaves.RowHeadersVisible = false;
      this.tableLayoutPanel1.SetRowSpan(this.gridSaves, 5);
      this.gridSaves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.gridSaves.Size = new System.Drawing.Size(447, 230);
      this.gridSaves.TabIndex = 0;
      // 
      // nameDataGridViewTextBoxColumn
      // 
      this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
      this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
      this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
      this.nameDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // locationDataGridViewTextBoxColumn
      // 
      this.locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
      this.locationDataGridViewTextBoxColumn.HeaderText = "Location";
      this.locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
      this.locationDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // gameSaveBindingSource
      // 
      this.gameSaveBindingSource.DataSource = typeof(CloudGameSaves.GameSave);
      // 
      // btnAdd
      // 
      this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btnAdd.Location = new System.Drawing.Point(456, 3);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(74, 24);
      this.btnAdd.TabIndex = 1;
      this.btnAdd.Text = "Add";
      this.btnAdd.UseVisualStyleBackColor = true;
      // 
      // btnEdit
      // 
      this.btnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btnEdit.Location = new System.Drawing.Point(456, 33);
      this.btnEdit.Name = "btnEdit";
      this.btnEdit.Size = new System.Drawing.Size(74, 24);
      this.btnEdit.TabIndex = 2;
      this.btnEdit.Text = "Edit";
      this.btnEdit.UseVisualStyleBackColor = true;
      // 
      // btnRemove
      // 
      this.btnRemove.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btnRemove.Location = new System.Drawing.Point(456, 63);
      this.btnRemove.Name = "btnRemove";
      this.btnRemove.Size = new System.Drawing.Size(74, 24);
      this.btnRemove.TabIndex = 3;
      this.btnRemove.Text = "Remove";
      this.btnRemove.UseVisualStyleBackColor = true;
      // 
      // btnClear
      // 
      this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btnClear.Location = new System.Drawing.Point(456, 93);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(74, 24);
      this.btnClear.TabIndex = 4;
      this.btnClear.Text = "Clear";
      this.btnClear.UseVisualStyleBackColor = true;
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 1;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
      this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 4);
      this.tableLayoutPanel2.Controls.Add(this.numScanInterval, 0, 1);
      this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 3);
      this.tableLayoutPanel2.Controls.Add(this.label2, 0, 2);
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point(10, 10);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 5;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(533, 336);
      this.tableLayoutPanel2.TabIndex = 8;
      // 
      // label1
      // 
      this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 3);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(98, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Scan Interval (ms):";
      // 
      // numScanInterval
      // 
      this.numScanInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.numScanInterval.Location = new System.Drawing.Point(3, 25);
      this.numScanInterval.Name = "numScanInterval";
      this.numScanInterval.Size = new System.Drawing.Size(527, 22);
      this.numScanInterval.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(3, 53);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(44, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Games:";
      // 
      // EditGaveSaveSettings
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(553, 356);
      this.Controls.Add(this.tableLayoutPanel2);
      this.Name = "EditGaveSaveSettings";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Settings";
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gridSaves)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gameSaveBindingSource)).EndInit();
      this.tableLayoutPanel2.ResumeLayout(false);
      this.tableLayoutPanel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numScanInterval)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.DataGridView gridSaves;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnEdit;
    private System.Windows.Forms.Button btnRemove;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
    private System.Windows.Forms.BindingSource gameSaveBindingSource;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown numScanInterval;
    private System.Windows.Forms.Label label2;
  }
}