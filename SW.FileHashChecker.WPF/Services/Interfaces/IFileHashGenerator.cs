using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.FileHashChecker.WPF.Host.Services.Interfaces
{
    public interface IFileHashGenerator
    {
        string Md5Hash { get; }
        string Sha1Hash { get; }
    }
}
