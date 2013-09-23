using Caliburn.Micro;
using NUnit.Framework;
using SW.FileHashChecker.WPF.Host;
using SW.FileHashChecker.WPF.Host.Services;
using SW.FileHashChecker.WPF.Host.Services.Filesystem;
using SW.FileHashChecker.WPF.Host.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SW.FileHashChecker.UnitTests.SW.FileHashChecker.WPF.Host
{

    public class when_working_with_the_file_hash_checker : Specification
    {
    
    }

    /// <summary>
    /// SW_DU_FHC-7 The user must be able to generate hashes for a selected file
    ///     SW_DU_FHC-11 The user must be able to browse to and select a file
    /// </summary>
    public class and_browsing_to_select_a_file_to_check :
                when_working_with_the_file_hash_checker
    {
        IFileSelector _fileSelector;

        [SetUp]
        public void Init()
        {
            // NoteL IoC should not be necessary for unit testing
            // Ref: http://msdn.microsoft.com/en-us/magazine/cc163358.aspx

            _fileSelector = FileSelector.Instance; //IoC.Get<IFileSelector>();
        }

        [Test]
        public void then_a_valid_win32_file_dialog_should_be_opened()
        {
            var dlg = _fileSelector.FileDialog;

            Assert.That(dlg, Is.InstanceOf<Microsoft.Win32.OpenFileDialog>());

        }

        [Test]
        public void then_on_file_selection_a_valid_filestream_object_should_be_returned()
        {
            var dlg = _fileSelector.FileDialog;
            // dlg.ShowDialog(); // Need to mock FileDialog service.
            // Note: Here the file handle is returned to _vm from the dialog.
            // Mock the file handle here.
            string fh = "filePathHere";
            var fso = _fileSelector.SelectedFile;

            Assert.That(fso, Is.InstanceOf<FileStream>());
        }

    }

    /// <summary>
    /// SW_DU_FHC-7 The user must be able to generate hashes for a selected file
    ///     
    /// </summary>
    public class and_generating_hashes_for_the_selected_file :
                        when_working_with_the_file_hash_checker
    {
        IFileHashGenerator _fileHashGenerator;
        
        [SetUp]
        public void Init()
        {
            _fileHashGenerator = new FileHashGenerator();
        }
        
        [Test]
        public void then_a_valid_md5_hash_should_be_returned()
        {

            Assert.That(Regex.Match(_fileHashGenerator.Md5Hash, "[0-9a-f]{32}"), Is.True);
        }

        [Test]
        public void then_a_valid_sha1_hash_should_be_returned()
        {
            Assert.That(Regex.Match(_fileHashGenerator.Sha1Hash, "sha1regex exp here"), Is.True);
        }

        [Test]
        public void then_the_generated_hashes_should_be_presented_to_the_user()
        {
            // Note: Check the ViewModel View bound properties.
            // Check NotifyOfPropertyChanged fired - or Vm property values match fileHash Generator or View control values itself??? not poss for unit test.
            throw new NotImplementedException();
        }

    }



    

}
