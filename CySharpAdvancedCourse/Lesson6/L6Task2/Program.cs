using System;
using System.IO;
using System.Reflection;
using L6Task1;

namespace L6Task2
{
    
    /*
    Задание 3 
    Создайте программу, в которой предоставьте пользователю доступ к сборке из Задания 2. 
    Реализуйте использование метода конвертации значения температуры из шкалы Цельсия в 
    шкалу Фаренгейта. Выполняя задание используйте только рефлексию.
    */
    internal class Program
    {
        public static void Main(string[] args)
        {
            Assembly assembly = null;

            try
            {
                assembly = Assembly.Load("L6Task1");
                
                Type type = assembly.GetType("L6Task1.TemperatureConverter");

                TemperatureConverter converter = (TemperatureConverter) Activator.CreateInstance(type);
                
                var methods = type.GetMethods();
                
                foreach (var methodInfo in methods)
                {
                    
                    if (methodInfo.Name == "Equals" || 
                        methodInfo.Name == "GetHashCode" || 
                        methodInfo.Name == "GetType" || 
                        methodInfo.Name == "ToString") continue;
                    
                    object[] parameters = { 30f };
                    
                    var result = methodInfo.Invoke(converter, parameters);
                    
                    Console.WriteLine($"Метод: {methodInfo.Name}, параметр: {parameters[0]}, результат: {result}"); 
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}