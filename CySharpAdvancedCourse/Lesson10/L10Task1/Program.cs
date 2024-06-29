namespace L10Task1
{
    
    /*
    Напишите небольшую программу на языке C#, представляющую собой абстрактную 
    реализацию шаблона Template method (Шаблонный метод). 
    */
    internal static class Program
    {
        public static void Main(string[] args)
        {
            TemplateMethodDerived clazz = new TemplateMethodDerived();
            
            clazz.MainAction();
        }
    }
    
    internal class TemplateMethodBase
    {

        internal void MainAction()
        {
            InitialAction();
            SubAction1();
            SubAction2();
            SubAction3();
            FinalAction();
        }
        
        protected virtual void SubAction1()
        {
            Console.WriteLine("Base::SubAction1");
        }
        
        protected virtual void SubAction2()
        {
            Console.WriteLine("Base::SubAction2");
        }
        
        protected virtual void SubAction3()
        {
            Console.WriteLine("Base::SubAction3");
        }
        
        // метод добавился в новой версии класса
        private void InitialAction()
        {
            Console.WriteLine("Base::InitialAction");
        }
        
        // метод добавился в новой версии класса
        private void FinalAction()
        {
            Console.WriteLine("Base::FinalAction");
        }
    }

    internal class TemplateMethodDerived : TemplateMethodBase
    {

        protected override void SubAction1()
        {
            Console.WriteLine("Derived::SubAction1");
        }
        
        protected override void SubAction2()
        {
            Console.WriteLine("Derived::SubAction2");
        }
        
        protected override void SubAction3()
        {
            Console.WriteLine("Derived::SubAction3");
        }


    }
}