using Microsoft.Win32;
using SW.FileHashChecker.WPF.Host.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.FileHashChecker.WPF.Host.Services.Filesystem
{
    /// <summary>
    /// Provides File Selection Services.
    /// Note: Is threadsafe singleton.
    /// ref: http://msdn.microsoft.com/en-us/library/ff650316.aspx
    /// </summary>
    public class FileSelector : IFileSelector
    {
        private IFileDialog _fileDialog;

        private static volatile FileSelector _instance;
        private static object syncRoot = new Object();
                
        private FileSelector()
        {
            // TODO: IoC constructor injection, check on intented use in Caliburn.Micro though as was only designed to be used in framework
            // code, not application code.
            _fileDialog = new FileDialog();
            _fileDialog.FileSelected += OnFileSelected;            
        }
        
        public static FileSelector Instance 
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_instance == null)
                            _instance = new FileSelector();
                    }
                }
                
                return _instance;
            }
        }

        /// <summary>
        /// When user selects a file create a filestream object as required for hash generation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFileSelected(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                // Create a fileStream for the file.
                SelectedFile = new FileStream(((OpenFileDialog)sender).FileName, FileMode.Open, FileAccess.Read);  //fInfo.Open(FileMode.Open);
                // Be sure it's positioned to the beginning of the stream. 
                SelectedFile.Position = 0;
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Error: The directory specified could not be found.");
            }
            catch (IOException)
            {
                Console.WriteLine("Error: A file in the directory could not be accessed.");
            }
        }

        public FileStream SelectedFile { get; private set; }

        public IFileDialog FileDialog
        {
            get { return _fileDialog; }
            set { _fileDialog = value; }
        }
    }
}
