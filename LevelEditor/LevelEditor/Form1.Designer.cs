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
            this.levelSaveFileDialouge = new System.Windows.Forms.SaveFileDialog();
            this.loadLevelDialouge = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wallToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.floorToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entranceToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // levelSaveFileDialouge
            // 
            this.levelSaveFileDialouge.DefaultExt = "txt";
            this.levelSaveFileDialouge.FileName = "MyLevel";
            this.levelSaveFileDialouge.InitialDirectory = "../../../../TeamTube/TeamTube/Levels/";
            this.levelSaveFileDialouge.Title = "save level ";
            this.levelSaveFileDialouge.FileOk += new System.ComponentModel.CancelEventHandler(this.LevelSaveFileDialouge_FileOk);
            // 
            // loadLevelDialouge
            // 
            this.loadLevelDialouge.FileName = "MyLevel";
            this.loadLevelDialouge.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            this.loadLevelDialouge.InitialDirectory = "../../../../TeamTube/TeamTube/Levels/";
            this.loadLevelDialouge.FileOk += new System.ComponentModel.CancelEventHandler(this.LoadLevelDialouge_FileOk);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1380, 33);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripNew,
            this.toolStripOpen,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolStripNew
            // 
            this.toolStripNew.Name = "toolStripNew";
            this.toolStripNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.toolStripNew.Size = new System.Drawing.Size(270, 34);
            this.toolStripNew.Text = "New";
            this.toolStripNew.Click += new System.EventHandler(this.CreateLevel);
            // 
            // toolStripOpen
            // 
            this.toolStripOpen.Name = "toolStripOpen";
            this.toolStripOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.toolStripOpen.Size = new System.Drawing.Size(270, 34);
            this.toolStripOpen.Text = "Open";
            this.toolStripOpen.Click += new System.EventHandler(this.ToolStripOpen_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(58, 29);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wallToolToolStripMenuItem,
            this.floorToolToolStripMenuItem,
            this.entranceToolToolStripMenuItem,
            this.exitToolToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // wallToolToolStripMenuItem
            // 
            this.wallToolToolStripMenuItem.Name = "wallToolToolStripMenuItem";
            this.wallToolToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.wallToolToolStripMenuItem.Text = "Wall Tool";
            this.wallToolToolStripMenuItem.Click += new System.EventHandler(this.WallToolToolStripMenuItem_Click);
            // 
            // floorToolToolStripMenuItem
            // 
            this.floorToolToolStripMenuItem.Name = "floorToolToolStripMenuItem";
            this.floorToolToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.floorToolToolStripMenuItem.Text = "Floor Tool";
            this.floorToolToolStripMenuItem.Click += new System.EventHandler(this.FloorToolToolStripMenuItem_Click);
            // 
            // entranceToolToolStripMenuItem
            // 
            this.entranceToolToolStripMenuItem.Name = "entranceToolToolStripMenuItem";
            this.entranceToolToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.entranceToolToolStripMenuItem.Text = "Entrance Tool";
            this.entranceToolToolStripMenuItem.Click += new System.EventHandler(this.EntranceToolToolStripMenuItem_Click);
            // 
            // exitToolToolStripMenuItem
            // 
            this.exitToolToolStripMenuItem.Name = "exitToolToolStripMenuItem";
            this.exitToolToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.exitToolToolStripMenuItem.Text = "Exit Tool";
            this.exitToolToolStripMenuItem.Click += new System.EventHandler(this.ExitToolToolStripMenuItem_Click);
            // 
            // levelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1380, 1301);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "levelEditor";
            this.Text = "Level Editor";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog levelSaveFileDialouge;
        private System.Windows.Forms.OpenFileDialog loadLevelDialouge;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripNew;
        private System.Windows.Forms.ToolStripMenuItem toolStripOpen;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wallToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem floorToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entranceToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolToolStripMenuItem;
    }
}

