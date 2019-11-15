using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTube
{
    //abstract class character
    abstract class Character : iDamageable, iMovable
    {
        //fields for every character
        int health;
        int damageTaken;
        bool turn;

        //turn property
        public bool Turn
        {
            get { return turn; }
            set { turn = value; }
        }

        //health property
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        
        //damageTaken property
        public int DamageTaken
        {
            get { return damageTaken; }
            set { damageTaken = value; }
        }

        //take damage method
        public void TakeDamage(int damage)
        {
            health -= damage;
            damageTaken += damage;
            if(health <= 0)
            {
                Death();
            }
        }

        //abstract makeDecision method
        //should be implemented in each character for enemy ai decision making and player input
        public abstract void MakeDecision(KeyboardState keyboardState);

        //absract update method
        //should call makeDecision on the character's turn, and move the character apropriately
        public abstract void Update(KeyboardState keyboardState);

        //abstract death method
        //The death method should remove characters from the level if they have died, and handle player death
        public abstract void Death();

        //abstract checkTarget method
        //checkTarget method is for colissions and moving characters through the level. Should be called in MakeDecision to determine if a decision is 
        public abstract bool CheckTarget(int x, int y);
    }
}
