using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Data_layer
{
    public class XMLGen
    {
        
            private readonly string path;

            public XMLGen(string path)
            {
                this.path = path;
            }

            public void XmlGen<T>(IEnumerable<T> humansinfo)
            {
                try
                {
                    List<T> emp = new List<T>(humansinfo);

                    XmlSerializer formatter = new XmlSerializer(typeof(List<T>));

                    using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, emp);
                    }
                }
                catch (Exception Error)
                {
                    throw Error;
                }
            }
    }
}
