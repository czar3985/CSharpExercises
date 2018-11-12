using System;

namespace CSharpExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordCounter = new WordCounter();

            wordCounter.ParseText(args[0]);

            wordCounter.PrintSorted();
        }
    }
}