using System;
using System.IO;
namespace SW.FileHashChecker.WPF.Host.Services.Interfaces
{
    public interface IFileSelector
    {
        IFileDialog FileDialog { get; }

        FileStream SelectedFile { get; }

    }
}
