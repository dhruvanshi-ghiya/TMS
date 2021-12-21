/********************************************//**
 *  Filename: Logger.cs
 *	Project: Software Quality Term Project - Team 10
 *  By: Travis Fiander, Patrick Cho, Dhruvanshi Ghiya
 *  Date: November 27, 2021
 *	Description: Contains the class and method definitions for the Logger class
 ***********************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TMS.Communications
{
    /// 
    /// \class Logger
    ///
    /// \brief The Logger class is responsible for making entries into the main logfiles of the system. It's public methods make it 
    ///        simple to interface with from other classes and log infomation from anywhere in the application.
    ///
    public class Logger
    {
        private string LogPath1 = "./exampleLog1.txt";
        private string LogPath2 = "./exampleLog2.txt";
        private string LogPath3 = "./exampleLog3.txt";

        ///
        /// \brief This method allows logs to be made to a specified log file. 
        ///
        /// \param the logfile that you want to log to
        /// \param the log message you want to log
        ///
        /// \test Test without existing log file
        /// \test Test with existing log file
        /// \test Test with empty string
        /// \test Test with invalid file path 
        /// 
        /// \return Nothing is returned
        ///
        public void Log(string logFile, string logMessage)
        {
            //We don't want to log a nonexistent message
            if (logMessage == null)
            {
                return;
            }

            //Add the current server data and time to the log message
            logMessage = DateTime.Now.ToString() + " " + logMessage;

            //Check if the log file exists. If it doesn't, create a new log file
            if (!File.Exists(logFile))
            {
                File.Create(logFile);
            }

            //Append log file
            StreamWriter writer = File.AppendText(logFile);

            //Write the log message to the log file
            writer.WriteLine(logMessage);

            //Close
            writer.Close();
        }
    }
}
