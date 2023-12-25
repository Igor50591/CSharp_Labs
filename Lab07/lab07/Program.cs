using System.Reflection;
using System.Xml;
using AnimalClasses;
using AnimalClasses.classes;
using AnimalClasses.animal;
using AnimalClasses.enums;

public class Program
{
    public static void Main()
    {
        XmlDocument xmlDoc = new XmlDocument();

        XmlElement rootElement = xmlDoc.CreateElement("ClassDiagram");
        xmlDoc.AppendChild(rootElement);

        Assembly assembly = Assembly.Load("AnimalClasses");
        Type[] types = assembly.GetTypes();

        foreach (Type type in types)
        {
            string t;
            if (type.IsClass)
            {
                t = "Class";
            }
            else
            {
                t = "Enum";
            }

            if (type.Namespace.Contains("AnimalClasses"))
            {
                XmlElement element = xmlDoc.CreateElement(t);
                rootElement.AppendChild(element);

                element.SetAttribute("name", type.Name);

                CommentAttribute comment = (CommentAttribute)type.GetCustomAttribute(typeof(CommentAttribute));

                if (comment != null)
                {
                    XmlElement commentElement = xmlDoc.CreateElement("Comment");
                    commentElement.InnerText = comment.Comment;
                    element.AppendChild(commentElement);
                }

                object[] properties = type.GetProperties();

                foreach (var prop in properties)
                {
                    XmlElement propertyElement = xmlDoc.CreateElement("Property");
                    propertyElement.InnerText = prop.ToString();
                    element.AppendChild(propertyElement);
                }

                object[] methods = type.GetMethods(BindingFlags.DeclaredOnly);

                foreach (var method in methods)
                {
                    XmlElement methodElement = xmlDoc.CreateElement("Method");
                    methodElement.InnerText = method.ToString();
                    element.AppendChild(methodElement);
                }
            }

        }

        xmlDoc.Save("D:\\Study\\2 Course\\3 semestr\\C# 2023\\Code\\lab07\\ClassDiagram.xml");

    }
}