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
        CharacterController characterController;
        TileController tiles;

        public Enemy(CharacterController characterController, TileController tiles, int health, Rectangle enemyRectangle, Texture2D enemyTexture)
        {
            xTarget = 0;
            yTarget = 0;
            this.Health = health;
            moving = false;
            this.characterController = characterController;
            this.tiles = tiles;
            this.enemyRectangle = enemyRectangle;
            this.enemyTexture = enemyTexture;
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
            throw new NotImplementedException();
        }

        public override void Death()
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(enemyTexture, enemyRectangle, null, Color.White);
        }

    }
}
