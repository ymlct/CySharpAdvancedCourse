namespace L7Task1
{
    
    /*
    Задание 2 
    Создайте класс и примените к его методам атрибут Obsolete сначала в форме просто 
    выводящей предупреждение, а затем в форме, препятствующей компиляции. 
    Продемонстрируйте работу атрибута на примере вызова данных методов.
    */
    
    internal static class Program
    {
        public static void Main(string[] args)
        {

            ObsoleteClass oc = new ObsoleteClass();
            
            oc.ObsoleteMethod();
            // oc.ObsoleteMethodWithError();
            
        }
    }

    internal class ObsoleteClass
    {

        [Obsolete("Метод устарел")]
        internal void ObsoleteMethod()
        {
            Console.WriteLine("ObsoleteMethod body");
        }
        
        [Obsolete("Метод устарел. Компиляция невозможна.", error: true)]
        internal void ObsoleteMethodWithError()
        {
            Console.WriteLine("ObsoleteMethodWithError body");
        }

    }
}