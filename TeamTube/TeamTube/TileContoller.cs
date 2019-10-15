using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TeamTube
{

    class TileController
    {
        //need to load levels from file.io and save them to 2d arrays
        //2d arrays for tiles on the map
        public List<TileType[,]> levels;
        
        //set level dimensions in constructor
        int xLevelDimension;
        int yLevelDimension;
        
        //streamwriter
        StreamWriter writer; //unused

        //streamreader
        StreamReader reader;

        //constructor
        public TileController(int x, int y)
        {
            //set the dimensions
            this.xLevelDimension = x;
            this.yLevelDimension = y;

            //instantiate the LIST OF ARRAYS
            levels = new List<TileType[,]>();
        }
        
        //method for creating level, makes a Tiletype 2d array usable by the rest of game1
        public void CreateLevel1(string path)
        {

            //create level of size xLevelDimension by yLevelDimension
            TileType[,] newlevel = new TileType[xLevelDimension, yLevelDimension];

            //load in text file
            reader = File.OpenText(path);

            //check if reader is null
            if (reader != null)
            {
                //we need to read a whole line of the text file and set figure out what each character means
                //each instance of this loop coresponds to one row of the level
                for (int y = 0; y < yLevelDimension; y++)
                {
                    //each instance of this loop coresponds to one tile in the row
                    for (int x = 0; x < xLevelDimension; x++)
                    {
                        //we take the x and y values at each of these times and determine what the character should mean
                        //parse into an char 
                        string tile = Convert.ToString(reader.Read());
                        int intTile = int.Parse(tile);
                        //assign the enum for current tile based on streamreader's character
                        //ascii char start from 48 (48 = 0, 49 = 1 etc)
                        switch (intTile-48)
                        {
                            case 0:
                                newlevel[x, y] = TileType.Wall;
                                break;
                            case 1:
                                newlevel[x, y] = TileType.floor;
                                break;
                            case 2:
                                newlevel[x, y] = TileType.entrance;
                                break;
                            case 3:
                                newlevel[x, y] = TileType.exit;
                                break;
                            default:
                                //this shouldn't happen, but if it does, make it an error tile
                                newlevel[x, y] = TileType.error;
                                break;
                        }
                    }
                }
            }
            //reader is null
            else
            {
                //i'm really sorry if this happens
                Console.WriteLine("read error");
            }
            //close the reader
            reader.Close();

            //add level to the list of levels
            levels.Add(newlevel);
        }


        public void DrawLevel(SpriteBatch spriteBatch, Texture2D wallTexture, Texture2D floorTexture, Texture2D entranceTexture, Texture2D exitTexture, int levelNumber) 
        {
            //draw one tile
            //spriteBatch.Draw(floorTexture, new Rectangle(0, 0, 32, 32), Color.White);

            //draw all the tiles
            //y loop
            //use manual values for now
            for (int y = 0; y < 26; y++)
            {
                for (int x = 0; x < 26; x++)
                {
                    //see what each tile is, then print them
                    switch (levels[levelNumber - 1][x, y])
                    {
                        case TileType.Wall:
                            //draw a wall
                            spriteBatch.Draw(wallTexture, new Rectangle(32 * x, 32 * y, 32, 32), Color.White);
                            break;
                        case TileType.floor:
                            //draw a floor
                            spriteBatch.Draw(floorTexture, new Rectangle(32 * x, 32 * y, 32, 32), Color.White);
                            break;
                        case TileType.entrance:
                            //draw an entrance

                            break;
                        case TileType.exit:
                            //draw an exit

                        case TileType.error:
                            //draw error tile
                            spriteBatch.Draw(floorTexture, new Rectangle(32 * x, 32 * y, 32, 32), Color.White);
                            break;
                    }
                }
            }
        }
    }
}
