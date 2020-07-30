using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBot
{
    class Bot
    {
        string name;

        public string Name { get => name; set => name = value; }
        public void Greetings()
        {
            Console.WriteLine("Hello, I'm " + Name);
        }
    }
}
