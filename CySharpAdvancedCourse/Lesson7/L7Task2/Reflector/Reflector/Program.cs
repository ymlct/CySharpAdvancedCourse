using System;
using System.Windows.Forms;

namespace Reflector
{
    /*
    Расширьте возможности программы-рефлектора из предыдущего урока следующим образом: 
    1. Добавьте возможность выбирать, какие именно члены типа должны быть показаны 
       пользователю. При этом должна быть возможность выбирать сразу несколько членов 
       типа, например, методы и свойства. 
    2. Добавьте возможность вывода информации об атрибутах для типов и всех членов типа, 
       которые могут быть декорированы атрибутами.
     */
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}