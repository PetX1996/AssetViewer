namespace AssetViewer
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
            this.AssetTree = new System.Windows.Forms.TreeView();
            this.MapTextBox = new System.Windows.Forms.TextBox();
            this.TotalInfoTextBox = new System.Windows.Forms.TextBox();
            this.ModCheckBox = new System.Windows.Forms.CheckBox();
            this.MapCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // AssetTree
            // 
            this.AssetTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.AssetTree.Location = new System.Drawing.Point(156, 12);
            this.AssetTree.Name = "AssetTree";
            this.AssetTree.Size = new System.Drawing.Size(322, 356);
            this.AssetTree.TabIndex = 0;
            // 
            // MapTextBox
            // 
            this.MapTextBox.Location = new System.Drawing.Point(34, 30);
            this.MapTextBox.Name = "MapTextBox";
            this.MapTextBox.Size = new System.Drawing.Size(116, 20);
            this.MapTextBox.TabIndex = 2;
            this.MapTextBox.Text = "MapName";
            this.MapTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MapTextBox_KeyPress);
            // 
            // TotalInfoTextBox
            // 
            this.TotalInfoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.TotalInfoTextBox.Location = new System.Drawing.Point(12, 56);
            this.TotalInfoTextBox.Multiline = true;
            this.TotalInfoTextBox.Name = "TotalInfoTextBox";
            this.TotalInfoTextBox.Size = new System.Drawing.Size(138, 312);
            this.TotalInfoTextBox.TabIndex = 5;
            // 
            // ModCheckBox
            // 
            this.ModCheckBox.AutoSize = true;
            this.ModCheckBox.Location = new System.Drawing.Point(13, 10);
            this.ModCheckBox.Name = "ModCheckBox";
            this.ModCheckBox.Size = new System.Drawing.Size(47, 17);
            this.ModCheckBox.TabIndex = 6;
            this.ModCheckBox.Text = "Mod";
            this.ModCheckBox.UseVisualStyleBackColor = true;
            this.ModCheckBox.CheckedChanged += new System.EventHandler(this.ModCheckBox_CheckedChanged);
            // 
            // MapCheckBox
            // 
            this.MapCheckBox.AutoSize = true;
            this.MapCheckBox.Location = new System.Drawing.Point(13, 33);
            this.MapCheckBox.Name = "MapCheckBox";
            this.MapCheckBox.Size = new System.Drawing.Size(15, 14);
            this.MapCheckBox.TabIndex = 7;
            this.MapCheckBox.UseVisualStyleBackColor = true;
            this.MapCheckBox.CheckedChanged += new System.EventHandler(this.ModCheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 380);
            this.Controls.Add(this.MapCheckBox);
            this.Controls.Add(this.ModCheckBox);
            this.Controls.Add(this.MapTextBox);
            this.Controls.Add(this.AssetTree);
            this.Controls.Add(this.TotalInfoTextBox);
            this.Name = "MainForm";
            this.Text = "AssetViewer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView AssetTree;
        private System.Windows.Forms.TextBox MapTextBox;
        private System.Windows.Forms.TextBox TotalInfoTextBox;
        private System.Windows.Forms.CheckBox ModCheckBox;
        private System.Windows.Forms.CheckBox MapCheckBox;
    }
}

