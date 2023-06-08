using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Giant_Killer_Robot
{
    internal class Planet
    {
        public List<Entity> Lifeforms = new List<Entity>();
        public bool ContainsLife()
        {
            if (Lifeforms.Count != 0)
                return true;
            return false;
        }
        public void GenerateEarth()
        {
            Random rnd = new Random();
            int nrEntities = rnd.Next(9, 16);
            int randomvalue;
            for(int i=0; i<=nrEntities;i++)
            {
                randomvalue=rnd.Next(1, 11);
                if(randomvalue<=6)
                {
                    Lifeforms.Add(new Entity("Human", 28, 5, 20));
                }
                if(randomvalue>6 && randomvalue!=10)
                {
                    Lifeforms.Add(new Entity("Animal", 14, 2, 8));
                }
                if(randomvalue==10)
                {
                    Lifeforms.Add(new Entity("Super Hero", 90, 10, 42));
                }
            }
        }
        public void GenerateMars()
        {
            Random rnd = new Random();
            int nrEntities = rnd.Next(10, 19);
            int randomvalue;
            for (int i = 0; i <= nrEntities; i++)
            {
                randomvalue = rnd.Next(1, 11);
                if (randomvalue <= 6)
                {
                    Lifeforms.Add(new Entity("Martian", 30, 5, 25));
                }
                if (randomvalue > 6 && randomvalue != 10)
                {
                    Lifeforms.Add(new Entity("Alien Creature", 15, 5, 10));
                }
                if (randomvalue == 10)
                {
                    Lifeforms.Add(new Entity("Armored Martian", 80, 12, 35));
                }
            }
        }
    }
}
