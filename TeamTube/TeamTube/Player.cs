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
        //fields
        Texture2D playerTexture;
        Rectangle playerRectangle;
        bool moving;
        int xTarget;
        int yTarget;
        CharacterController characterController;
        TileController tiles;
        int speed = 2;

        //player rectangle property
        public Rectangle PlayerRectangle
        {
            get { return playerRectangle; }
        }

        //player constructor makes a player in the character and tile controllers
        public Player(CharacterController characterController, TileController tiles, int health, Rectangle playerRectangle, Texture2D playerTexture)
        {
            //move targets set to 0
            xTarget = 0;
            yTarget = 0;
            //Health set
            this.Health = health;
            //player is not moving
            moving = false;
            //set the character controller and tile controller
            this.characterController = characterController;
            this.tiles = tiles;
            //set the rectangle and texture
            this.playerRectangle = playerRectangle;
            this.playerTexture = playerTexture;
            //add the player to the character controller
            characterController.Add(this, playerRectangle.X/32, playerRectangle.Y/32);
            //set the input to be false;
            characterController.Input = false;
        }

        //check target method checks the tiles around the character to determine if a move is valid or not
        public override bool CheckTarget(int targetX, int targetY)
        {
            //get the array position of the character
            int x = characterController.FindCharacter(this).X;
            int y = characterController.FindCharacter(this).Y;

            //if the tiles in the target position of the character is not a wall or character
            if (tiles.levels[0][x + targetX, y + targetY] != TileType.Wall && characterController.Characters[x + targetX, y + targetY] == null)
            {
                if ((targetX == 1 || targetX == -1) && (targetY == 1 || targetY == -1))
                {
                    //recursively check corners
                    if (CheckTarget(targetX, 0) && CheckTarget(0, targetY))
                        return true;
                    else
                        return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        //update method
        public override void Update(KeyboardState keyboardState)
        {
            //make decision regarding movement
            MakeDecision(keyboardState);
            if (moving)
            {
                if (xTarget > 0)
                {
                    playerRectangle.X += speed;
                    xTarget -= speed;
                }
                else if (xTarget < 0)
                {
                    playerRectangle.X -= speed;
                    xTarget += speed;
                }
                else
                {
                    //dont move
                }

                if (yTarget > 0)
                {
                    playerRectangle.Y -= speed;
                    yTarget -= speed;
                }
                else if (yTarget < 0)
                {
                    playerRectangle.Y += speed;
                    yTarget += speed;
                }
                else
                {
                    //dont move
                }

                if (xTarget == 0 && yTarget == 0)
                {
                    moving = false;
                    characterController.Input = false;
                }
            }
        
        }

        public override void MakeDecision(KeyboardState keyboardState)
        {
            if (!moving)
            {
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    if (CheckTarget(0, -1))
                    {
                        moving = true;
                        characterController.MoveCharacter(this, 0, -1);
                        Turn = false;
                        yTarget += 32;
                        //characterController.AllCharacters.Find(this).Next.Value.Turn = true;
                        characterController.Input = true;
                    }
                }
                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    if (CheckTarget(0, 1))
                    {
                        moving = true;
                        characterController.MoveCharacter(this, 0, 1);
                        yTarget -= 32;
                        Turn = false;
                        //characterController.AllCharacters.Find(this).Next.Value.Turn = true;
                        characterController.Input = true;
                    }
                }
                if (keyboardState.IsKeyDown(Keys.Left))
                {
                    if (CheckTarget(-1, 0))
                    {
                        moving = true;
                        characterController.MoveCharacter(this, -1, 0);
                        xTarget -= 32;
                        Turn = false;
                        //characterController.AllCharacters.Find(this).Next.Value.Turn = true;
                        characterController.Input = true;
                    }
                }
                if (keyboardState.IsKeyDown(Keys.Right))
                {
                    if (CheckTarget(1, 0))
                    {
                        moving = true;
                        characterController.MoveCharacter(this, 1, 0);
                        xTarget += 32;
                        Turn = false;
                        //characterController.AllCharacters.Find(this).Next.Value.Turn = true;
                        characterController.Input = true;
                    }
                }
            }
        }

        public override void Death()
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(playerTexture, playerRectangle, null, Color.White);
        }

    }
}
