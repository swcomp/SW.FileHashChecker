using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.FileHashChecker.WPF.Host.Services.Interfaces
{
    /// <summary>
    /// FileSelected Event delegate.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void FileSelectedHandler(object sender, System.ComponentModel.CancelEventArgs e);

    public interface IFileDialog
    {
        /// <summary>
        /// File selected event, fired when user selects a file.
        /// </summary>
        event FileSelectedHandler FileSelected;
    }
}
