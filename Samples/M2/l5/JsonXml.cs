using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace L5;

// Json Serializer: https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/how-to?pivots=dotnet-7-0
// Newtonsoft: https://www.newtonsoft.com/json/help/html/SerializingJSON.htm
// Xml Serializer: https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/serialize-object-xml
public static class JsonXml
{
    public static void Execute()
    {
        var person = new Person()
        {
            Age = 10,
            FullName = "John X",
            Parents = new Person[]
            {
                new() { Age = 39, FullName = "Alice X" },
                new() {
                    Age = 41,
                    FullName = "Bob X",
                    Parents = new Person[] { new() { Age = 89, FullName = "Emily X" } }
                }
            }
        };

        var asJson = JsonSerializer.Serialize(person);
        Console.WriteLine(asJson + Environment.NewLine);

        var xmlSeializer = new XmlSerializer(person.GetType());
        string asXml;

        using var sww = new StringWriter();
        using var writer = new XmlTextWriter(sww) { Formatting = Formatting.Indented };

        xmlSeializer.Serialize(writer, person);
        asXml = sww.ToString();
        Console.WriteLine(asXml);
    }

    public class Person
    {
        public int Age { get; set; }
        public string FullName { get; set; } = string.Empty;
        public Person[]? Parents { get; set; }
    }
}
