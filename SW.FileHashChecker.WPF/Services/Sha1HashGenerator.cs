using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SW.FileHashChecker.WPF.Host.Services
{
    public class Sha1HashGenerator
    {
        public static string GetSha1Hash(FileStream fileStream)
        {
            SHA1 sha1Hasher = new SHA1CryptoServiceProvider();
            // This is one implementation of the abstract class SHA1.

            // Convert the input string to a byte array and compute the hash. 
            //byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            byte[] data = sha1Hasher.ComputeHash(fileStream);

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();

        }
    }
}
