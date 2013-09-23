using System;
using System.IO;
using System.Security.Cryptography;
using SW.FileHashChecker.WPF.Host.Models;

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
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            //string directory = "";
            //if (args.Length < 1)
            //{
                //FolderBrowserDialog fbd = new FolderBrowserDialog();
                //DialogResult dr = fbd.ShowDialog();
                //if (dr == DialogResult.OK)
                //    directory = fbd.SelectedPath;
                //else
                //{
                //    Console.WriteLine("No directory selected.");
                //    return;
                //}

                // Configure open file dialog box
                //dlg = new Microsoft.Win32.OpenFileDialog();
                //dlg.FileName = "Document"; // Default file name
                //dlg.DefaultExt = ".txt"; // Default file extension
                dlg.Filter = "All files (*.*)|*.*"; // Filter files by extension 

                // Show open file dialog box
                Nullable<bool> result = dlg.ShowDialog();

                // Process open file dialog box results 
                if (result == true)
                {
                    // Open document 
                    //string filename = dlg.FileName;
                    //dlg.OpenFile()
                }

            //}
            //else
            //    directory = args[0];
            try
            {
                
                    // Create a fileStream for the file.
                    FileStream fileStream = new FileStream(dlg.FileName,FileMode.Open,FileAccess.Read);  //fInfo.Open(FileMode.Open);
                    // Be sure it's positioned to the beginning of the stream.
                    fileStream.Position = 0;
                    // Compute the hash of the fileStream.
                    //hashValue = myRIPEMD160.ComputeHash(fileStream);

                    string hash = Md5HashModel.getMd5Hash(fileStream);

                    // Write the name of the file to the Console.
                    Console.Write(dlg.FileName + ": " + hash);
                    // Write the hash value to the Console.
                    //PrintByteArray(hashValue);
                    // Close the file.
                    fileStream.Close();
                

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