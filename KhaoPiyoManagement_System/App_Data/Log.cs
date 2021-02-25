using System;
using System.IO;
using System.Reflection;

namespace System
{
    /// <summary>
    /// Global static class for logging
    /// </summary>
    public static class Log
    {
        #region Member variables
        public static bool bEncryptLog;     // To encrypt logs or not
        public static string strLogPath;    // Log file path
        #endregion

        /// <summary>
        /// Static function to write log
        /// </summary>
        /// <param name="inText">String to log in the file</param>
        /// <param name="strKID">Kiosk ID of the machine from which message received</param>
        /// <param name="strMSN">Serial number of the machine from which message received</param>
        public static void Write(string inText, string strKioskIP)
        {
            try
            {

                string strPath = "";

                if (strKioskIP != "")
                    strPath = "C:\\KPMS- " + strKioskIP + "\\" + DateTime.Now.ToString("MMM yy");
                else
                    strPath = "C:\\KPMS- " + DateTime.Now.ToString("MMM yy");

                // Create directory if not exist
                if (!Directory.Exists(strPath))
                    Directory.CreateDirectory(strPath);

                if (!File.Exists(strPath + "\\KPMSLog_" + DateTime.Today.ToString("dd_MM_yyyy") + ".txt"))
                {
                        File.WriteAllText(strPath + "\\KPMSLog_" + DateTime.Today.ToString("dd_MM_yyyy") + ".txt",
                                      DateTime.Now.ToString("HH:mm:ss.fff") + "\t***** Service started V" + Assembly.GetExecutingAssembly().GetName().Version.ToString() + " *****\n");
                }

                // Create or map file objct with append mode
                StreamWriter swFile = new StreamWriter(strPath + "\\LipiRMSLog_" + DateTime.Today.ToString("dd_MM_yyyy") + ".txt", true);

                // If created or mapped
                if (swFile != null)
                {
                        swFile.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + "\t" + inText);

                    // Close the file
                    swFile.Close();
                }
            }
            catch
            { }
        }
    }
}