using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlipstreamEngine.PlayerContainer
{
    public  class Player
    {
        public float health { get { return health; } set { health = value; } }
        public float speed { get { return speed; } set { speed = value; } }

        public Player(float health = 0f, float speed = 0f)
        {
            this.health = health;
            this.speed = speed;
        }
    }
}
