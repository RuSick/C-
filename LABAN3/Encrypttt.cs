using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA3
{
    class Encrypttt
    {
        static public string EncodeTo64(string path, string targetDir)
        {
            string txt;
            using (StreamReader sr = new StreamReader(path))
            {
                txt = sr.ReadToEnd();
            }
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(txt);
            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            string newpath = targetDir + @"\temp\encoded.txt";
            using (FileStream fstream = new FileStream(newpath, FileMode.Create))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(returnValue);
                fstream.Write(array, 0, array.Length);
            }
            return newpath;

        }
        //DECODER
        static public void DecodeFrom64(string path)
        {
            string txt;
            using (StreamReader sr = new StreamReader(path))
            {
                txt = sr.ReadToEnd();

            }
            byte[] encodedDataAsBytes = System.Convert.FromBase64String(txt);
            string returnValue = System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
            string newpath = path + "_UNencoded.txt";
            using (FileStream fstream = new FileStream(newpath, FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(returnValue);
                fstream.Write(array, 0, array.Length);
            }

        }
    }
}
