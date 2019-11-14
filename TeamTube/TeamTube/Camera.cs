using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TeamTube
{
    class Camera
    {
        public Matrix Transform { get; private set; }

        

        public void Follow(Player player)
        {
            float scale = 3;
            var position = Matrix.CreateTranslation(
                -player.PlayerRectangle.X + (player.PlayerRectangle.Width/2 ), // the positions plus half the width and height
                -player.PlayerRectangle.Y + (player.PlayerRectangle.Height/2), // so the center will be the rarget
                0);

            var offset = Matrix.CreateTranslation( //multiplies the offset by half the screen size
                    Game1.screenWidth /7,
                    Game1.screenHeight /7,
                    0);

            var scaleTotal = Matrix.CreateScale(new Vector3(scale, scale, scale));

            Transform = (position * offset) * scaleTotal;
        }
    }
}