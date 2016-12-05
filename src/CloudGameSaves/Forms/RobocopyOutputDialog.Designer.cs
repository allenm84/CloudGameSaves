namespace CloudGameSaves
{
  partial class RobocopyOutputDialog
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
      this.txtOutput = new System.Windows.Forms.RichTextBox();
      this.SuspendLayout();
      // 
      // txtOutput
      // 
      this.txtOutput.BackColor = System.Drawing.Color.Black;
      this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtOutput.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtOutput.ForeColor = System.Drawing.Color.White;
      this.txtOutput.Location = new System.Drawing.Point(10, 10);
      this.txtOutput.Name = "txtOutput";
      this.txtOutput.ReadOnly = true;
      this.txtOutput.Size = new System.Drawing.Size(758, 371);
      this.txtOutput.TabIndex = 0;
      this.txtOutput.Text = "";
      this.txtOutput.WordWrap = false;
      // 
      // RobocopyOutputDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(778, 391);
      this.Controls.Add(this.txtOutput);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
      this.Name = "RobocopyOutputDialog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "robocopy Output";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.RichTextBox txtOutput;
  }
}