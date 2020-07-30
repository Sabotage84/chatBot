using System;

namespace ChatBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Bot jarvis = new Bot();
            jarvis.Name = "Jarvis";
            jarvis.Greetings();
        }
    }
}
