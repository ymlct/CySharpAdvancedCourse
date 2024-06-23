using System.Xml.Serialization;

namespace L8Task2
{
    
    /*
    Задание 3 
    Создайте новое приложение, в котором выполните десериализацию объекта из предыдущего 
    примера. Отобразите состояние объекта на экране. 
    */
    internal static class Program
    {
        public static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SerializableClass));

            using (FileStream source = new FileStream("/Lesson8/L8Task2/L8Task2/SerializableClass.xml", FileMode.Open, FileAccess.Read))
            {
                SerializableClass serializableClass = (SerializableClass )serializer.Deserialize(source);
                
            }
        }
    }
    
    [XmlRoot("CustomRootName")]     
    public class SerializableClass
    {

        // [XmlAttribute("StringFieldAsXmlAttribute")]
        public string StringField;
        
        
        public double DoubleField;
        
        
        public List<int> ListOfInts;
        
        
        public ChildSerializableClass CustomTypeField;

    }
    
    
    public class ChildSerializableClass
    {
        public bool BoolField;
    }
}