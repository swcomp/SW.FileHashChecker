using Microsoft.Win32;
using SW.FileHashChecker.WPF.Host.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.FileHashChecker.WPF.Host.Services
{
    public class FileDialog : IFileDialog
    {
        OpenFileDialog _openFileDialog;
        
        public FileDialog()
        {
            InitFileDialog();
        }

        // Declare the event. 
        public event FileSelectedHandler FileSelected;

        // Wrap the event in a protected virtual method 
        // to enable derived classes to raise the event. 
        protected virtual void InvokeFileSelected(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Raise the event by using the () operator. 
            if (FileSelected != null)
                FileSelected(sender, e);
        }

        protected virtual void InitFileDialog()
        {
            _openFileDialog = new OpenFileDialog();
            _openFileDialog.Filter = "All files (*.*)|*.*"; // Filter files by extension.
            _openFileDialog.FileOk += InvokeFileSelected;
        }
        
    }
}
