namespace L11Task1
{
    /*
    Задание 2 
    Создайте консольное приложение, которое в различных потоках сможет получить доступ к 2-м файлам. 
    Считайте из этих файлов содержимое и попытайтесь записать полученную информацию в третий файл. 
    Чтение/запись должны осуществляться одновременно в каждом из дочерних потоков. 
    Используйте блокировку потоков для того, чтобы добиться корректной записи в конечный файл.
    */
    internal static class Program
    {
        public static void Main(string[] args)
        {
            string filesDir = Directory.GetCurrentDirectory().Split(@"\bin")[0] + "\\files";
            Console.WriteLine("Путь до файлов: {0}", filesDir);

            FileReader fileReader1 = new FileReader($"{filesDir}\\source_1.txt");
            FileReader fileReader2 = new FileReader($"{filesDir}\\source_2.txt");
            
            FileWriter fileWriter = new FileWriter($"{filesDir}\\destination.txt");
            
            fileReader1.ReadFromFileInBackground(fileWriter.WriteToFileSynchronously);
            fileReader2.ReadFromFileInBackground(fileWriter.WriteToFileSynchronously);
        }
    }

    internal class FileReader
    {
        
        internal delegate void ProcessFileRead(byte[] fileContent);

        private readonly string _filePath;
        
        internal FileReader(string filePath)
        {
            _filePath = filePath;
        }

        
        internal void ReadFromFileInBackground(ProcessFileRead callback)
        {
            Thread thread = new Thread(CallbackWrapper);
            Console.WriteLine($"Читаю файл в потоке {thread.GetHashCode()}");
            thread.Start();
            
            return;

            void CallbackWrapper() => ReadFromFile(callback);
        }

        internal void ReadFromFile(ProcessFileRead callback)
        {
            FileInfo file = new FileInfo(_filePath);

            byte[] buffer;
                
            using (FileStream fileStream = file.OpenRead())
            {
                buffer = new byte[fileStream.Length];
                
                fileStream.Read(buffer, 0, buffer.Length);
            }

            callback.Invoke(buffer);
        }
    }
    
    internal class FileWriter
    {
        
        private static readonly object Block = new object();
        
        private readonly string _filePath;
        
        internal FileWriter(string filePath)
        {
            _filePath = filePath;
        }

        internal void WriteToFileSynchronously (byte[] fileNewContent)
        {
            lock (Block) // если закомментировать, то получим ошибку доступа к файлу
            {
                Console.WriteLine($"Записываю файл в потоке {Thread.CurrentThread.GetHashCode()}");

                FileInfo file = new FileInfo(_filePath);
                byte[] fileExistentContent;
                
                using (FileStream fileStream = file.OpenRead())
                {
                    fileExistentContent = new byte[fileStream.Length];
                
                    fileStream.Read(fileExistentContent, 0, fileExistentContent.Length);
                }
                
                using (FileStream fileStream = file.OpenWrite())
                {
                    byte[] fileMergedContent = fileExistentContent.Concat(fileNewContent).ToArray();
                    fileStream.Write(fileMergedContent, 0, fileMergedContent.Length);
                }
            }
        }
    }
}