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
                player.ItemsHeld += 1;
            }
        }

        public virtual void Draw(SpriteBatch sb)
        {
            if(isActive)
            sb.Draw(text, rect, Color.White);
        }
    }
}
