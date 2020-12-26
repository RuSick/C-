using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PressetsManager;

namespace LABA3
{
    public partial class Service1 : ServiceBase
    {
        Logger logger;
        public Service1()
        {
            InitializeComponent();
        }
        public void OnDebug() 
        {
            OnStart(null);
        }
        class Logger
        {
            Pressets Presset;
            SettingsParser Parser = new SettingsParser();
            FileSystemWatcher Watcher;
            private string _file;
            private bool _enabled = true;
            public Logger()
            {
                
                if (File.Exists(@"C:\Users\User\source\repos\C#\2 kurs\3\3\LABA3\conf.xml"))
                {
                    Presset = Parser.SettingsXML();
                }
                else if (File.Exists(@"C:\Users\User\source\repos\C#\2 kurs\3\3\LABA3\pressets.json"))
                {
                    Presset = Parser.SettingsJson();
                }
                
                else LogTxt("default config applied \n\r");
                Watcher = new FileSystemWatcher(Presset.sourceDir);
                Watcher.IncludeSubdirectories = true;
                Watcher.EnableRaisingEvents = true;
                Watcher.Created += FSW_Created;
                Watcher.Deleted += FSW_Deleted;
                Watcher.Renamed += FSW_Renamed;
                Watcher.Changed += FSW_Changed;
            }
            private void FSW_Deleted(object sender, System.IO.FileSystemEventArgs e)
            {
                Logger.LogTxt( "Deleted file " + e.Name + "\r\n");
            }

            private void FSW_Renamed(object sender, System.IO.RenamedEventArgs e)
            {
                Logger.LogTxt("old name:" + e.OldName + "\r\n to new:" + e.Name + "\r\n");
            }
            private void FSW_Created(object sender, System.IO.FileSystemEventArgs e)
            {
                Logger.LogTxt("Added new file " + e.Name + "\r\n");
                string encoded = Encrypttt.EncodeTo64(e.FullPath, Presset.targetDir);
                _file = Path.GetFileNameWithoutExtension(e.FullPath);
                string newfile = Presset.targetDir + $@"\{_file}.gz";
                Compressing.Compress(encoded, newfile);
                File.Delete(encoded);
                _file = Path.GetFileNameWithoutExtension(newfile);
                string decomprFile = Presset.DearchiveDir + $@"\{_file}.txt";
                Compressing.Decompress(newfile, decomprFile);
                Encrypttt.DecodeFrom64(decomprFile);
                File.Delete(decomprFile);

            }
            private void FSW_Changed(object sender, FileSystemEventArgs e)
            {
                Logger.LogTxt ("file changed " + e.Name + "\r\n");
                string encoded = Encrypttt.EncodeTo64(e.FullPath, Presset.targetDir);
                _file = Path.GetFileNameWithoutExtension(e.FullPath);
                string newfile = Presset.targetDir + $@"\{_file}.gz";
                Compressing.Compress(encoded, newfile);
                File.Delete(encoded);
                _file = Path.GetFileNameWithoutExtension(newfile);
                string decomprFile = Presset.DearchiveDir + $@"\{_file}.txt";
                Compressing.Decompress(newfile, decomprFile);
                Encrypttt.DecodeFrom64(decomprFile);
                File.Delete(decomprFile);
            }

            public void Start()
            {
                Watcher.EnableRaisingEvents = true;
                while (_enabled)
                {
                    Thread.Sleep(1000);
                }
            }
            public void Stop()
            {
                Watcher.EnableRaisingEvents = false;
                _enabled = false;
            }
            public static void LogTxt(string Log)
            {
                    using (StreamWriter writer = new StreamWriter((@"D:\templog.txt"), true))
                    {
                        writer.WriteLine(Log);
                        writer.Flush();
                    }   
            }

        }
        
        protected override void OnStart(string[] args)
        {
            logger = new Logger();
            Thread loggerThread = new Thread(new ThreadStart(logger.Start));
            loggerThread.Start();
        }

        protected override void OnStop()
        {
            logger.Stop();
            Thread.Sleep(1000);

        }

    }
}
