namespace Birds
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.fileToolStrip = new System.Windows.Forms.ToolStrip();
            this.newButton = new System.Windows.Forms.ToolStripButton();
            this.openButton = new System.Windows.Forms.ToolStripButton();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.ExportPNG = new System.Windows.Forms.ToolStripButton();
            this.deleteButton = new System.Windows.Forms.ToolStripButton();
            this.undoButton = new System.Windows.Forms.ToolStripButton();
            this.redoButton = new System.Windows.Forms.ToolStripButton();
            this.SetBackgroundBtn = new System.Windows.Forms.ToolStripButton();
            this.drawingToolStrip = new System.Windows.Forms.ToolStrip();
            this.pointerButton = new System.Windows.Forms.ToolStripButton();
            this.MoveSelectedButton = new System.Windows.Forms.ToolStripButton();
            this.CloneElementBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ScaleBtn = new System.Windows.Forms.ToolStripButton();
            this.scaleLabel = new System.Windows.Forms.ToolStripLabel();
            this.scale = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Bird01Button = new System.Windows.Forms.ToolStripButton();
            this.Bird02Button = new System.Windows.Forms.ToolStripButton();
            this.Bird03Button = new System.Windows.Forms.ToolStripButton();
            this.Bird04Button = new System.Windows.Forms.ToolStripButton();
            this.Bird05Button = new System.Windows.Forms.ToolStripButton();
            this.Bird06Button = new System.Windows.Forms.ToolStripButton();
            this.Bird07Button = new System.Windows.Forms.ToolStripButton();
            this.lineButton = new System.Windows.Forms.ToolStripButton();
            this.fileToolStrip.SuspendLayout();
            this.drawingToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawingPanel
            // 
            this.drawingPanel.BackColor = System.Drawing.Color.White;
            this.drawingPanel.Location = new System.Drawing.Point(96, 67);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(979, 846);
            this.drawingPanel.TabIndex = 1;
            this.drawingPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseDown);
            this.drawingPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseMove);
            this.drawingPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseUp);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // fileToolStrip
            // 
            this.fileToolStrip.AutoSize = false;
            this.fileToolStrip.BackColor = System.Drawing.Color.Plum;
            this.fileToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.fileToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.fileToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newButton,
            this.openButton,
            this.saveButton,
            this.ExportPNG,
            this.deleteButton,
            this.undoButton,
            this.redoButton,
            this.SetBackgroundBtn});
            this.fileToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fileToolStrip.Name = "fileToolStrip";
            this.fileToolStrip.Size = new System.Drawing.Size(1075, 64);
            this.fileToolStrip.TabIndex = 2;
            this.fileToolStrip.Text = "toolStrip1";
            // 
            // newButton
            // 
            this.newButton.AutoSize = false;
            this.newButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newButton.Image = ((System.Drawing.Image)(resources.GetObject("newButton.Image")));
            this.newButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(61, 61);
            this.newButton.Text = "New (N)";
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // openButton
            // 
            this.openButton.AutoSize = false;
            this.openButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openButton.Image = ((System.Drawing.Image)(resources.GetObject("openButton.Image")));
            this.openButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(61, 61);
            this.openButton.Text = "Open Drawing (O)";
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.AutoSize = false;
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(61, 61);
            this.saveButton.Text = "Save Drawing (P)";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // ExportPNG
            // 
            this.ExportPNG.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ExportPNG.Image = ((System.Drawing.Image)(resources.GetObject("ExportPNG.Image")));
            this.ExportPNG.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExportPNG.Name = "ExportPNG";
            this.ExportPNG.Size = new System.Drawing.Size(36, 61);
            this.ExportPNG.Text = "Export To PNG (E)";
            this.ExportPNG.Click += new System.EventHandler(this.ExportPNG_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(36, 61);
            this.deleteButton.Text = "Delete (D)";
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // undoButton
            // 
            this.undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoButton.Image = ((System.Drawing.Image)(resources.GetObject("undoButton.Image")));
            this.undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(36, 61);
            this.undoButton.Text = "Undo (U)";
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // redoButton
            // 
            this.redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoButton.Image = ((System.Drawing.Image)(resources.GetObject("redoButton.Image")));
            this.redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(36, 61);
            this.redoButton.Text = "Redo (R)";
            this.redoButton.Click += new System.EventHandler(this.redoButton_Click);
            // 
            // SetBackgroundBtn
            // 
            this.SetBackgroundBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SetBackgroundBtn.Image = ((System.Drawing.Image)(resources.GetObject("SetBackgroundBtn.Image")));
            this.SetBackgroundBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SetBackgroundBtn.Name = "SetBackgroundBtn";
            this.SetBackgroundBtn.Size = new System.Drawing.Size(36, 61);
            this.SetBackgroundBtn.Text = "Set Background (B)";
            this.SetBackgroundBtn.Click += new System.EventHandler(this.SetBackgroundBtn_Click);
            // 
            // drawingToolStrip
            // 
            this.drawingToolStrip.BackColor = System.Drawing.Color.Thistle;
            this.drawingToolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.drawingToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.drawingToolStrip.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.drawingToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointerButton,
            this.MoveSelectedButton,
            this.CloneElementBtn,
            this.toolStripSeparator2,
            this.ScaleBtn,
            this.scaleLabel,
            this.scale,
            this.toolStripSeparator1,
            this.Bird01Button,
            this.Bird02Button,
            this.Bird03Button,
            this.Bird04Button,
            this.Bird05Button,
            this.Bird06Button,
            this.Bird07Button,
            this.lineButton});
            this.drawingToolStrip.Location = new System.Drawing.Point(0, 64);
            this.drawingToolStrip.Name = "drawingToolStrip";
            this.drawingToolStrip.Padding = new System.Windows.Forms.Padding(0, 8, 1, 0);
            this.drawingToolStrip.Size = new System.Drawing.Size(93, 849);
            this.drawingToolStrip.TabIndex = 3;
            this.drawingToolStrip.Text = "Tools";
            // 
            // pointerButton
            // 
            this.pointerButton.AutoSize = false;
            this.pointerButton.CheckOnClick = true;
            this.pointerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pointerButton.Image = ((System.Drawing.Image)(resources.GetObject("pointerButton.Image")));
            this.pointerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pointerButton.Name = "pointerButton";
            this.pointerButton.Size = new System.Drawing.Size(61, 50);
            this.pointerButton.Text = "pointerButton (S)";
            this.pointerButton.Click += new System.EventHandler(this.pointerButton_Click);
            // 
            // MoveSelectedButton
            // 
            this.MoveSelectedButton.CheckOnClick = true;
            this.MoveSelectedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MoveSelectedButton.Image = ((System.Drawing.Image)(resources.GetObject("MoveSelectedButton.Image")));
            this.MoveSelectedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MoveSelectedButton.Name = "MoveSelectedButton";
            this.MoveSelectedButton.Size = new System.Drawing.Size(90, 68);
            this.MoveSelectedButton.Text = "Move Selection (M)";
            this.MoveSelectedButton.Click += new System.EventHandler(this.MoveSelectedButton_Click);
            // 
            // CloneElementBtn
            // 
            this.CloneElementBtn.CheckOnClick = true;
            this.CloneElementBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CloneElementBtn.Image = ((System.Drawing.Image)(resources.GetObject("CloneElementBtn.Image")));
            this.CloneElementBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CloneElementBtn.Name = "CloneElementBtn";
            this.CloneElementBtn.Size = new System.Drawing.Size(90, 68);
            this.CloneElementBtn.Text = "Clone Element (C)";
            this.CloneElementBtn.Click += new System.EventHandler(this.CloneElementBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(90, 6);
            // 
            // ScaleBtn
            // 
            this.ScaleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ScaleBtn.Image = ((System.Drawing.Image)(resources.GetObject("ScaleBtn.Image")));
            this.ScaleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ScaleBtn.Name = "ScaleBtn";
            this.ScaleBtn.Size = new System.Drawing.Size(90, 68);
            this.ScaleBtn.Text = "Resize (F)";
            this.ScaleBtn.Click += new System.EventHandler(this.ScaleBtn_Click);
            // 
            // scaleLabel
            // 
            this.scaleLabel.Name = "scaleLabel";
            this.scaleLabel.Size = new System.Drawing.Size(90, 15);
            this.scaleLabel.Text = "Scale (.01 to 99):";
            this.scaleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // scale
            // 
            this.scale.AutoSize = false;
            this.scale.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.scale.Name = "scale";
            this.scale.Size = new System.Drawing.Size(70, 23);
            this.scale.Text = "1";
            this.scale.Leave += new System.EventHandler(this.scale_Leave);
            this.scale.TextChanged += new System.EventHandler(this.scale_TextChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(90, 6);
            // 
            // Bird01Button
            // 
            this.Bird01Button.AutoSize = false;
            this.Bird01Button.CheckOnClick = true;
            this.Bird01Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Bird01Button.Image = ((System.Drawing.Image)(resources.GetObject("Bird01Button.Image")));
            this.Bird01Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Bird01Button.Name = "Bird01Button";
            this.Bird01Button.Size = new System.Drawing.Size(61, 61);
            this.Bird01Button.Text = "bird";
            this.Bird01Button.Click += new System.EventHandler(this.BirdButton_Click);
            // 
            // Bird02Button
            // 
            this.Bird02Button.AutoSize = false;
            this.Bird02Button.CheckOnClick = true;
            this.Bird02Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Bird02Button.Image = ((System.Drawing.Image)(resources.GetObject("Bird02Button.Image")));
            this.Bird02Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Bird02Button.Name = "Bird02Button";
            this.Bird02Button.Size = new System.Drawing.Size(61, 61);
            this.Bird02Button.Text = "bird2";
            this.Bird02Button.Click += new System.EventHandler(this.BirdButton_Click);
            // 
            // Bird03Button
            // 
            this.Bird03Button.AutoSize = false;
            this.Bird03Button.CheckOnClick = true;
            this.Bird03Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Bird03Button.Image = ((System.Drawing.Image)(resources.GetObject("Bird03Button.Image")));
            this.Bird03Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Bird03Button.Name = "Bird03Button";
            this.Bird03Button.Size = new System.Drawing.Size(61, 61);
            this.Bird03Button.Text = "bird3";
            this.Bird03Button.Click += new System.EventHandler(this.BirdButton_Click);
            // 
            // Bird04Button
            // 
            this.Bird04Button.CheckOnClick = true;
            this.Bird04Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Bird04Button.Image = ((System.Drawing.Image)(resources.GetObject("Bird04Button.Image")));
            this.Bird04Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Bird04Button.Name = "Bird04Button";
            this.Bird04Button.Size = new System.Drawing.Size(90, 68);
            this.Bird04Button.Text = "bird4";
            this.Bird04Button.Click += new System.EventHandler(this.BirdButton_Click);
            // 
            // Bird05Button
            // 
            this.Bird05Button.CheckOnClick = true;
            this.Bird05Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Bird05Button.Image = ((System.Drawing.Image)(resources.GetObject("Bird05Button.Image")));
            this.Bird05Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Bird05Button.Name = "Bird05Button";
            this.Bird05Button.Size = new System.Drawing.Size(90, 68);
            this.Bird05Button.Text = "bird5";
            this.Bird05Button.ToolTipText = "bird5";
            this.Bird05Button.Click += new System.EventHandler(this.BirdButton_Click);
            // 
            // Bird06Button
            // 
            this.Bird06Button.CheckOnClick = true;
            this.Bird06Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Bird06Button.Image = ((System.Drawing.Image)(resources.GetObject("Bird06Button.Image")));
            this.Bird06Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Bird06Button.Name = "Bird06Button";
            this.Bird06Button.Size = new System.Drawing.Size(90, 68);
            this.Bird06Button.Text = "bird6";
            this.Bird06Button.Click += new System.EventHandler(this.BirdButton_Click);
            // 
            // Bird07Button
            // 
            this.Bird07Button.CheckOnClick = true;
            this.Bird07Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Bird07Button.Image = ((System.Drawing.Image)(resources.GetObject("Bird07Button.Image")));
            this.Bird07Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Bird07Button.Name = "Bird07Button";
            this.Bird07Button.Size = new System.Drawing.Size(90, 68);
            this.Bird07Button.Text = "bird7";
            this.Bird07Button.Click += new System.EventHandler(this.BirdButton_Click);
            // 
            // lineButton
            // 
            this.lineButton.AutoSize = false;
            this.lineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lineButton.Image = ((System.Drawing.Image)(resources.GetObject("lineButton.Image")));
            this.lineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(90, 24);
            this.lineButton.Text = "Line";
            this.lineButton.Click += new System.EventHandler(this.lineButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1075, 913);
            this.Controls.Add(this.drawingToolStrip);
            this.Controls.Add(this.fileToolStrip);
            this.Controls.Add(this.drawingPanel);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Bird Drawing";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.fileToolStrip.ResumeLayout(false);
            this.fileToolStrip.PerformLayout();
            this.drawingToolStrip.ResumeLayout(false);
            this.drawingToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel drawingPanel;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.ToolStrip fileToolStrip;
        private System.Windows.Forms.ToolStripButton newButton;
        private System.Windows.Forms.ToolStripButton openButton;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStrip drawingToolStrip;
        private System.Windows.Forms.ToolStripButton pointerButton;
        private System.Windows.Forms.ToolStripButton Bird01Button;
        private System.Windows.Forms.ToolStripButton Bird02Button;
        private System.Windows.Forms.ToolStripButton Bird03Button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton Bird04Button;
        private System.Windows.Forms.ToolStripButton Bird05Button;
        private System.Windows.Forms.ToolStripButton Bird06Button;
        private System.Windows.Forms.ToolStripButton Bird07Button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel scaleLabel;
        private System.Windows.Forms.ToolStripTextBox scale;
        private System.Windows.Forms.ToolStripButton deleteButton;
        private System.Windows.Forms.ToolStripButton undoButton;
        private System.Windows.Forms.ToolStripButton redoButton;
        private System.Windows.Forms.ToolStripButton lineButton;
        private System.Windows.Forms.ToolStripButton SetBackgroundBtn;
        private System.Windows.Forms.ToolStripButton ExportPNG;
        private System.Windows.Forms.ToolStripButton MoveSelectedButton;
        private System.Windows.Forms.ToolStripButton CloneElementBtn;
        private System.Windows.Forms.ToolStripButton ScaleBtn;
    }
}

