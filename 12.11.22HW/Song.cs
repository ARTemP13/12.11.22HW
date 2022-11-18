using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov26._11
{
    public class Song
    {
        protected string name;
        protected string autor;
        protected static Song prev;
        public Song(string name, string autor, Song prev = null)
        {
            this.name = name;
            this.autor = autor;
        }
        public Song()
        {
            name = "Неизвестно";
            autor = "Неизвестно";
            prev = null;
        }

        public void Info()
        {
            Console.WriteLine($"Название песни: {name}\nАвтор песни: {autor}\nЧто обьединяет с прошлой песней: {prev}");
        }

        public bool Equals(Song song1)
        {
            if (song1.name == name)
            {
                Console.WriteLine("Название песен совпадают");
                if (song1.name == name)
                {
                    Console.WriteLine("Авторы песен совпадают");
                    return true;
                }
                else
                {
                    Console.WriteLine("Авторы песен не совпадают");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Название песен не совпадают");
                if (song1.name == name)
                {
                    Console.WriteLine("Авторы песен совпадают");
                    return true;
                }
                else
                {
                    Console.WriteLine("Авторы песен не совпадают");
                    return false;
                }
            }


        }

    }
}
