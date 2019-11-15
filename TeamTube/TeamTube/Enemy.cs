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
    class Enemy : Character
    {
        //enemy fields
        Texture2D enemyTexture;
        Rectangle enemyRectangle;
        //boolean to determine if the character is moving or not
        bool moving;
        //the intended position in the room to move to
        int xTarget;
        int yTarget;
        //a character reference to the player
        Character player;
        //the character controller
        CharacterController characterController;
        //the tile controller
        TileController tiles;
        //the speed at which the enemy moves
        int speed = 2;

        //Enemy constructor takes information for the enemy fields
        public Enemy(CharacterController characterController, TileController tiles, int health, Rectangle enemyRectangle, Texture2D enemyTexture, Character player)
        {
            //set all the enemy fields
            xTarget = 0;
            yTarget = 0;
            this.Health = health;
            moving = false;
            this.characterController = characterController;
            this.tiles = tiles;
            this.enemyRectangle = enemyRectangle;
            this.enemyTexture = enemyTexture;
            this.player = player;
            //add the enemy to the character controller at the enemy location
            characterController.Add(this, enemyRectangle.X / 32, enemyRectangle.Y / 32);
        }

        //check target method should control collisions
        public override bool CheckTarget(int targetX, int targetY)
        {
            //get the current x and y tile locations of the enemy
            int x = characterController.FindCharacter(this).X;
            int y = characterController.FindCharacter(this).Y;

            //if the target tile is not a wall nor is it occupied by a player
            if (tiles.levels[0][x + targetX, y + targetY] != TileType.Wall && characterController.Characters[x+targetX, y+targetY] == null)
            {
                //return true (valid tile to move to)
                return true;
            }
            else
            {
                //return false (invalid tile to move to, theres something there)
                return false;
            }
        }

        //update method 
        public override void Update(KeyboardState keyboardState)
        {
            //if the player has put in input
            if(characterController.Input == true)
            {
                //make the enemy's decision and give input control back to the player
                MakeDecision(keyboardState);
                characterController.Input = false;
            }

            //if the enemy is moving
            if (moving)
            {
                //move in the x direction if the enemy hasn't reached the target position
                if (xTarget > 0)
                {
                    enemyRectangle.X += speed;
                    xTarget -= speed;
                }
                else if (xTarget < 0)
                {
                    enemyRectangle.X -= speed;
                    xTarget += speed;
                }
                else
                {
                    //dont move
                }

                //move in the y direction if the enemy hasn't reached the target position
                if (yTarget > 0)
                {
                    enemyRectangle.Y -= speed;
                    yTarget -= speed;
                }
                else if (yTarget < 0)
                {
                    enemyRectangle.Y += speed;
                    yTarget += speed;
                }
                else
                {
                    //dont move
                }

                //if the target position is reached, set moving to false and make sure the character has input control
                if (xTarget == 0 && yTarget == 0)
                {
                    moving = false;
                    characterController.Input = false;
                }
            }
        }

        //death method
        public override void Death()
        {
            throw new NotImplementedException();
        }

        //draw method draws the enemy
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(enemyTexture, enemyRectangle, new Rectangle(0,0,32,32), Color.White);
        }

        //make decision method 
        public override void MakeDecision(KeyboardState keyboardState)
        {
            //get the room location of the player, and the room location of the enemy
            Point playerLocation = characterController.FindCharacter(player);
            Point selfLocation = characterController.FindCharacter(this);

            //get the distance between the player and the enemy
            Point distance = playerLocation - selfLocation;

            //if the player is within 4 spaces of the enemy
            if(distance.X < 4 || distance.Y < 4)
            {
                //get the target tile location as an x and y value set
                int targetX = Math.Sign(playerLocation.X - selfLocation.X);
                int targetY = Math.Sign(playerLocation.Y - selfLocation.Y);
                //if the target is a valid tile
                if (CheckTarget(targetX, targetY))
                {
                    //set moving to be true
                    moving = true;
                    //move the character in the character Controller
                    characterController.MoveCharacter(this, targetX, targetY);
                    //set the x and y move targets
                    yTarget = -32 * targetY;
                    xTarget = 32 * targetX;
                }
            }
        }

    }
}
