using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTube
{
    abstract class Character : iDamageable
    {
        int health;

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        
    }
}
