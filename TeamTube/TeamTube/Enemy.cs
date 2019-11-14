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
        Texture2D enemyTexture;
        Rectangle enemyRectangle;
        bool moving;
        int xTarget;
        int yTarget;
        Character player;
        CharacterController characterController;
        TileController tiles;
        int speed = 2;

        public Enemy(CharacterController characterController, TileController tiles, int health, Rectangle enemyRectangle, Texture2D enemyTexture, Character player)
        {
            xTarget = 0;
            yTarget = 0;
            this.Health = health;
            moving = false;
            this.characterController = characterController;
            this.tiles = tiles;
            this.enemyRectangle = enemyRectangle;
            this.enemyTexture = enemyTexture;
            this.player = player;
            characterController.Add(this, enemyRectangle.X / 32, enemyRectangle.Y / 32);
        }

        public override bool CheckTarget(int targetX, int targetY)
        {
            int x = characterController.FindCharacter(this).X;
            int y = characterController.FindCharacter(this).Y;

            if (tiles.levels[0][x + targetX, y + targetY] != TileType.Wall && characterController.Characters[x+targetX, y+targetY] == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Update(KeyboardState keyboardState)
        {
            if(characterController.Input == true)
            {
                MakeDecision(keyboardState);
                characterController.Input = false;
            }
            if (moving)
            {
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

                if (xTarget == 0 && yTarget == 0)
                {
                    moving = false;
                    characterController.Input = false;
                }
            }
        }

        public override void Death()
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(enemyTexture, enemyRectangle, null, Color.White);
        }

        public override void MakeDecision(KeyboardState keyboardState)
        {
            Point playerLocation = characterController.FindCharacter(player);
            Point selfLocation = characterController.FindCharacter(this);

            Point distance = playerLocation - selfLocation;

            if(distance.X < 4 || distance.Y < 4)
            {
                int xTarget = Math.Sign(playerLocation.X - selfLocation.X);
                int yTarget = Math.Sign(playerLocation.Y - selfLocation.Y);
                if (CheckTarget(xTarget, yTarget))
                {
                    moving = true;
                    characterController.MoveCharacter(this, 0, -1);
                    yTarget = 32 * yTarget;
                    xTarget = 32 * xTarget;
                    //characterController.AllCharacters.Find(this).Next.Value.Turn = true;
                    characterController.Input = true;
                }
            }
        }

    }
}
