using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTube
{
    class Player : Character, iMovable
    {

        public Player(CharacterController characterController, int health)
        {
            this.Health = health;
        }

        public override void GetAdjacent(TileType[] tiles, int[] characters)
        {

        }

        public override void Death()
        {

        }

    }
}
