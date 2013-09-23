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
        private OpenFileDialog _openFileDialog;

        private static volatile FileSelector _instance;
        private static object syncRoot = new Object();
                
        private FileSelector()
        {
            InitOpenFileDialog();
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

        protected void InitOpenFileDialog()
        {

            _openFileDialog = new OpenFileDialog();
            _openFileDialog.Filter = "All files (*.*)|*.*"; // Filter files by extension.
            _openFileDialog.FileOk += OnFileSelected;

        }

        private void OnFileSelected(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Create a fileStream for the file.
            SelectedFile = new FileStream(((OpenFileDialog)sender).FileName, FileMode.Open, FileAccess.Read);  //fInfo.Open(FileMode.Open);
            // Be sure it's positioned to the beginning of the stream. 
            SelectedFile.Position = 0;
        }

        public FileStream SelectedFile { get; private set; }

        public OpenFileDialog OpenFileDialog
        {
            get { return _openFileDialog; }
            set { _openFileDialog = value; }
        }
    }
}
