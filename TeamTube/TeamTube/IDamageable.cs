using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTube
{
    interface IDamageable
    {
        int health { get; set; }
        int damageTaken { get; set; }
        void TakeDamage();
        void Death();

    }
}
