﻿using System;
using ClassAidUniversal.Users;
using System.Linq;

namespace ClassAid_Raw_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Admin admin = new Admin("HeloSenorita", "xoxoIamAwesome");
            admin.Username = "HeloSenorita";
            admin.Password = "xoxoIamAwesome";
            Console.WriteLine(admin.Key);
            //Student s = new Student();
            //s.ID = "192311030";
            //s.Name = "Jack Sparrow";
            //List<Student> sl = new List<Student>();
            //sl.Add(s);
            //sl.Add(s);
            //sl.Add(s);
            //sl.Add(s);
            Console.WriteLine("Hello");
            //Yo Wassup
            //admin.UserBase = Newtonsoft.Json.JsonConvert.SerializeObject(sl);
            Console.WriteLine(admin.StudentList.Count());
            //admin.UserBase = Newtonsoft.Json.JsonConvert.SerializeObject(sl);
            Console.WriteLine(admin.StudentList.Count());
            //string res = RegisterAdmin.Register(admin);
            //Console.WriteLine(res);
        }
    }
}
//Hello World