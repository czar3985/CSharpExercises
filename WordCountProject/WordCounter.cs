using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpExercises
{
    class WordCounter
    {
        private Dictionary<string, int> _dictWords;

        public WordCounter()
        {
            _dictWords = new Dictionary<string, int>();
        }

        public void ParseText(string filePath)
        {
            // TODO: Error checking
            string[] lines = System.IO.File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                var words = line.Split(new[] { ' ', '.', ',', '-' });
                foreach (var word in words)
                {
                    if (_dictWords.ContainsKey(word))
                    {
                        _dictWords[word]++;
                    }
                    else
                    {
                        _dictWords.Add(word, 1);
                    }
                }
            }
        }

        public void PrintSorted()
        {
            var list = _dictWords.OrderByDescending(x => x.Value).ToList();
            foreach (var item in list)
            {
                Console.WriteLine(item.Key + " " + item.Value.ToString());
            }
            Console.ReadLine();
        }

        public void PrintCount()
        {
            foreach (var item in _dictWords)
            {
                Console.WriteLine(item.Key + " " + item.Value.ToString());
            }
            Console.ReadLine();
        }
    }
}
