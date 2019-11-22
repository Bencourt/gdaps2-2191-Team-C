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
    class HealthPotion : Item
    {
        int data;
        Rectangle rect;
        bool isActive;
        public HealthPotion(int data, Rectangle rect, Texture2D text) 
            :base(data,rect,text)
        {
            isActive = true;
        }

        public void Use(Player player)
        {
            player.Health += data;
        }

        public override void Update(Player player)
        {
            base.Update(player);
            //if (rect.Intersects(player.PlayerRectangle) && isActive)
               // player.ItemsHeld++;
        }

    }
}
