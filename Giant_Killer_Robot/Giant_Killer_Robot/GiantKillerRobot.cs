using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giant_Killer_Robot
{
    internal class GiantKillerRobot : Entity
    {
        public Entity target;
        
        public GiantKillerRobot(string typus, int health, int defense, int damage)
        {
            this.type = typus;
            this.health = health;
            this.defense = defense;
            this.damage = damage;
        }
    }
}
