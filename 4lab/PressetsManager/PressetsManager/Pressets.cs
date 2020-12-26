using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;

namespace PressetsManager
{
    public class Pressets
    {
        [JsonPropertyName("Source_Directory")]
        public string sourceDir { get; set; } = @"C:\Users\User\source\repos\C#\2 kurs\2\SourceDir";
        [JsonPropertyName("Target_Directory")]
        public string targetDir { get; set; } = @"C:\Users\User\source\repos\C#\2 kurs\2\TargetDir";
        [JsonPropertyName("Dearchive_Directory")]
        public string DearchiveDir { get; set; } = @"C:\Users\User\source\repos\C#\2 kurs\2\TargetDir\Dearchive";
        [JsonPropertyName("Connect")]
        public string Connection { get; set; } = "Data Source=DESKTOP-GE7ID1L;Initial Catalog=AdventureWorks;Integrated Security=True";
        public Pressets() { }
    }
    public class SettingsParser
    {
        public Pressets SettingsXML()
        {
            Pressets parsed = new Pressets();
            if (File.Exists(@"C:\\Users\\User\\source\\repos\\C#\\2 kurs\\3\\3\\LABA3\\conf.xml"))
            {
                XmlDocument xml = new XmlDocument();
                xml.Load("conf.xml");
                foreach (XmlNode n in xml.SelectNodes("Settings"))
                {
                    string Sdir = n.SelectSingleNode("sourceDir").InnerText;
                    string Tdir = n.SelectSingleNode("targetDir").InnerText;
                    string Ddir = n.SelectSingleNode("DearchivetDir").InnerText;
                    string Con = n.SelectSingleNode("Connection").InnerText;
                    parsed.sourceDir = Sdir;
                    parsed.targetDir = Tdir;
                    parsed.DearchiveDir = Ddir;
                    parsed.Connection = Con;
                }
            }
            return parsed;

        }
        public Pressets SettingsJson()
        {
            Pressets parsed = new Pressets();
            if (File.Exists("Setting.json"))
            {
                parsed = JsonConvert.DeserializeObject<Pressets>(File.ReadAllText(@"C:\\Users\\User\\source\\repos\\C#\\2 kurs\\3\\3\\LABA3\\pressets.json"));
            }
            return parsed;
        }
    }
}