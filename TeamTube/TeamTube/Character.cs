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

        public abstract void Death();
        public abstract void GetAdjacent(TileType[] tiles, int[] characters);
    }
}
