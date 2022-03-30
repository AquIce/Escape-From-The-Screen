using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace pARK
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo ck;

            bool gameOver = false;

            string gameOverStr = @"
███▀▀▀██ ███▀▀▀███ ███▀█▄█▀███ ██▀▀▀
██    ██ ██     ██ ██   █   ██ ██   
██   ▄▄▄ ██▄▄▄▄▄██ ██   ▀   ██ ██▀▀▀
██    ██ ██     ██ ██       ██ ██   
███▄▄▄██ ██     ██ ██       ██ ██▄▄▄
                                    
███▀▀▀███ ▀███  ██▀ ██▀▀▀ ██▀▀▀▀██▄ 
██     ██   ██  ██  ██    ██     ██ 
██     ██   ██  ██  ██▀▀▀ ██▄▄▄▄▄▀▀ 
██     ██   ██  █▀  ██    ██     ██ 
███▄▄▄███    ▀█▀    ██▄▄▄ ██     ██▄";

            int[] pos = new int[] { 12, 12 };

            char[] player = new char[] { '☺', '☻' };

            string[] dir = new string[] {
            "  ↑\n",
            "← ",
            "o ",
            "→\n",
            "  ↓"};

            char[] bat = new char[] { '↔', '▬' };

            char[] dead = new char[] { '░', ' ' };
            int[,] deadPositions = new int[,] { { 12, 16 }, { 13, 16 }, { 5, 17 }, { 5, 18 }, { 5, 19 }, { 5, 20 }, { 5, 21 } };

            char[] weapon = new char[] { '↑', '→', '↓', '←' };
            int[,] weaponPositions = new int[,] { { 5, 10}, { 5, 11 }, { 5, 12}, { 5, 13 }, { 9, 10 }, { 9, 11 }, { 1, 3 }, { 2, 3 }, { 3, 3 }, { 4, 3 } };

            char[,] level = new char[,] {
                {'▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒'},
                {'▒','▒','▒',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','▒','▒','▒','▒','▒','▒'},
                {'▒','▒','▒',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','▒','▒','▒','▒',' ','▒','▒','▒','▒','▒','▒'},
                {'▒','▒','▒',' ',' ',' ',' ',' ','▒','▒','▒','▒','▒','▒','▒',' ',' ',' ',' ','▒','▒','▒','▒','▒','▒'},
                {'▒','▒','▒',' ',' ',' ',' ','▒','▒','▒','▒','▒','▒','▒','▒',' ','▒','▒','▒','▒','▒','▒','▒','▒','▒'},
                {'▒','▒','▒','▒','▒',' ',' ','▒','▒','▒','▒','▒','▒','▒','▒',' ','▒','▒','▒','▒','▒','▒','▒','▒','▒'},
                {'▒','▒','▒','▒','▒','▒','▒','▒','▒',' ',' ',' ',' ',' ',' ',' ','▒',' ',' ',' ',' ',' ',' ','▒','▒'},
                {'▒','▒','▒',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','▒','▒'},
                {'▒','▒','▒',' ','▒','▒','▒','▒',' ',' ',' ',' ',' ',' ',' ',' ','▒',' ',' ',' ',' ',' ',' ','▒','▒'},
                {'▒','▒','▒',' ','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒',' ','▒','▒'},
                {'▒','▒','▒',' ','▒','▒','▒','▒','▒','▒','▒','▒',' ',' ',' ',' ',' ',' ',' ',' ','▒','▒',' ','▒','▒'},
                {'▒','▒','▒',' ','▒','▒','▒','▒','▒','▒','▒','▒',' ','▒','▒','▒','▒',' ',' ',' ','▒','▒',' ','▒','▒'},
                {'▒','▒','▒',' ','▒','▒','▒','▒','▒','▒','▒','▒',' ','▒','▒','▒','▒',' ',' ',' ','▒','▒',' ','▒','▒'},
                {'▒','▒','▒',' ','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒',' ',' ',' ',' ',' ',' ','▒','▒'},
                {'▒','▒','▒',' ',' ',' ',' ',' ',' ',' ','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒'},
                {'▒','▒','▒','▒',' ',' ',' ',' ',' ',' ','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒'},
                {'▒','▒','▒','▒',' ','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒',' ',' ',' ',' ','▒','▒','▒'},
                {'▒','▒','▒','▒',' ','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒',' ','▒','▒',' ','▒','▒','▒'},
                {'▒','▒','▒','▒',' ','▒','▒','▒','▒','▒','▒','▒',' ',' ',' ',' ',' ','▒',' ','▒','▒',' ','▒','▒','▒'},
                {'▒','▒','▒','▒',' ','▒','▒','▒','▒','▒','▒','▒',' ',' ',' ',' ',' ',' ',' ','▒','▒',' ','▒','▒','▒'},
                {'▒','▒','▒','▒',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','▒',' ',' ',' ','▒','▒',' ','▒','▒','▒'},
                {'▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒',' ',' ','▒','▒'},
                {'▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒',' ',' ','▒','▒'},
                {'▒','▒','▒','▒','▒','▒','▒','▒','▒',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','▒','▒'},
                {'▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒',} };

            int height = 20;
            Console.WindowHeight = height;
            int width = 50;
            Console.WindowWidth = width;

            string spaces = "";
            for (int i = 0; i< (width / 2 - 17); i++)
            {
                spaces += " ";
            }
            string center = "";
            for (int i = 0; i < ((height-5) / 2); i++)
            {
                center += "\n";
            }

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"{center}{spaces}");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(">→ ESCAPE ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("FROM ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("THE ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("SCREEN ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("(EFTS) ←<\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{spaces}          © by Lil_Tim");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n\n{spaces}      [PRESS ENTER TO PLAY]");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{spaces}            Good luck !");
            Console.CursorVisible = false;
            do
            {
                ck = Console.ReadKey(true);
            }
            while (ck.Key != ConsoleKey.Enter);

            height = 35;
            Console.WindowHeight = height;

            for (int i = 0; i<deadPositions.GetLength(0); i++)
            {
                level[deadPositions[i, 0], deadPositions[i, 1]] = dead[0];
            }

            for(int i = 0; i<weaponPositions.GetLength(0); i++)
            {
                int[] wpPos = new int[] { weaponPositions[i, 0], weaponPositions[i, 1] };
                for(int j = 0; j<level.GetLength(0); j++)
                {
                    for(int k=0;k<level.GetLength(1); k++)
                    {
                        level[j, k] = placeWeapons(level, wpPos, weapon)[j, k];
                    }
                }
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(dir[0]);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(dir[1]);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(dir[2]);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(dir[3]);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(dir[4]);

            int temp = 1;
            do
            {
                if (temp == 1)
                    temp = 0;
                else
                    temp = 1;

                level[pos[0], pos[1]] = player[temp];

                Clear();
                Console.ForegroundColor = ConsoleColor.Gray;
                for (int i = 0; i < level.GetLength(0); i++)
                {
                    for (int j = 0; j<level.GetLength(1); j++)
                    {
                        Console.Write(level[i, j]);
                    }
                    Console.WriteLine();
                }

                ck = Console.ReadKey(true);

                switch (ck.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:

                        do
                        {
                            if (level[pos[0]-1, pos[1]] == ' ')
                            {
                                level[pos[0], pos[1]] = ' ';
                                pos[0]--;
                            }
                            else if (level[pos[0]-1, pos[1]] == '░')
                            {
                                gameOver = true;
                                break;
                            }
                        }
                        while (level[pos[0]-1, pos[1]] != '▒');

                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:

                        do
                        {
                            if (level[pos[0]+1, pos[1]] == ' ')
                            {
                                level[pos[0], pos[1]] = ' ';
                                pos[0]++;
                            }
                            else if (level[pos[0]+1, pos[1]] == '░')
                            {
                                gameOver = true;
                                break;
                            }
                        }
                        while (level[pos[0]+1, pos[1]] != '▒');

                        break;
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:

                        do
                        {
                            if (level[pos[0], pos[1]-1] == ' ')
                            {
                                level[pos[0], pos[1]] = ' ';
                                pos[1]--;
                            }
                            else if (level[pos[0], pos[1]-1] == '░')
                            {
                                gameOver = true;
                                break;
                            }
                        }
                        while (level[pos[0], pos[1]-1] != '▒');

                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:

                        do
                        {
                            if (level[pos[0], pos[1]+1] == ' ')
                            {
                                level[pos[0], pos[1]] = ' ';
                                pos[1]++;
                            }
                            else if (level[pos[0], pos[1]+1] == '░')
                            {
                                gameOver = true;
                                break;
                            }
                        }
                        while (level[pos[0], pos[1]+1] != '▒');

                            break;
                }

                if (gameOver)
                {
                    Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    height = 13;
                    Console.WindowHeight = height;
                    width = 40;
                    Console.WindowWidth = width;
                    Console.WriteLine(gameOverStr);
                    do
                    {
                        ck = Console.ReadKey();
                    }
                    while (ck.Key != ConsoleKey.Escape);
                }
            }
            while (ck.Key != ConsoleKey.Escape);
        }
        public static char[,] placeWeapons(char[,] tab, int[] coords, char[] weapons)
        {
            if (tab[coords[0]-1, coords[1]]==' ')
            {
                tab[coords[0], coords[1]] = weapons[0];
            }
            else if (tab[coords[0], coords[1]+1]==' ')
            {
                tab[coords[0], coords[1]] = weapons[1];
            }
            else if (tab[coords[0]+1, coords[1]]==' ')
            {
                tab[coords[0], coords[1]] = weapons[2];
            }
            else if (tab[coords[0], coords[1]-1]==' ')
            {
                tab[coords[0], coords[1]] = weapons[3];
            }

            return tab;
        }

        public static void Clear()
        {
            Console.Clear();
        }
    }
}
