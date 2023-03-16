namespace Forests
{
    partial class BackgroundSelect
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
            this.ImageSelect = new System.Windows.Forms.Button();
            this.imagePath = new System.Windows.Forms.TextBox();
            this.ColorSelect = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ImageSelect
            // 
            this.ImageSelect.Location = new System.Drawing.Point(12, 12);
            this.ImageSelect.Name = "ImageSelect";
            this.ImageSelect.Size = new System.Drawing.Size(75, 23);
            this.ImageSelect.TabIndex = 0;
            this.ImageSelect.Text = "Image";
            this.ImageSelect.UseVisualStyleBackColor = true;
            this.ImageSelect.Click += new System.EventHandler(this.ImageSelect_Click);
            // 
            // imagePath
            // 
            this.imagePath.Location = new System.Drawing.Point(93, 14);
            this.imagePath.Name = "imagePath";
            this.imagePath.Size = new System.Drawing.Size(241, 20);
            this.imagePath.TabIndex = 1;
            // 
            // ColorSelect
            // 
            this.ColorSelect.HideSelection = false;
            this.ColorSelect.Location = new System.Drawing.Point(93, 41);
            this.ColorSelect.MultiSelect = false;
            this.ColorSelect.Name = "ColorSelect";
            this.ColorSelect.Size = new System.Drawing.Size(121, 97);
            this.ColorSelect.TabIndex = 2;
            this.ColorSelect.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Color";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select a color or an image";
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(259, 144);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 5;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(178, 144);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(75, 23);
            this.ClearBtn.TabIndex = 6;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // BackgroundSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 182);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ColorSelect);
            this.Controls.Add(this.imagePath);
            this.Controls.Add(this.ImageSelect);
            this.Name = "BackgroundSelect";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ImageSelect;
        private System.Windows.Forms.TextBox imagePath;
        private System.Windows.Forms.ListView ColorSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button ClearBtn;
    }
}