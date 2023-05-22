using System;

namespace FunkTask4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            bool isPlaying = true;
            int userPositionX = 1;
            int userPositionY = 1;
            int userDirectionX = 0;
            int userDirectionY = 0;
            char userOnMap = '@';
            char mapPiece = '#';
            char[,] map =
            {
               {'#','#','#','#','#','#','#','#','#','#','#','#'},
               {'#',' ',' ',' ',' ','#',' ','#',' ',' ',' ','#'},
               {'#','#','#','#',' ','#',' ',' ',' ','#','#','#'},
               {'#',' ',' ','#',' ','#',' ',' ',' ',' ',' ','#'},
               {'#',' ',' ',' ',' ','#',' ',' ',' ','#',' ','#'},
               {'#',' ','#','#',' ',' ',' ','#','#','#','#','#'},
               {'#',' ',' ','#',' ','#',' ',' ',' ','#',' ','#'},
               {'#','#',' ','#',' ','#',' ','#',' ',' ',' ','#'},
               {'#',' ',' ','#',' ',' ',' ','#',' ',' ',' ','#'},
               {'#','#','#','#','#','#','#','#','#','#','#','#'}
            };

            DrawMap(map);
            DrawUser(userPositionY, userPositionX, userOnMap);

            while (isPlaying) 
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                GetDirection(key, out userDirectionX, out userDirectionY);

                if (userDirectionX != 0 || userDirectionY != 0)
                {
                    if (map[userPositionX + userDirectionX, userPositionY + userDirectionY] != mapPiece)
                    {
                        MoveUser(ref userPositionX, ref userPositionY, userDirectionX, userDirectionY, userOnMap);
                    }
                }
            }
        }
        
        static void DrawMap(char[,] map) 
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }

                Console.WriteLine();
            }
        }
        
        static void DrawUser(int positionX, int positionY, char user) 
        {
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(user);
        }

        static void GetDirection(ConsoleKeyInfo key, out int directionX, out int directionY)
        {
            const ConsoleKey KeyMoveUp = ConsoleKey.UpArrow;
            const ConsoleKey KeyMoveDowm = ConsoleKey.DownArrow;
            const ConsoleKey KeyMoveLeft = ConsoleKey.LeftArrow;
            const ConsoleKey KeyMoveRight = ConsoleKey.RightArrow;

            directionX = 0;
            directionY = 0;

            switch (key.Key)
            {
                case KeyMoveUp:
                    directionX = -1;
                    break;

                case KeyMoveDowm:
                    directionX = 1;
                    break;

                case KeyMoveLeft:
                    directionY = -1;
                    break;

                case KeyMoveRight:
                    directionY = 1;
                    break;
            }
        }

        static void MoveUser(ref int positionX, ref int positionY, int directionX, int directionY, char user) 
        {
            CursorPosition(positionY, positionX, " ");

            positionX += directionX;
            positionY += directionY;

            CursorPosition(positionY, positionX, "@");
        }

        static void CursorPosition(int positionY, int positionX, string user) 
        {
            Console.SetCursorPosition(positionY, positionX);
            Console.Write(user);
        }
    }
}
