namespace ActualFass.Window
{
  partial class Form1
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.treeResultat = new System.Windows.Forms.TreeView();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.btnSök = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // textBox1
      // 
      this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.textBox1.Location = new System.Drawing.Point(23, 23);
      this.textBox1.Name = "textBox1";
      this.textBox1.PlaceholderText = "Sök på läkemedel, substans eller sjukdom";
      this.textBox1.Size = new System.Drawing.Size(597, 25);
      this.textBox1.TabIndex = 4;
      this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.treeResultat);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.groupBox1.Location = new System.Drawing.Point(20, 54);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
      this.groupBox1.Size = new System.Drawing.Size(681, 499);
      this.groupBox1.TabIndex = 5;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Resultat";
      // 
      // treeResultat
      // 
      this.treeResultat.BackColor = System.Drawing.SystemColors.Control;
      this.treeResultat.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.treeResultat.Dock = System.Windows.Forms.DockStyle.Fill;
      this.treeResultat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.treeResultat.FullRowSelect = true;
      this.treeResultat.ImageIndex = 0;
      this.treeResultat.ImageList = this.imageList1;
      this.treeResultat.Indent = 25;
      this.treeResultat.ItemHeight = 20;
      this.treeResultat.Location = new System.Drawing.Point(10, 28);
      this.treeResultat.Name = "treeResultat";
      this.treeResultat.SelectedImageIndex = 0;
      this.treeResultat.Size = new System.Drawing.Size(661, 461);
      this.treeResultat.TabIndex = 6;
      this.treeResultat.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeResultat_NodeMouseDoubleClick);
      // 
      // imageList1
      // 
      this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "price-tag-label.png");
      this.imageList1.Images.SetKeyName(1, "pill.png");
      this.imageList1.Images.SetKeyName(2, "box.png");
      this.imageList1.Images.SetKeyName(3, "tag-hash.png");
      this.imageList1.Images.SetKeyName(4, "building.png");
      this.imageList1.Images.SetKeyName(5, "molecule.png");
      this.imageList1.Images.SetKeyName(6, "burn.png");
      // 
      // btnSök
      // 
      this.btnSök.Location = new System.Drawing.Point(626, 23);
      this.btnSök.Name = "btnSök";
      this.btnSök.Size = new System.Drawing.Size(75, 25);
      this.btnSök.TabIndex = 6;
      this.btnSök.Text = "Sök";
      this.btnSök.UseVisualStyleBackColor = true;
      this.btnSök.Click += new System.EventHandler(this.btnSök_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(721, 573);
      this.Controls.Add(this.btnSök);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.textBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.Name = "Form1";
      this.Padding = new System.Windows.Forms.Padding(20);
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Sök på FASS";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.groupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private TextBox textBox1;
    private GroupBox groupBox1;
    private TreeView treeResultat;
    private Button btnSök;
    private ImageList imageList1;
  }
}