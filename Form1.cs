using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace laba2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string targetDir = @"C:\Users\User\source\repos\C#\2 kurs\2\TargetDir";
        string _file;
        private void FSW_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            TB1.Text += "Added new file " + e.Name + "\r\n";
            string encoded = EncodeTo64(e.FullPath,targetDir);
            _file = Path.GetFileNameWithoutExtension(e.FullPath);
            string newfile = targetDir + $@"\{_file}.gz";
            Compress(encoded, newfile);
            File.Delete(encoded);
            _file = Path.GetFileNameWithoutExtension(newfile);
            string decomprFile = targetDir + $@"\Dearchive\{_file}.txt";
            Decompress(newfile, decomprFile);
            DecodeFrom64(decomprFile);
            File.Delete(decomprFile);

        }

        private void FSW_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            TB1.Text += "Deleted file " + e.Name + "\r\n";
        }

        private void FSW_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            TB1.Text += "old name:" + e.OldName + "\r\n to new:" + e.Name + "\r\n"; 
        }
        public static void Compress(string sourceFile, string compressedFile)
        {
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.Open))
            {
                using (FileStream targetStream = File.Create(compressedFile))
                {
                    using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        sourceStream.CopyTo(compressionStream);
                    }
                }
            }
        }

        public static void Decompress(string compressedFile, string targetFile)
        {
            using (FileStream sourceStream = new FileStream(compressedFile, FileMode.Open))
            {
                using (FileStream targetStream = File.Create(targetFile))
                {
                    using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetStream);
                    }
                }
            }
        }

        private void FSW_Changed(object sender, FileSystemEventArgs e)
        {
            TB1.Text += "file changed " + e.Name + "\r\n";
            string encoded = EncodeTo64(e.FullPath, targetDir);
            _file = Path.GetFileNameWithoutExtension(e.FullPath);
            string newfile = targetDir + $@"\{_file}.gz";
            Compress(encoded, newfile);
            File.Delete(encoded);
            _file = Path.GetFileNameWithoutExtension(newfile);
            string decomprFile = targetDir + $@"\Dearchive\{_file}.txt";
            Decompress(newfile, decomprFile);
            DecodeFrom64(decomprFile);
            File.Delete(decomprFile);
        }
        //ENCODER
        static public string EncodeTo64(string path, string targetDir)
        {
            string txt; 
            using (StreamReader sr = new StreamReader(path))
            {
                   txt=sr.ReadToEnd();
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
