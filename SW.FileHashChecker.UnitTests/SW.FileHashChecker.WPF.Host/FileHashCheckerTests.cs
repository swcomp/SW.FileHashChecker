using NUnit.Framework;
using SW.FileHashChecker.WPF.Host;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        ShellViewModel _vm;

        [SetUp]
        public void Init()
        {
            _vm = new ShellViewModel();
        }

        [Test]
        public void then_a_valid_win32_file_dialog_should_be_opened()
        {
            var dlg = _vm.GetOpenFileDialog();

            Assert.That(dlg, Is.InstanceOf<Microsoft.Win32.OpenFileDialog>());

        }

        [Test]
        public void then_on_file_selection_a_valid_filestream_object_should_be_returned()
        {
            var dlg = _vm.GetOpenFileDialog();
            // Note: Here the file handle is returned to _vm from the dialog.
            // Mock the file handle here.
            string fh = "filePathHere";
            var fso = _vm.GetSelectedFile(fh);

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
        [Test]
        public void then_a_valid_md5_hash_should_be_returned()
        {

        }

        [Test]
        public void then_a_valid_sha1_hash_should_be_returned()
        {

        }

        [Test]
        public void then_the_generated_hashes_should_be_presented_to_the_user()
        {
            // Note: Check the ViewModel View bound properties.
        }

    }



    

}
