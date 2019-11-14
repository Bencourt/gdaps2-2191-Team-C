using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTube
{
    //damageable interface
    interface iDamageable
    {
        //health property
        int Health { get; set; }
        //damage taken property
        int DamageTaken { get; set; }
        //take damage method
        void TakeDamage(int damage);
        //death method
        void Death();

    }
}
