using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giant_Killer_Robot
{
    internal class Entity
    {
        protected string type { get; set; }
        public int health { get; set; }
        protected int defense { get; set; }
        protected int damage { get; set; }
        public Entity()
        {
            type = " ";
            health = 0;
            defense = 0;
            damage = 0;
        }
        public Entity(string type, int health, int defense, int damage)
        {
            this.type = type;
            this.health = health;
            this.defense = defense;
            this.damage = damage;
        }
        public int GetDef()
        {
            return this.defense;
        }
        public int GetDmg()
        {
            return this.damage;
        }
        public bool IsAlive()
        {
            if(health>0)
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return this.type;
        }
    }
}
