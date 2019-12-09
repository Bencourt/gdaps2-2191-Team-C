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
        //player rectangle and texture
        Texture2D playerTexture;
        Rectangle playerRectangle;
        //is the player moving
        bool moving;
        public bool dead = false;
        //the room position to move to
        int xTarget;
        int yTarget;
        //character controller
        CharacterController characterController;
        //tile controller
        TileController tiles;
        //the speed at which the character moves
        int speed = 2;
        //items 
        List<Item> itemsHeld;
        //attack damage;
        int weakAttack = 1;

        //player rectangle property
        public Rectangle PlayerRectangle
        {
            get { return playerRectangle; }
        }

        public List<Item> ItemsHeld
        {
            get { return itemsHeld; }
            set { itemsHeld = value; }
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
            //instantiate the list if items
            itemsHeld = new List<Item>();
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
                        //valid move space
                        return true;
                    else
                        //invalid move space
                        return false;
                }
                else
                {
                    //valid move space
                    return true;
                }
            }
            else
            {
                //invalid moves space
                return false;
            }
        }

        //update method
        public void Update(KeyboardState keyboardState, KeyboardState previousKbState)
        {
            //make decision regarding movement
            characterController.TakeTurns();
            MakeDecision(keyboardState, previousKbState);
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

        bool SingleKeyPress(KeyboardState current, KeyboardState previous, Keys key)
        {
            //return true if key is currently down and previously was up
            if (current.IsKeyDown(key) && previous.IsKeyUp(key))
            {
                return true;
            }
            else //it isn't being pressed just now
            {
                return false;
            }
        }

        public void MakeDecision(KeyboardState keyboardState, KeyboardState previousKbState)
        {
            //if the player isn't moving
            if (!moving)
            {
                if (characterController.Input == false)
                {
                    if (SingleKeyPress(keyboardState, previousKbState, Keys.L))
                    {
                        characterController.Input = true;
                        foreach (Character c in characterController.AllCharacters)
                        {
                            Point enemyPosition = characterController.FindCharacter(c);
                            Point playerPosition = characterController.FindCharacter(this);

                            if (((enemyPosition.X - playerPosition.X <= 1) && (enemyPosition.X - playerPosition.X >= -1)) && ((enemyPosition.Y - playerPosition.Y <= 1) && (enemyPosition.Y - playerPosition.Y >= -1)))
                            {
                                if(c != this)
                                c.TakeDamage(3);
                            }
                        }
                    }
                }
                if(characterController.Input == false)
                {
                    int inputY = 0;
                    int inputX = 0;

                    if (keyboardState.IsKeyDown(Keys.Up))
                    {
                        inputY = -1;
                    }
                    else if (keyboardState.IsKeyDown(Keys.Down))
                    {
                        inputY = 1;
                    }
                    else
                    {
                        inputY = 0;
                    }
                    if (keyboardState.IsKeyDown(Keys.Left))
                    {
                        inputX = -1;
                    }
                    else if (keyboardState.IsKeyDown(Keys.Right))
                    {
                        inputX = 1;
                    }
                    else
                    {
                        inputX = 0;
                    }

                    if (CheckTarget(inputX, inputY))
                    {
                        moving = true;
                        characterController.MoveCharacter(this, inputX, inputY);
                        xTarget = 32 * inputX;
                        yTarget = 32 * -inputY;
                        Turn = false;
                        characterController.Input = true;
                    }
                }
            }
        }

        public override void Death()
        {
            dead = true;
        }

        public void Draw(SpriteBatch sb)
        {
            if(Health > 0)
            sb.Draw(playerTexture, playerRectangle, null, Color.White);
        }

        public override void MakeDecision(KeyboardState keyboardState)
        {
            throw new NotImplementedException();
        }

        public override void Update(KeyboardState keyboardState)
        {
            throw new NotImplementedException();
        }
    }
}
