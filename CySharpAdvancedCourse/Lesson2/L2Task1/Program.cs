using System;
using System.Collections.Generic;

namespace L2Task1
{
    /*
    Задание 2
    Создайте коллекцию, в которую можно добавлять покупателей и категорию приобретенной ими
    продукции. Из коллекции можно получать категории товаров, которые купил покупатель или по
    категории определить покупателей. 
     */
    internal class Program
    {
        public static void Main(string[] args)
        {

            PurchaseCategoriesByCustomer items = new PurchaseCategoriesByCustomer();

            Customer customer1 = new Customer("customer1");
            Customer customer2 = new Customer("customer2");
            Customer customer3 = new Customer("customer3");

            items.Add(customer1, PurchaseCategory.One);
            items.Add(customer2, PurchaseCategory.Two);
            items.Add(customer3, PurchaseCategory.Three);

            Console.WriteLine($"{items.GetCategory(customer1)}");
            Console.WriteLine($"{items.GetCategory(customer2)}");
            Console.WriteLine($"{items.GetCategory(customer3)}");
        }

        internal class PurchaseCategoriesByCustomer
        {
            private Dictionary<int, Element> _items = new Dictionary<int, Element>();

            public void Add(Customer customer, PurchaseCategory category)
            {
                var key = customer.GetHashCode();
                if (!_items.ContainsKey(key))
                {
                    _items.Add(customer.GetHashCode(), new Element(customer, category));
                }
                else
                {
                    throw new Exception("Элемент уже присутствует в коллекции.");
                }
            }
            
            public PurchaseCategory GetCategory(Customer customer)
            {
                if (_items.TryGetValue(customer.GetHashCode(), out Element element))
                {
                    return element.Category;
                }
                throw new Exception("Элемент не найден в коллекции.");
            }
            
            private class Element
            {
                public readonly Customer Customer;
                public readonly PurchaseCategory Category;
                
                public Element(Customer customer, PurchaseCategory category)
                {
                    Customer = customer;
                    Category = category;
                }
            }
        }

        internal class Customer
        {
            public string Name;

            public Customer(string name)
            {
                Name = name;
            }
        }
        
        internal enum PurchaseCategory
        {
            One,
            Two,
            Three
        }
    }
}