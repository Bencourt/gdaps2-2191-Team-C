using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelEditor
{
    public enum ToolState
    {
        Wall,
        Floor,
        Entrance,
        Exit
    }

    public enum TileState
    {
        Wall,
        Floor,
        Entrance,
        Exit
    }

    public partial class levelEditor : Form
    {
        //level name
        string levelName;
        //level path
        string levelPath;
        //toolstate
        ToolState toolState;
        //tilestate
        public TileState[,] tileState;
        public levelEditor()
        {
            InitializeComponent();
            levelName = "MyLevel";
            levelPath = "";
        }

        private void levelNameInput_TextChanged(object sender, EventArgs e)
        {
            //change the level name
            levelName = levelNameInput.Text;
        }

        private void filePathInput_TextChanged(object sender, EventArgs e)
        {
            //change the path name
            levelPath = filePathInput.Text;
        }

        private void ToolButton_Click(object sender, EventArgs e)
        {
            //figure out which button was pressed and change the tool state to it
            if (sender == wallButton) 
            { 
                toolState = ToolState.Wall; 
            }
            if (sender == floorButton) 
            { 
                toolState = ToolState.Floor; 
            }
            if (sender == entranceButton) 
            { 
                toolState = ToolState.Entrance; 
            }
            if (sender == exitButton) 
            { 
                toolState = ToolState.Exit; 
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //save the level based on the name, path and level layout
        }
    }
}
