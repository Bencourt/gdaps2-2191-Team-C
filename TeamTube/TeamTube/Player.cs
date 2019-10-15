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
        CharacterController characterController;
        TileController tiles;

        public Player(CharacterController characterController, TileController tiles, int health, Rectangle playerRectangle, Texture2D playerTexture)
        {
            xTarget = 0;
            yTarget = 0;
            this.Health = health;
            moving = false;
            this.characterController = characterController;
            this.tiles = tiles;
            this.playerRectangle = playerRectangle;
            this.playerTexture = playerTexture;
            characterController.Add(this, playerRectangle.X/32, playerRectangle.Y/32);
        }

        public override bool CheckTarget(int targetX, int targetY)
        {
            int x = characterController.FindCharacter(this).X;
            int y = characterController.FindCharacter(this).Y;

            if(tiles.levels[0][x+targetX,y+targetY] != TileType.floor)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Update(KeyboardState keyboardState)
        {
            if (!moving)
            {
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    if (CheckTarget(0, -1))
                    {
                        moving = true;
                        characterController.MoveCharacter(this, 0, -1);
                        yTarget += 32;
                    }
                }
                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    if (CheckTarget(0, 1))
                    {
                        moving = true;
                        characterController.MoveCharacter(this, 0, 1);
                        yTarget -= 32;
                    }
                }
                if (keyboardState.IsKeyDown(Keys.Left))
                {
                    if (CheckTarget(-1, 0))
                    {
                        moving = true;
                        characterController.MoveCharacter(this, -1, 0);
                        xTarget -= 32;
                    }
                }
                if (keyboardState.IsKeyDown(Keys.Right))
                {
                    if (CheckTarget(1, 0))
                    {
                        moving = true;
                        characterController.MoveCharacter(this, 1, 0);
                        xTarget += 32;
                    }
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
