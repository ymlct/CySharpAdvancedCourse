using System;

namespace L2Task3
{
    /*
    Задание 4
    Создайте коллекцию типа OrderedDictionary и реализуйте в ней возможность сравнения значений. 
     */
    internal class Program
    {
        public static void Main(string[] args)
        {
            MyDict<DictKey, DictValue> dict = new MyDict<DictKey, DictValue>();
            
            Console.WriteLine(dict.Count);

            var k1 = new DictKey("a");
            var k2 = new DictKey("b");
            var k31 = new DictKey("x");
            var k32 = new DictKey("y");
            var k33 = new DictKey("z");
            
            var v1 = new DictValue("A");
            var v2 = new DictValue("B");
            var v31 = new DictValue("X");
            var v32 = new DictValue("Y");
            var v33 = new DictValue("Z");
            
            dict.Add(k1, v1);
            dict.Add(k2, v2);
            dict.Add(k31, v31);
            dict.Add(k32, v32);
            dict.Add(k33, v33);
            
            var elementA = dict[k1];
            var elementB = dict[k2];
            var elementX = dict[k31];
            var elementY = dict[k32];
            var elementZ = dict[k33];
            
            Console.WriteLine(elementA.Name);
            Console.WriteLine(elementB.Name);
            Console.WriteLine(elementX.Name);
            Console.WriteLine(elementY.Name);
            Console.WriteLine(elementZ.Name);
            
            Console.WriteLine(dict.Count);

        }
    }
    
    // ключ элемента словаря 
    internal class DictKey
    {
        public string Val { get; }

        public DictKey(string val)
        {
            Val = val;
        }
    }
    
    // элемент словаря
    internal class DictValue
    {
        public string Name { get; }

        public DictValue(string name)
        {
            Name = name;
        }
    }
}