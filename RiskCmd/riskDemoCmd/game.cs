﻿using System;
using System.Collections.Generic;
using System.Text;

namespace riskdemo
{
    class game
    {
        //organize turns
        private  int turn;
        //graph of the game
        List<int>[] map = new List<int>[42];
        country[] countries = new country[42];
        player[] players = new player[3];
        player curplayer;
        public game()
        {

            turn = 0;
            curplayer = new player();
            fillmap();
            initplayers();
            initcountries();
            disturb();
            while(players[0].countries<42&&players[1].countries<42&&players[2].countries<42)
            {         
                curplayer = players[turn % 3];
                draft();
                attack();
                fortify();
                turn++;
            }
            
            

        }
        //fills the map logically
        private void fillmap()
        {
            // 1 ,2, 35     
            map[0] = new List<int>() { 1, 2, 35 };
            //0, 2 ,3 ,12           
            map[1] = new List<int>() { 0, 2, 3, 12 };
            //0 ,1, 3, 4          
            map[2] = new List<int>() { 0, 1, 3, 4};
            //1, 2 ,4 ,6 ,5 ,12
            map[3] = new List<int>() { 1, 2, 4, 6, 5, 12 };
            //2 ,3, 7, 6          
            map[4] = new List<int>() { 2, 3, 7, 6 };
            //6 ,3, 12          
            map[5] = new List<int>() { 6, 3, 12 };
            //5 ,3, 4, 7           
            map[6] = new List<int>() { 5, 3, 4, 7 };
            //4 ,6, 8          
            map[7] = new List<int>() { 4, 6, 8 };
            //7 ,9, 10           
            map[8] = new List<int>() { 7, 9, 10 };
            //8 ,10, 11           
            map[9] = new List<int>() { 8, 10, 11 };
            //8, 9 ,11, 22           
            map[10] = new List<int>() { 8, 9, 11, 22 };
            //9, 10
            map[11] = new List<int>() { 9, 10 };
            //1 ,3 ,5, 13
            map[12] = new List<int>() { 1, 3, 5, 13 };
            //12,14,15
            map[13] = new List<int>() { 12, 14, 15 };
            //13,15,16,17
            map[14] = new List<int>() { 13, 15, 16, 17 };
            //13,16,18,14
            map[15] = new List<int>() { 13, 16, 18,14 };
            //14,15,17,18,19
            map[16] = new List<int>() { 14, 15, 17, 18, 19 };
            //14,16,19,22
            map[17] = new List<int>() { 14, 16, 19, 22 };
            //15,16,19,20,28,27
            map[18] = new List<int>() { 15, 16, 19, 20, 28, 27 };
            //16,17,18,20,21
            map[19] = new List<int>() { 16, 17, 18, 20, 21 };
            //18,19,21,23,28,29
            map[20] = new List<int>() { 18, 19, 21, 23, 28, 29 };
            //19,20,23,22
            map[21] = new List<int>() { 19, 20, 23, 22 };
            //17,10,21,23,24
            map[22] = new List<int>() { 17, 10, 21, 23, 24 };
            //21,22,24,25,26,20
            map[23] = new List<int>() { 21, 22, 24, 25, 26, 20 };
            //22,23,25
            map[24] = new List<int>() { 22, 23, 25 };
            //23,24,26
            map[25] = new List<int>() { 23, 24, 26 };
            //23,25
            map[26] = new List<int>() { 23, 25 };
            //18,28,30,31
            map[27] = new List<int>() { 18, 28, 30, 31 };
            //18,27,30,20,29
            map[28] = new List<int>() { 18, 27, 30, 20, 29 };
            //20,28,30,37
            map[29] = new List<int>() { 20, 28, 30, 37 };
            //27,28,29,34,37,31
            map[30] = new List<int>() { 27, 28, 29, 34, 37,31 };
            //27,30,34,33,32
            map[31] = new List<int>() { 27, 30, 34, 33, 32 };
            //31,33,35
            map[32] = new List<int>() { 31, 33, 35 };
            //31,32,35,34
            map[33] = new List<int>() { 31, 32, 35, 34 };
            //31,33,36,30,35
            map[34] = new List<int>() { 31, 33, 36, 30,35 };
            //32,33,36,0,34
            map[35] = new List<int>() { 32, 33, 36, 0,34 };
            //35,34
            map[36] = new List<int>() { 35, 34 };
            //29,30,38
            map[37] = new List<int>() { 29, 30, 38 };
            //37,39,40
            map[38] = new List<int>() { 37, 39, 40 };
            //38,40,41
            map[39] = new List<int>() { 38, 40, 41 };
            //41,38,39
            map[40] = new List<int>() { 41, 38, 39 };
            //40,39
            map[41] = new List<int>() { 40, 39 };




        }
        //check if the map costructed correctly
        private void checkmap()
        {
            for(int i=0;i<42;i++)
            {
                for(int ii=0;ii<map[i].Count;ii++)
                {
                    bool found = false ;
                    for(int iii=0;iii<map[map[i][ii]].Count;iii++)
                    {
                        if(map[map[i][ii]][iii]==i)
                        {
                            found = true;
                        }
                    }
                    if(found==false)
                    {
                        Console.WriteLine("{0},{1}", i, map[i][ii]);
                    }
                }
            }
        }
        private void initplayers()
        {
           for(int i=0;i<3;i++)
            {
                players[i] = new player();
                players[i].id = i;
            }
            
        }
        private void initcountries()
        {
            for(int i=0;i<42;i++)
            {
                countries[i] = new country();
            }
        }
        //this function disturb 35 troops on random 14 country fo each player 
        private void disturb()
        {
            Random rnd = new Random();
            bool[] arr = new bool[42];
            List<int>[] arr2 = new List<int>[3];
            for(int i=0;i<3;i++)
            {
                arr2[i] = new List<int>();
            }
            for(int i=0;i<2;i++ )
            {
                while(players[i].countries<14)
                {
                    int f = rnd.Next(0, 41);
                   // Console.WriteLine(f);
                    if(arr[f]==false )
                    {
                        arr[f] = true;
                        countries[f].owner = players[i];
                        countries[f].troops++;
                        players[i].countries++;
                        players[i].notusedtroops--;
                     
                        arr2[i].Add(f);
                    }
                    
                }
            }
            
            for(int i=0;i<42;i++)
            {
                if(arr[i]==false )
                {
                    arr[i] = true;
                    countries[i].owner = players[2];
                    countries[i].troops++;
                    players[2].countries++;
                    players[2].notusedtroops--;
                  
                    arr2[2].Add(i);
                }
            }

            for(int i=0;i<3;i++)
            {
                for(int ii=0;ii<arr2[i].Count;ii++)
                {
                    int f = rnd.Next(0, players[i].notusedtroops/3);
                    countries[arr2[i][ii]].troops += f;
                    players[i].notusedtroops -= f;
                    if (players[i].notusedtroops == 0) break;
                }
                if(players[i].notusedtroops>0)
                {
                    while(players[i].notusedtroops > 0)
                    {
                        int f = rnd.Next(0, 13);
                        countries[arr2[i][f]].troops += 1;
                        players[i].notusedtroops -= 1;
                    }
                }
            }


            //////////////////////
            ///
            /*for(int i=0;i<42;i++)
            {
                Console.WriteLine("{0} , {1} , {2}", i, countries[i].owner.id, countries[i].troops);
            }*////
        }
        private void play()
        {

        }
        private void draft()
        {
            Console.WriteLine("draft");
            int newtroops = (players[turn % 3].usedtroops) / 7;
            Console.WriteLine("player{0},has new{1}troops", turn % 3, newtroops);
            players[turn % 3].notusedtroops += newtroops;
            Console.WriteLine("all your cities:");
            search(1);
            Console.WriteLine(" ");
            while(players[turn%3].notusedtroops>0)
            {
            Console.WriteLine("enter city and num of troops ");
                int a, b;
                string c;
               a = int.Parse(Console.ReadLine());
               b = int.Parse(Console.ReadLine());
                if ( b <= players[turn % 3].notusedtroops&&countries[a].owner==players[turn%3])
                {
                   
                    players[turn % 3].notusedtroops -= b;
                    players[turn % 3].usedtroops += b;
                    countries[a].troops += b;
                }

            }
        }
          private void attack()
          {
            Console.WriteLine("attack");
            Console.WriteLine("your current cities :");
            search(1);
            Console.WriteLine(" ");
            int curcity;
            do
            {

                Console.WriteLine("enter your city:");
                curcity = int.Parse(Console.ReadLine());
            } while (countries[curcity].owner != curplayer || countries[curcity].troops <= 1);
            if(countries[curcity].owner==curplayer&&countries[curcity].troops>1)
            {
                Console.WriteLine("choose one of your enimies:");
                for(int i=0;i<map[curcity].Count;i++)
                {
                    if(countries[map[curcity][i]].owner!=curplayer)
                    {
                        Console.Write("{0} ",map[curcity][i]);

                    }
                }
                Console.WriteLine(" ");
                int a = int.Parse(Console.ReadLine());
                if(countries[a].owner!=curplayer)
                countries[curcity].attack(countries[a]);
            }

          }
        
        //searches for all countries 1 if you want friend one,0 if you want enimies
        private void search(int state)
        {
            bool []vis=new bool [42];
            for (int i = 0; i < 42; i++) vis[i] = false;
            dfs(0, vis, state);

        }
        private void dfs(int cur,bool []vis,int state)
        {
            if (vis[cur] == true) return;
            vis[cur] = true;
            if(state==1&&countries[cur].owner==players[turn%3])
            {
                Console.Write("{0} ", cur);
                //run any function 
            }
            else if(state==0&& countries[cur].owner != players[turn % 3])
            {
                Console.Write("{0} ", cur);
                //run any function
            }    
            for (int i=0;i<map[cur].Count;i++)
            {
                dfs(map[cur][i], vis, state);
            }
        }
        private void fortify()
        {
            Console.WriteLine("this is your countries:");
            search(1);
            Console.WriteLine("select one of them to fortify or -1 to exit");
            int a = int.Parse(Console.ReadLine());
            if (a == -1) return;
            else selectfrinds(a);
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("enter num of troops from 1 to {0}", countries[a].troops-1);
            int c = int.Parse(Console.ReadLine());
            countries[a].troops -= c;
            countries[b].troops += c;

        }
        private void selectfrinds(int cur)
        {
            bool[] vis = new bool[42];
            for (int i = 0; i < 42; i++) vis[i] = false;
            dfs2(cur, vis);
        }
        private void dfs2(int cur,bool []vis)
        {
            if (vis[cur] == true) return;
            vis[cur] = true;
            Console.Write("{0} ",cur);
            for(int i=0;i<map[cur].Count;i++)
            {
                if(countries[map[cur][i]].owner==curplayer)
                {
                    dfs2(map[cur][i], vis);
                }
            }
        }
        
    }
}
