using System;
namespace SW.FileHashChecker.WPF.Host.Services.Interfaces
{
    public interface IFileSelector
    {
        Microsoft.Win32.OpenFileDialog OpenFileDialog { get; set; }
        System.IO.FileStream SelectedFile { get; }
    }
}
