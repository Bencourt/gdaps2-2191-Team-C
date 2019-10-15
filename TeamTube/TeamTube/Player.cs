using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTube
{
    class Player : Character, iMovable
    {
        Texture2D playerTexture;
        Rectangle playerRectangle;
        bool moving;
        int xTarget;
        int yTarget;

        public Player(CharacterController characterController, int health, Rectangle playerRectangle, Texture2D playerTexture)
        {
            xTarget = 0;
            yTarget = 0;
            this.Health = health;
            moving = false;
            this.playerRectangle = playerRectangle;
            this.playerTexture = playerTexture;
        }

        public override void GetAdjacent(TileType[] tiles, int[] characters)
        {

        }

        public void Update(KeyboardState keyboardState)
        {
            if (!moving)
            {
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    moving = true;
                    yTarget += 32;
                }
                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    moving = true;
                    yTarget -= 32;
                }
                if (keyboardState.IsKeyDown(Keys.Left))
                {
                    moving = true;
                    xTarget -= 32;
                }
                if (keyboardState.IsKeyDown(Keys.Right))
                {
                    moving = true;
                    xTarget += 32;
                }
            }
            else if (moving)
            {
                if(xTarget > 0)
                {
                    playerRectangle.X++;
                    xTarget--;
                }
                else if(xTarget < 0)
                {
                    playerRectangle.X--;
                    xTarget++;
                }
                else
                {
                    //dont move
                }

                if(yTarget > 0)
                {
                    playerRectangle.Y--;
                    yTarget--;
                }
                else if(yTarget < 0)
                {
                    playerRectangle.Y++;
                    yTarget++;
                }
                else
                {
                    //dont move
                }

                if(xTarget == 0 && yTarget == 0)
                {
                    moving = false;
                }
            }
        }
        public override void Death()
        {

        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(playerTexture, playerRectangle, null, Color.White);
        }

    }
}
