using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace L3Task2
{
    /*
    Задание 3
    Напишите приложение для поиска заданного файла на диске. Добавьте код, использующий
    класс FileStream и позволяющий просматривать файл в текстовом окне. В заключение
    добавьте возможность сжатия найденного файла.
     */
    internal class Program
    {
        public static void Main(string[] args)
        {
            DirectoryInfo root = new DirectoryInfo(@"C:\Users\Ярослав\RiderProjects\CySharpAdvancedCourse\CySharpAdvancedCourse\Lesson3\L3Task2\test_directory");
            
            Search(
                "test_3",
                root,
                out List<FileInfo> filesFound
            );

            if (filesFound.Count > 0)
            {
                var file = filesFound[0];
                
                ReadFileContent(
                    file,
                    (fileContent) =>
                    {
                        Console.WriteLine(fileContent);
                    }
                );

                CompressAsync(file, $"{file.DirectoryName}/compressed.txt");

                Console.ReadKey();
            }
        }

        private static async void ReadFileContent(FileInfo file, Action<string> onReadingCompeted)
        {
            using (FileStream fstream = file.OpenRead())
            {
                byte[] buffer = new byte[fstream.Length];
                
                await fstream.ReadAsync(buffer, 0, buffer.Length);

                string textFromFile = Encoding.Default.GetString(buffer);

                onReadingCompeted(textFromFile);
            } 
        }

        private static void Search(string fileName, DirectoryInfo root, out List<FileInfo> filesFound)
        {
            filesFound = new List<FileInfo>();

            SearchRecursively(fileName, root, filesFound);

            return;

            void SearchRecursively(string fName, DirectoryInfo directory, ICollection<FileInfo> flsFound)
            {
                foreach (var file in directory.GetFiles())
                {
                    if (string.Equals(
                            fName, 
                            Path.GetFileNameWithoutExtension(file.Name), 
                            StringComparison.CurrentCultureIgnoreCase))
                    {
                        flsFound.Add(file);
                    }
                }

                foreach (var subdirectory in directory.GetDirectories())
                {
                    SearchRecursively(fName, subdirectory, flsFound);
                }
            }
        }
        
        private static async void CompressAsync(FileInfo sourceFile, string compressedFile)
        {
            FileStream sourceStream;
            FileStream targetStream;
            GZipStream compressionStream;

            sourceStream = sourceFile.OpenRead();
            targetStream = File.Create(compressedFile);

            compressionStream = new GZipStream(targetStream, CompressionMode.Compress);
            await sourceStream.CopyToAsync(compressionStream); 
           
            sourceStream.Close();
            targetStream.Close();
        }
    }
}