﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp
{

    class Board
    {
        const char CIRCLE = '\u25cf';
        public TileType[,] _tile; // 2차원 배열
        public int _size;

        public enum TileType
        {
            Empty,
            Wall,

        }

        public void initialize(int size)
        {
            if (size % 2 == 0)
                return;
            _tile = new TileType[size, size];
            _size = size;

            
            GenerateBySideWinder();
        }

        void GenerateBySideWinder()
        {

            // 일단, 길을 다 막아버리는 작업
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        _tile[y, x] = TileType.Wall;
                    else
                        _tile[y, x] = TileType.Empty;

                }
            }

            // 
            // 초록색 점에 대해서 랜덤으로 우측 혹은 아래로 길을 뚫는 작업
            Random rand = new Random();
            for (int y = 0; y < _size; y++)
            {
                int count = 1;
                for (int x = 0; x < _size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;
                    if (y == _size - 2 && x == _size - 2)
                        continue;
                    if(y == _size - 2)
                    {
                        _tile[y, x + 1] = TileType.Empty;
                        continue;
                    }
                    if(x == _size -2)
                    {
                        _tile[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    if (rand.Next(0, 2) == 0) // 0 혹은 1 두개중 하나가 나온다. 1/2 확률 생성
                    {
                        _tile[y, x + 1] = TileType.Empty;
                        count++;
                    }
                    else
                    {
                        int randomindex = rand.Next(0, count);
                        _tile[y + 1, x - randomindex * 2] = TileType.Empty;
                        count = 1;
                    }
                }
            }
        }

        public void Render()
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    
                    Console.ForegroundColor = GetTileColor(_tile[y, x]); // 콘솔에 써지는 색상 변경
                    Console.Write(CIRCLE); // 동그라미 그리기
                }
                Console.WriteLine(); // 개행
            }
            Console.ForegroundColor = prevColor;
        }


        ConsoleColor GetTileColor(TileType type)
        {
            switch(type)
            {
                case TileType.Empty:
                    return ConsoleColor.Green;
                case TileType.Wall:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.Green;
            }
        }
    }
}
