﻿using System;
using System.Threading.Tasks;

namespace ClassAid_Raw_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 20; i++)Console.WriteLine(GetCode());
        }
        public static string GetCode()
        {
            Random random = new Random();
            string res = "";
            for (int i = 0; i < 6; i++)
            {
                res += (char)random.Next(65, 91);
            }
            return res;
        }
    }
}
//Hello World