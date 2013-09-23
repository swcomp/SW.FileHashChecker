using SW.FileHashChecker.WPF.Host.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.FileHashChecker.WPF.Host.Services
{
    public class FileHashGenerator : IFileHashGenerator
    {

        public FileHashGenerator()
        {

        }
        
        public void GenerateHashes(FileStream fileStream ){

            Md5Hash = Md5HashGenerator.GetMd5Hash(fileStream);
            Sha1Hash = Sha1HashGenerator.GetSha1Hash(fileStream);

            // Release filestream resources.
            fileStream.Close();
            fileStream = null;
        }

        public string Md5Hash { get; private set; }

        public string Sha1Hash { get; private set; }

    }
}
