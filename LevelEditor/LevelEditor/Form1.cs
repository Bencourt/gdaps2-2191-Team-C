using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
        //IO stuff
        StreamReader reader;
        StreamWriter writer;
        //create a new stream
        Stream stream;
        
        //toolstate
        ToolState toolState;
        //tilestate
        public TileState[,] tileState;
        //array of bottons
        public Button[,] tileButtons;

        public levelEditor()
        {
            InitializeComponent();
            
            //set toolstate to wall initially
            toolState = ToolState.Wall;
            tileState = new TileState[26, 26];
        }

        //instantiate buttons
        public void CreateLevel(object sender, EventArgs e)
        {
            //if the button array is null then create a new array
            if (tileButtons is null)
            {
                //make tile buttons into a 26 by 26 array of buttons
                tileButtons = new System.Windows.Forms.Button[26, 26];

                //for each of them
                for (int y = 0; y < 26; y++)
                {
                    for (int x = 0; x < 26; x++)
                    {
                        //add to the list of drawables
                        tileButtons[x, y] = new System.Windows.Forms.Button();
                        //add to form1
                        this.Controls.Add(tileButtons[x, y]);
                        //set size
                        tileButtons[x, y].Size = new Size(25, 25);
                        //set location
                        tileButtons[x, y].Location = new Point((30 * x) + 120, (30 * y) + 50);

                        //set the click event to tile button click
                        tileButtons[x, y].MouseDown += new MouseEventHandler(TileButton_Click);

                        tileButtons[x, y].CreateGraphics();
                    }
                }
            }
            
            //for each of them
            for ( int y = 0; y < 26; y++)
            {
                for(int x = 0; x < 26; x++)
                {
                    //set tileState to wall
                    tileState[x, y] = TileState.Wall;
                    //back color to black
                    tileButtons[x, y].BackColor = Color.Black;
                    //set the text to w
                    tileButtons[x, y].Text = "w";
                }
            }
        } 


        private void TileButton_Click(object sender, EventArgs e)
        {
            //check if mousestate is down
            
            
                Button button = (Button)sender;
                //change this sender's text and tile state based on what the toolstate is
                switch (toolState)
                {
                    case ToolState.Wall:
                        button.Text = "w";
                        button.BackColor = Color.Black;
                        //tileState[x, y] = TileState.Wall;
                        break;
                    case ToolState.Floor:
                        button.Text = "f";
                        button.BackColor = Color.White;
                        //tileState[x, y] = TileState.Floor;
                        break;
                    case ToolState.Entrance:
                        button.Text = "e";
                        button.BackColor = Color.Blue;
                        //tileState[x, y] = TileState.Entrance;
                        break;
                    case ToolState.Exit:
                        button.Text = "x";
                        button.BackColor = Color.Green;
                        //tileState[x, y] = TileState.Exit;
                        break;
                }
            
        }

        private void ToolStripOpen_Click(object sender, EventArgs e)
        {
            //need to load from a file
            //if the button array doesn't exist
            if (tileButtons is null)
            {
                //create level
                CreateLevel(sender, e);
            }

            loadLevelDialouge.ShowDialog();
        }

        private void LoadLevelDialouge_FileOk(object sender, CancelEventArgs e)
        {
            

            //the file is good, read it and save it in the level array
             stream = loadLevelDialouge.OpenFile();

            //reader is set to selected file
            //reader = new StreamReader("../../../../TeamTube/TeamTube/Levels/LevelExample.txt");

            //reader is instead set to the stream of the file opened
            reader = new StreamReader(stream);
            //go character by character and set the tile to the read character
            for(int y = 0; y < 26; y++)
            {
                for(int x = 0; x< 26; x++)
                {
                    //tile will be an ascii value for the char in the file
                    int tile = reader.Read();
                    switch (tile - 48)
                    {
                        //the ascii value for zero is 48 and the single digit numbers continue: 49, 50, etc. 
                        //we just need to offset tile by 48
                        case 0:
                            //wall is 0
                            tileButtons[x, y].Text = "w";
                            tileButtons[x, y].BackColor = Color.Black;
                            tileState[x, y] = TileState.Wall;
                            break;
                        case 1:
                            //floor is 1
                            tileButtons[x, y].Text = "f";
                            tileButtons[x, y].BackColor = Color.White;
                            tileState[x, y] = TileState.Floor;
                            break;
                        case 2:
                            //entrance is 2
                            tileButtons[x, y].Text = "e";
                            tileButtons[x, y].BackColor = Color.Blue;
                            tileState[x, y] = TileState.Entrance;
                            break;
                        case 3:
                            //exit is 3
                            tileButtons[x, y].Text = "x";
                            tileButtons[x, y].BackColor = Color.Green;
                            tileState[x, y] = TileState.Exit;
                            break;
                        default:
                            tileButtons[x, y].Text = "w";
                            tileState[x, y] = TileState.Wall;
                            break;
                    }
                }
            }
            //close the reader
            reader.Close();
        }

        private void WallToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //set toolstate to wall
            toolState = ToolState.Wall;
        }

        private void FloorToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //set toolstate to floor
            toolState = ToolState.Floor;
        }

        private void EntranceToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //set toolstate to entrance
            toolState = ToolState.Entrance;
        }

        private void ExitToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //set toolstate to exit
            toolState = ToolState.Exit;
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if the tile buttons are null, don't do anything
            if (tileButtons[0, 0] == null)
            {

            }
            //otherwise open the save dialouge
            else
            {
                levelSaveFileDialouge.ShowDialog();
            }
        }

        private void LevelSaveFileDialouge_FileOk(object sender, CancelEventArgs e)
        {
            //need a FileStream to save to a file
            FileStream newStream;

            stream = levelSaveFileDialouge.OpenFile();
            newStream = (FileStream)stream;

            writer = new StreamWriter(newStream);
            //save the level layout to  the filepath
            //go character by character and set the tile to the written character
            for (int y = 0; y < 26; y++)
            {
                for (int x = 0; x < 26; x++)
                {
                    string tile = tileButtons[x, y].Text;
                    //determine what to write to the file
                    switch (tile)
                    {
                        case "w":
                            //writes 0 to the file
                            writer.Write("0");
                            break;
                        case "f":
                            //writes 1 to the file
                            writer.Write("1");
                            break;
                        case "e":
                            //writes 2 to the file
                            writer.Write("2");
                            break;
                        case "x":
                            //writes 3 to the file
                            writer.Write("3");
                            break;
                        default:
                            //writes 0 to the file
                            writer.Write("0");
                            break;
                    }
                    
                }
            }
            writer.Close();
        }
    }
}
