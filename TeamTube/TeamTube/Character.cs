using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTube
{
    abstract class Character : iDamageable, iMovable
    {
        int health;
        int damageTaken;
        bool turn;

        public bool Turn
        {
            get { return turn; }
            set { turn = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public int DamageTaken
        {
            get { return damageTaken; }
            set { damageTaken = value; }
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
        }

        public abstract void MakeDecision(KeyboardState keyboardState);
        public abstract void Update(KeyboardState keyboardState);
        public abstract void Death();
        public abstract bool CheckTarget(int x, int y);
    }
}
