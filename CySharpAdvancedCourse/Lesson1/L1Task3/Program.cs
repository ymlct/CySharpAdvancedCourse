using System;
using System.Collections;
using System.Collections.Generic;

namespace L1Task3
{
    /*
    Задание 4
    Создайте коллекцию, в которую можно записывать два значения одного слова, 
    по типу русско-английско-испанский словарь. 
    И в ней можно для русского слова найти либо только английское
    значение, либо только испанское и вывести его на экран.  
     */
    internal class Program
    {
        public static void Main(string[] args)
        {

            WordDict dict = new WordDict();
            
            dict.AddWords(
                russianWord: "улица",
                englishWord: "a street",
                spanishWord:  "la calle"
                );
            
            dict.AddWords(
                russianWord: "здание",
                englishWord: "a building",
                spanishWord:  "el edificio"
            );

            Console.WriteLine(dict.GetEnglishMeaning("здание"));
            Console.WriteLine(dict.GetSpanishMeaning("улица"));
            
            
            foreach (var o in dict)
            {
                Console.WriteLine(o);
            }

            Console.WriteLine("*");
            
            foreach (var o in dict)
            {
                Console.WriteLine(o);
            }
        }
    }

    internal class WordDict : IEnumerable
    {

        public int Count => _russianWords.Count;

        private readonly List<string> _russianWords = new List<string>();
        
        private readonly List<string> _englishWords = new List<string>();
        
        private readonly List<string> _spanishWords = new List<string>();

        public void AddWords(
            string russianWord,
            string englishWord,
            string spanishWord
            )
        {
            if (!_russianWords.Contains(russianWord))
            {
                _russianWords.Add(russianWord);
                _englishWords.Add(englishWord);
                _spanishWords.Add(spanishWord);
            }
        }
        
        public string GetEnglishMeaning(
            string russianWord
        )
        {
            var idx = _russianWords.IndexOf(russianWord);
            return _englishWords[idx];
        }
        
        public string GetSpanishMeaning(
            string russianWord
            )
        {
            var idx = _russianWords.IndexOf(russianWord);
            return _spanishWords[idx];
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new WordDictEnumerator(this);
        }

        private class WordDictEnumerator : IEnumerator
        {

            private int _count = -1;
            public object Current { get; private set; }

            private WordDict _dict;
                
            public WordDictEnumerator(WordDict dict)
            {
                _dict = dict;
            }

            bool IEnumerator.MoveNext()
            {
                _count++;

                if (_count < _dict.Count)
                {
                    Current = $"{_dict._russianWords[_count]} : {_dict._englishWords[_count]} : {_dict._spanishWords[_count]}"; 
                    return true;
                }
              
                return false;
            }
            
            void IEnumerator.Reset()
            {
                _count = -1;
            }
        }
    }
}