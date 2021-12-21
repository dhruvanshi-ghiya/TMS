/********************************************//**
 *  Filename: BackupDatabasePopUp.xaml.cs
 *	Project: Software Quality Term Project - Team 10
 *  By: Travis Fiander, Patrick Cho, Dhruvanshi Ghiya
 *  Date: December 5
 *	Description: Contains the code behind logic for the pop-up used to back up the database
 ***********************************************/

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Configuration;

namespace Admin
{
    /// 
    /// \class BackupDatabasePopUp
    ///
    /// \brief This class is responsible for the code behind of the Backup Database pop up window.
    ///        It collects a directory path from the user, validates it, and then creates the backup.
    ///
    public partial class BackupDatabasePopUp : Window
    {
        ///
        /// \brief This method initializes the components of the windows
        ///
        /// \return Nothing is returned
        ///
        public BackupDatabasePopUp()
        {
            InitializeComponent();
        }

        ///
        /// \brief This is the Cancel button event handler - it simply closes the pop-up
        /// 
        /// \param object sender, RoutedEventArgs e
        ///
        /// \return Nothing is returned
        ///
        private void CancelBackup_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        ///
        /// \brief Reference: https://code.4noobz.net/c-copy-a-folder-its-content-and-the-subfolders/ - This is the Ok button click event handler.
        ///        It checks the validity of the entered filepath and then creates the backup at the specified location
        ///
        /// \param object sender, RoutedEventArgs e
        /// 
        /// \return Nothing is returned
        ///
        private void OkBackup_Click(object sender, RoutedEventArgs e)
        {
            string sourceDirectory = ConfigurationManager.AppSettings["dbDirectory"]; ; //change to db directory
            string targetDirectory = DatabaseBackupDirectoryTextBox.Text;

            if (!Directory.Exists(targetDirectory))
            {
                MessageBox.Show("The directory you have entered does not exist.");
                return;
            }

            Copy(sourceDirectory, targetDirectory);
        }

        ///
        /// \brief Reference: https://code.4noobz.net/c-copy-a-folder-its-content-and-the-subfolders/ - This is the copy function from the reference.
        ///        It converts the directory strings to DirectoryInfo objects, and passes it on
        ///
        /// \param string sourceDirectory
        /// \param string targetDirectory
        /// 
        /// \return Nothing is returned
        ///
        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            var diSource = new DirectoryInfo(sourceDirectory);
            var diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        ///
        /// \brief Reference: https://code.4noobz.net/c-copy-a-folder-its-content-and-the-subfolders/ - This is the copy all function from the reference.
        ///        This one puts the files in the directory, and also copies each subdirectory recursively
        /// \param DirectoryInfo source
        /// \param DirectoryInfo target
        /// 
        /// \return Nothing is returned
        ///
        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(System.IO.Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
    }
}
