using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTube
{
    //charcter controller class
    class CharacterController
    {
        //fields for characters
        //2d array of characters keeps track of every character and their position relative to the level
        private Character[,] characters;
        //null point is a reference point to test methods
        private Point nullPoint = new Point(-1,-1);
        //allCharacters list is a list of the characters currently in the level
        List<Character> allCharacters= new List<Character>();
        //input determines if the player has put in input
        private bool input;

        //input property
        public bool Input
        {
            get { return input; }
            set { input = value; }
        }

        //characters array property
        public Character[,] Characters
        {
            get { return characters; }
            set { characters = value; }
        }

        //Allcharacers list property
        public List<Character> AllCharacters
        {
            get { return getCharacters(); }
            set { allCharacters = value; }
        }

        //characterController constructor takes in the level width and height in tiles, and sets the character array to be that size
        public CharacterController(int width, int height)
        {
            characters = new Character[width, height];
        }

        //MoveCharacter method takes a character, an x change int and a y change int
        public void MoveCharacter(Character c, int xChange, int yChange)
        {
            //gets the index of the character in the array
            Point p = FindCharacter(c);
            //if the point is not the null point (the character exists on the level)
            if(p != nullPoint)
            {
                //change the new index in the array is set to the character
                characters[p.X + xChange, p.Y + yChange] = c;
                //the old point is set to null
                characters[p.X, p.Y] = null;
            }
        }

        //find character method takes a character to find
        public Point FindCharacter(Character c)
        {
            //iterating through the x values of the character array
            for(int x = 0; x < characters.GetLength(0); x++)
            {
                //iterating through the y values of the character array
                for(int y = 0; y < characters.GetLength(1); y++)
                {
                    //if the character is at the point in the array
                    if(characters[x,y] == c)
                    {
                        //return the index of the point as a new Point
                        return new Point(x, y);
                    }
                }
            }
            //if the character is not in the array, return the NullPoint
            return new Point(-1, -1);
        }

        //Add Character method takes a character, an x position and a y position
        public void Add(Character c, int x, int y)
        {
            //add the character at the x and y index
            characters[x, y] = c;
        }

        public void Remove(Character c)
        {
            Point myIndex = FindCharacter(c);
            Characters[myIndex.X, myIndex.Y] = null;
        }

        /*
         * 
         * The take turns method was supposed to control which character should be making decisions and looping through the characters 
         * 
         * 
        public void TakeTurns(KeyboardState keyboardState)
        {
            getCharacters();
            if (allCharacters != null)
            {
                foreach (Character c in allCharacters)
                {
                    if (c.Turn)
                    {
                        c.MakeDecision(keyboardState);
                    }
                    c.Update(keyboardState);
                }
            }
        }
        */


        //getCharacters method 
        private List<Character> getCharacters()
        {
            //clear the current allCharacters list
            if(allCharacters != null)
                allCharacters.Clear();
            //loop through the 2d array
            foreach (Character c in characters)
            {
                //add the character to the list
                allCharacters.Add(c);
            }
            //return the list
            return allCharacters;
        }
    }
}
