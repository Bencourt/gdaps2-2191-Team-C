using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TeamTube
{

    class TileContoller
    {
        //need to load levels from file.io and save them to 2d arrays
        //2d arrays for tiles on the map
        TileType[,] level1;

        //parameters to get the 2d arrays
        public TileType[,] Level1 { get { return level1; } }

        //paths for levels
        string level1Path;

        //streamwriter
        StreamWriter writer;

        //streamreader
        StreamReader reader;

        //constructor
        public TileContoller()
        {
           //nothing to take in the contructor
        }
        
        //method for creating level, makes a Tiletype 2d array usable by the rest of game1
        public void CreateLevel(int Width, int Height, string path, TileType[,] level)
        {
            //create level of size xWidth by yWidth
            level = new TileType[Width, Height];

            //load in text file
            reader = File.OpenText(path);

            //we need to read a whole line of the text file and set figure out what each character means
            //each instance of this loop coresponds to one row of the level
            for (int y = 0; y < Height; y++)
            {
                //each instance of this loop coresponds to one tile in the row
                for (int x = 0; x< Width; x++)
                {
                    //we take the x and y values at each of these times and determine what the character should mean
                    //parse into an char 
                    char tile = (char)reader.Read();
                    int intTile = tile;
                    //assign the enum for current tile based on streamreader's character
                    switch (intTile)
                    {
                        case 0:
                            level[x, y] = TileType.Wall;
                            break;
                        case 1:
                            level[x, y] = TileType.floor;
                            break;
                        case 2:
                            level[x, y] = TileType.entrance;
                            break;
                        case 3:
                            level[x, y] = TileType.exit;
                            break;
                        default:
                            //this shouldn't happen, but if it does, make it an error
                            level[x, y] = TileType.error;
                            break;
                    }
                }
            }
            
            
        }


    }
}
