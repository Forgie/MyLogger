using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyLogger
{
    /// <summary>
    /// A utility for logging messages to text files. 
    /// </summary>
    public class TextLogger : Logger
    {
        private string _path;

        /// <summary>
        /// Initializes a new instance of the MyLogger.TextLogger class setting the directory
        /// and file name along with creating the directory initializing the file for logging.
        /// </summary>
        /// <param name="directory">The directory where the log will be written to.</param>
        /// <exception cref="System.ArgumentException"/>
        /// <exception cref="System.ArgumentNullException"/>
        /// <exception cref="System.UnauthorizedAccessException"/>
        /// <exception cref="System.NotSupportedException"/>
        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="System.IO.PathTooLongException"/>
        /// <exception cref="System.IO.DirectoryNotFoundException"/>
        public TextLogger(string directory)
        {
            string fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".log";

            _path = Path.Combine(directory, fileName);

            InitializeFile(directory);
        }

        /// <summary>
        /// Initializes a new instance of the MyLogger.TextLogger class setting the directory
        /// and file name along with creating the directory initializing the file for logging.
        /// </summary>
        /// <param name="directory">The directory where the log will be written to.</param>
        /// <param name="fileName">The name of the log file with or without an extension. If no extension is provided ".log" will be used. If null or empty a System.DateTime.Now.ToString("yyyy-MM-dd") will be used.</param>
        /// <exception cref="System.ArgumentException"/>
        /// <exception cref="System.ArgumentNullException"/>
        /// <exception cref="System.UnauthorizedAccessException"/>
        /// <exception cref="System.NotSupportedException"/>
        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="System.IO.PathTooLongException"/>
        /// <exception cref="System.IO.DirectoryNotFoundException"/>
        public TextLogger(string directory, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = DateTime.Now.ToString("yyyy-MM-dd");
            }

            _path = Path.Combine(directory, fileName);

            if (!Path.HasExtension(_path))
            {
                _path += ".log";
            }

            InitializeFile(directory);
        }

        private void InitializeFile(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
                File.Create(_path).Close();
            }
            else if (!File.Exists(_path))
            {
                File.Create(_path).Close();
            }
        }

        internal override void WriteMessage(LogTypeEnum type, string message)
        {
            using (StreamWriter sw = File.AppendText(_path))
            {
                sw.WriteLineAsync(string.Format("{0} {1} {2}", DateTime.Now.ToLongTimeString(), type.ToString(), message));
            }
        }
    }
}
