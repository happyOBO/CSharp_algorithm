﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace CSharp
{



    class Program
    {


        static int Find()
        {


            return 0;
        }
        static void Main(string[] args)
        {

            int? number = null;
            number = 3;
            //int a = number; // 오류 발생
            //int a = number.Value;

            //number = null;
            //int a = number.Value; // 컴파일 후 오류 발생


            if(number != null)
            {
                int a = number.Value;
                Console.WriteLine(a);
            }

            if(number.HasValue)
            {
                int a = number.Value;
                Console.WriteLine(a);
            }



            int b = number ?? 0; // number이 만약에 null이라면 0으로 할당 받는다.
            int? id = monster?.Id; // 만약 monster가 null이 아니라면 Id 값을 할당 받고, null이라면 null을 할당 받는다.
        }
    }
}
