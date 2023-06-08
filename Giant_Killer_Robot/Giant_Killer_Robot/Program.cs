using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Giant_Killer_Robot
{
    internal class Program
    {
        static int CalculateDmg(int def, int dmg)
        {
            int result = dmg - def;
            if (result <= 0)
                return 1;
            return result;
        }
        static void Main(string[] args)
        {
            int roboHp;
            int roboDef;
            int roboDmg;
            int destination;
            
            Console.WriteLine(">Initializing...");
            HP:
            Console.Write(">Set robot's health: ");
            try 
            {
                roboHp = int.Parse(Console.ReadLine());
            }
            catch(Exception)
            {
                Console.WriteLine("Invalid value!");
                goto HP;
            }
            DEF:
            Console.Write(">Set robot's defense: ");
            try
            {
                roboDef = int.Parse(Console.ReadLine());
            }
            catch(Exception)
            {
                Console.WriteLine("Invalid value!");
                goto DEF;
            }
            DMG:
            Console.Write(">Set robot's damage: ");
            try
            {
                roboDmg = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid value!");
                goto DMG;
            }
            DEST:
            Console.Write(">Select destination (0 for Earth, 1 for Mars): ");
            try
            {
                destination = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid value!");
                goto DEST;
            }
            Planet planet = new Planet();
            if(destination==0)
            {
                planet.GenerateEarth();
                Console.WriteLine(">Deploying robot on Earth...");
                Thread.Sleep(2100);
            }
            else
            {
                planet.GenerateMars();
                Console.WriteLine("Deploying robot on Mars...");
                Thread.Sleep(2100);
            }
            bool ok = false;
            GiantKillerRobot robot = new GiantKillerRobot("Robot", roboHp, roboDef, roboDmg);
            robot.target = new Entity(" ", 0, 0, 0);
            while(robot.IsAlive()==true && planet.ContainsLife()==true)
            {
                if(robot.target.IsAlive()==true)
                {
                    robot.target.health -= CalculateDmg(robot.target.GetDef(), robot.GetDmg());
                    Console.WriteLine(">Robot fired laser at " + robot.target.ToString() + " (" + robot.target.health + ")");
                    Thread.Sleep(1300);
                    if(robot.target.IsAlive()==true)
                    {
                        robot.health -= CalculateDmg(robot.GetDef(), robot.target.GetDmg());
                        Console.WriteLine(">"+robot.target.ToString()+ " hit Robot (" + robot.health + ")");
                        Thread.Sleep(1300);
                    }
                }
                else
                {
                    if(ok==true)
                    {
                        Console.WriteLine(">" + robot.target.ToString() + " fainted.");
                        planet.Lifeforms.RemoveAt(0);
                    }
                    ok = true;
                    Thread.Sleep(1300);
                    Console.WriteLine(">Acquiring next target...");
                    if(planet.Lifeforms.Count>0)
                    {
                        robot.target = planet.Lifeforms[0];
                        Thread.Sleep(1200);
                        Console.WriteLine(">Target spotted: "+robot.target.ToString());
                    }
                    Thread.Sleep(1300);
                }
            }
            if(robot.IsAlive()==false)
            {
                Console.WriteLine(">Robot is no longer active...");
            }
            else
            {
                Console.WriteLine(">Robot successfully eradicated all life on the targeted planet!");
            }
            Console.Read();
        }
    }
}
