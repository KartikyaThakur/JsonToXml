using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
using JsonToXml.Utilities;

namespace JsonToXml
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2 || args[0] == "-help" || args[0] == "-h")
            {
                Console.WriteLine("\n\rUtility to convert JSON file to XML\n\rUsage:\n\r\tJsonToXml.exe <inputFilePath> <outputFilePath>");
                return;
            }
            if (!File.Exists(args[0]))
            {
                Console.WriteLine("\n\rInput file not found!");
                return;
            }
            string jsonData = File.ReadAllText(args[0]);
            XmlDocument doc = JsonConvert.DeserializeXmlNode(jsonData, "root");
            File.WriteAllText(args[1], doc.Stringify());
        }
    }
}
