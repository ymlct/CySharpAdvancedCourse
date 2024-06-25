using System.Xml.Serialization;

namespace L8Task1
{
    
    /*
    Задание 2 
    Создайте класс, поддерживающий сериализацию. Выполните сериализацию объекта этого 
    класса в формате XML. Сначала используйте формат по умолчанию, а затем измените его 
    таким образом, чтобы значения полей сохранились в виде атрибутов элементов XML. 
    */
    internal static class Program
    {
        public static void Main(string[] args)
        {
            
            XmlSerializer serializer = new XmlSerializer(typeof(SerializableClass));

            SerializableClass serializable = new SerializableClass
            {
                StringField = "Some string",
                DoubleField = 1.2,
                ListOfInts = new List<int> { 1, 2, 3 },
                CustomTypeField = new ChildSerializableClass
                {
                    BoolField = true
                }

            };

            using (var stream = new FileStream("/SerializableClass.xml", FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                serializer.Serialize(stream, serializable);
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