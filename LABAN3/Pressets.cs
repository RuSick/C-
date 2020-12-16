using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace LABA3
{
    class Pressets
    {
        [JsonPropertyName("Source_Directory")]
        internal string sourceDir { get; set; } = @"C:\Users\User\source\repos\C#\2 kurs\2\SourceDir";
        [JsonPropertyName("Target_Directory")]
        internal string targetDir { get; set; } = @"C:\Users\User\source\repos\C#\2 kurs\2\TargetDir";
        [JsonPropertyName("Dearchive_Directory")]
        internal string DearchiveDir { get; set; } = @"C:\Users\User\source\repos\C#\2 kurs\2\TargetDir\Dearchive";
        public Pressets() { }
    }
    class SettingsParser
    {
        public Pressets SettingsXML()
        {
            Pressets parsed = new Pressets();
            if (File.Exists("conf.xml"))
            {
                XmlDocument xml = new XmlDocument();
                xml.Load("conf.xml");
                foreach (XmlNode n in xml.SelectNodes("Settings"))
                {
                    string Sdir = n.SelectSingleNode("sourceDir").InnerText;
                    string Tdir = n.SelectSingleNode("targetDir").InnerText;
                    string Ddir = n.SelectSingleNode("DearchivetDir").InnerText;
                    parsed.sourceDir = Sdir;
                    parsed.targetDir = Tdir;
                    parsed.DearchiveDir = Ddir;
                }
            }
            return parsed;

        }
        public Pressets SettingsJson()
        {
            Pressets parsed = new Pressets();
            if (File.Exists("Setting.json"))
            {
                parsed = JsonConvert.DeserializeObject<Pressets>(File.ReadAllText("pressets.json"));    
            }
            return parsed;
        }
    }
}
