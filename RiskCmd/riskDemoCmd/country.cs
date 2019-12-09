using System;
using System.Collections.Generic;
using System.Text;

namespace riskdemo
{
    class country
    {
       public  player owner;
        public int troops;
        public country()
        {
            owner = null;
           troops = 0;
        }

        public void losecountry(player newone,int sol)
        {
            this.owner = newone;
            this.troops = sol;
            
        }
        public void attack(country enemy)
        {
           int x = -1;
            while(x<0||x>=this.troops)
            {
            Console.WriteLine("enter number of troops to fight from 1 to {0}",this.troops-1);
             x= int.Parse(Console.ReadLine());
            }
            Random rnd = new Random();
            for(int i=0;i<x&&enemy.troops>0&&this.troops>=2;i++)
            {
                int a, b;
               a= rnd.Next(1,6);
                b = rnd.Next(1, 6);
                Console.WriteLine("a: {0} , b {1} ",a,b);
                if (a > b)
                {
                    enemy.troops--;
                }
                else this.troops--;
            }
            if(enemy.troops==0)
            {

                Console.WriteLine("player {0} has take country from player {1}", this.owner.id, enemy.owner.id);
                int f;
                do {
                    Console.WriteLine("how many toops you want to transport");
                    f = int.Parse(Console.ReadLine());
                } while (f > this.troops || this.troops - f < 1);
                enemy.owner.countries--;
                enemy.losecountry(this.owner, f);
                this.troops -= f;
                this.owner.countries++;
            }
        }
    }
}
