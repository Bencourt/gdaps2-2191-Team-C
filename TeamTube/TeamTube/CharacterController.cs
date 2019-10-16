using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTube
{
    class CharacterController
    {
        private Character[,] characters;
        private Point nullPoint = new Point(-1,-1);
        LinkedList<Character> allCharacters;

        public Character[,] Characters
        {
            get { return characters; }
            set { characters = value; }
        }

        public LinkedList<Character> AllCharacters
        {
            get { return allCharacters; }
            set { allCharacters = value; }
        }

        public CharacterController(int width, int height)
        {
            characters = new Character[width, height];
        }


        public void MoveCharacter(Character c, int xChange, int yChange)
        {
            Point p = FindCharacter(c);
            if(p != nullPoint)
            {
                characters[p.X + xChange, p.Y + yChange] = c;
                characters[p.X, p.Y] = null;
            }
        }

        public Point FindCharacter(Character c)
        {
            for(int x = 0; x < characters.GetLength(0); x++)
            {
                for(int y = 0; y < characters.GetLength(1); y++)
                {
                    if(characters[x,y] == c)
                    {
                        return new Point(x, y);
                    }
                }
            }
            return new Point(-1, -1);
        }

        public void Add(Character c, int x, int y)
        {
            characters[x, y] = c;
        }

        public void TakeTurns(KeyboardState keyboardState)
        {
            getCharacters();
            foreach (Character c in allCharacters)
            {
                if(c.Turn)
                {
                    c.MakeDecision(keyboardState);
                }
                c.Update(keyboardState);
            }
        }

        private LinkedList<Character> getCharacters()
        {
            allCharacters.Clear();
            foreach (Character c in characters)
            {
                allCharacters.AddLast(c);
            }
            return allCharacters;
        }




    }
}
