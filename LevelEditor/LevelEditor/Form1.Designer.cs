namespace LevelEditor
{
    partial class levelEditor
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
            this.filePathInput = new System.Windows.Forms.TextBox();
            this.filePathLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.levelNameInput = new System.Windows.Forms.TextBox();
            this.levelNameLabel = new System.Windows.Forms.Label();
            this.wallButton = new System.Windows.Forms.Button();
            this.floorButton = new System.Windows.Forms.Button();
            this.entranceButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // filePathInput
            // 
            this.filePathInput.Location = new System.Drawing.Point(663, 32);
            this.filePathInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.filePathInput.Name = "filePathInput";
            this.filePathInput.Size = new System.Drawing.Size(143, 20);
            this.filePathInput.TabIndex = 0;
            // 
            // filePathLabel
            // 
            this.filePathLabel.AutoSize = true;
            this.filePathLabel.Location = new System.Drawing.Point(609, 32);
            this.filePathLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.filePathLabel.Name = "filePathLabel";
            this.filePathLabel.Size = new System.Drawing.Size(51, 13);
            this.filePathLabel.TabIndex = 1;
            this.filePathLabel.Text = "File Path:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(663, 58);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(143, 49);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save to:\r\n";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(575, 408);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "level";
            // 
            // levelNameInput
            // 
            this.levelNameInput.Location = new System.Drawing.Point(663, 7);
            this.levelNameInput.Name = "levelNameInput";
            this.levelNameInput.Size = new System.Drawing.Size(143, 20);
            this.levelNameInput.TabIndex = 4;
            // 
            // levelNameLabel
            // 
            this.levelNameLabel.AutoSize = true;
            this.levelNameLabel.Location = new System.Drawing.Point(593, 12);
            this.levelNameLabel.Name = "levelNameLabel";
            this.levelNameLabel.Size = new System.Drawing.Size(67, 13);
            this.levelNameLabel.TabIndex = 5;
            this.levelNameLabel.Text = "Level Name:";
            // 
            // wallButton
            // 
            this.wallButton.Location = new System.Drawing.Point(722, 190);
            this.wallButton.Name = "wallButton";
            this.wallButton.Size = new System.Drawing.Size(75, 53);
            this.wallButton.TabIndex = 0;
            this.wallButton.Text = "Wall";
            this.wallButton.UseVisualStyleBackColor = true;
            // 
            // floorButton
            // 
            this.floorButton.Location = new System.Drawing.Point(722, 249);
            this.floorButton.Name = "floorButton";
            this.floorButton.Size = new System.Drawing.Size(75, 53);
            this.floorButton.TabIndex = 6;
            this.floorButton.Text = "Floor";
            this.floorButton.UseVisualStyleBackColor = true;
            // 
            // entranceButton
            // 
            this.entranceButton.Location = new System.Drawing.Point(722, 308);
            this.entranceButton.Name = "entranceButton";
            this.entranceButton.Size = new System.Drawing.Size(75, 53);
            this.entranceButton.TabIndex = 7;
            this.entranceButton.Text = "Entrance";
            this.entranceButton.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(722, 367);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 53);
            this.exitButton.TabIndex = 8;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // levelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 432);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.entranceButton);
            this.Controls.Add(this.floorButton);
            this.Controls.Add(this.wallButton);
            this.Controls.Add(this.levelNameLabel);
            this.Controls.Add(this.levelNameInput);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.filePathLabel);
            this.Controls.Add(this.filePathInput);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "levelEditor";
            this.Text = "Level Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filePathInput;
        private System.Windows.Forms.Label filePathLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox levelNameInput;
        private System.Windows.Forms.Label levelNameLabel;
        private System.Windows.Forms.Button wallButton;
        private System.Windows.Forms.Button floorButton;
        private System.Windows.Forms.Button entranceButton;
        private System.Windows.Forms.Button exitButton;
    }
}

