using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger
{
    /// <summary>
    /// Base class for various MyLogger.Logger utilities.
    /// </summary>
    public abstract class Logger
    {
        /// <summary>
        /// Send an Information message and log the message.
        /// </summary>
        /// <param name="message">The message to be logged</param>
        public void Information (string message)
		{
            WriteMessage("Information", message);
		}

        /// <summary>
        /// Send a Warning message and log the message.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
		public void Warning (string message)
		{
			WriteMessage ("Warning", message);
		}

        /// <summary>
        /// Send a Error message and log the message.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
		public void Error (string message)
		{
			WriteMessage ("Error", message);
		}

        /// <summary>
        /// Send a DEBUG message and log the message.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
		public void Debug (string message)
		{
			WriteMessage ("DEBUG", message);
		}

        internal abstract void WriteMessage(string type, string message);
    }
}
