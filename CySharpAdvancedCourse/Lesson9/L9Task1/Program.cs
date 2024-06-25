namespace L9Task1
{
    
    /*
    Задание 2 
    Создайте класс, который позволит выполнять мониторинг ресурсов, используемых программой. 
    Используйте его в целях наблюдения за работой программы, а именно: пользователь может 
    указать приемлемые уровни потребления ресурсов (памяти), а методы класса позволят выдать 
    предупреждение, когда количество реально используемых ресурсов приблизится к 
    максимально допустимому уровню. 
    */
    internal static class Program
    {
        public static void Main(string[] args)
        {

            MemoryMonitor memoryMonitor = new MemoryMonitor(100_000);

            new Timer(memoryMonitor.MonitorMemoryUsage, null, 0, 200);
            
            LargeObject[] array = new LargeObject[1000];

            for (int i = 0; i < array.Length; i++)
            {
                new LargeObject().Method(i);
            }

            Console.ReadKey();
        }
    }
    
    class MemoryMonitor
    {
        readonly int MemoryLimit;

        public MemoryMonitor(int memoryLimit)
        {
            MemoryLimit = memoryLimit;
        }
        
        public void MonitorMemoryUsage(object? o)
        {
            if (HasMemoryLimitExceeded())
            {
                Console.WriteLine("Уровень потребляемой памяти выше заданного!");
            }
        }
        
        private bool HasMemoryLimitExceeded()
        {
            var memoryUsed = GC.GetTotalMemory(false);
            return MemoryLimit < memoryUsed;
        }

    }
    
    class LargeObject
    {
        int[] array = new int[100_000]; 

        public void Method(int i)
        {
            Console.WriteLine(i);
        }
    }

}