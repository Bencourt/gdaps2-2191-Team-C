using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TeamTube
{
    abstract class Item
    {
        int data;
        bool isActive;
        Rectangle rect;
        Texture2D text;

        public Item(int data, Rectangle rect, Texture2D text)
        {
            this.data = data;
            isActive = true;
            this.rect = rect;
            this.text = text;
        }

        public virtual void Update(Player player)
        {
            if(rect.Intersects(player.PlayerRectangle) && isActive)
            {
                isActive = false;
                //changed to be a list of all the items we have
                player.ItemsHeld.Add(this);
            }
        }

        public virtual void Draw(SpriteBatch sb)
        {
            if(isActive)
            sb.Draw(text, rect, Color.White);
        }
        //Random rng = new Random();
        public virtual void Populate(TileController controller, int lvlNumber, Random rng)
        {
            int x = 0;
            int y = 0;
            while(controller.levels[lvlNumber - 1][x, y] != TileType.floor) // while the tile at the random index is not a floor get a new one
            {
                x = rng.Next(26);
                y = rng.Next(26);

                if (controller.levels[lvlNumber - 1][x, y] == TileType.floor) // when it is a floor
                {
                    this.rect.X = (x * 32) + 8; // move the item to that tile
                    this.rect.Y = (y * 32) + 8;
                }
            }
        }
    }
}
