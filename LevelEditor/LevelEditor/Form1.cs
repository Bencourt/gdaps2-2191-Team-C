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

        Button[,] tileButtons;

        //instantiate buttons
        public void InstantiateButtons(object sender, EventArgs e)
        {
            //make tile buttons into a 26 by 26 array of buttons
            tileButtons = new Button[26, 26];

            //for each of them
            for( int y = 0; y < 26; y++)
            {
                for(int x = 0; x < 26; x++)
                {
                    //set the text to w
                    tileButtons[x, y].Text = "w";
                    //set location
                    tileButtons[x, y].Location = new Point((30 * x) + 20, (30 * y) + 20);
                    //set size
                    tileButtons[x, y].Size = new Size(25, 25);
                    //set the click event to tile button click
                    //tileButtons[x, y].Click += tileButton_Click(tileButtons[x, y]);
                }
            }
        } 

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

        private void tileButton_Click(Button sender)
        {
            //change this sender's text based on what the toolstate is
            switch (toolState)
            {
                case ToolState.Wall:
                    sender.Text = "w";
                    break;
                case ToolState.Floor:
                    sender.Text = "f";
                    break;
                case ToolState.Entrance:
                    sender.Text = "e";
                    break;
                case ToolState.Exit:
                    sender.Text = "x";
                    break;
            }
        }
    }
}
