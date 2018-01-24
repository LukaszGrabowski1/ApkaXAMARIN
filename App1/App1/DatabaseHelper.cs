using App1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace App1
{
    public class DatabaseHelper
    {
       
        public static bool Insert<T>(ref T data)
        {

            using(var conn = new SQLite.SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "monument.db")))
            {
                conn.CreateTable<T>();
                
                if (conn.Insert(data) != 0)
                {
                    Console.WriteLine("Success");
                    return true;
                }
                    
            }
            Console.WriteLine("FAIL");
            return false;
        }

        public static List<Monument> GetAll()
        {
            List<Monument> monuments = new List<Monument>();
            using (var conn = new SQLite.SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "monument.db")))
            {
                monuments = conn.Table<Monument>().ToList();

            }
            return monuments;
        }

        public static bool Delete(Monument monument)
        {
            
            using (var conn = new SQLite.SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "monument.db")))
            {
                if (conn.Delete(monument) != 0)
                {
                    Console.WriteLine("Success");
                    return true;
                }

            }
            Console.WriteLine("FAIL");
            return false;
        }

        public static bool Update(Monument monument)
        {
            using (var conn = new SQLite.SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "monument.db")))
            {
                if (conn.Update(monument) != 0)
                {
                    Console.WriteLine("Success");
                    return true;
                }

            }
            Console.WriteLine("FAIL");
            return false;
        }
    }
}
