using System;
using System.IO;
using System.Security.Cryptography;

namespace SW.FileHashChecker.WPF.Host {
    public class ShellViewModel : IShell
    {

        public ShellViewModel()
        {
            //string hash = Md5HashModel.getMd5Hash(source);
           // HashDirectory();
        }

        public Microsoft.Win32.OpenFileDialog GetOpenFileDialog()
        {
            return new Microsoft.Win32.OpenFileDialog();
        }

        private void HashDirectory() //String[] args
        {

                // Show open file dialog box
//                Nullable<bool> result = dlg.ShowDialog();

        }

        // Print the byte array in a readable format. 
        public static void PrintByteArray(byte[] array)
        {
            int i;
            for (i = 0; i < array.Length; i++)
            {
                Console.Write(String.Format("{0:X2}", array[i]));
                if ((i % 4) == 3) Console.Write(" ");
            }
            Console.WriteLine();
        }

        private string _md5;
        public string Md5
        {
            get { return _md5; }
            
        }

        public FileStream GetSelectedFile(string fh)
        {
            throw new NotImplementedException();
        }
    }
}