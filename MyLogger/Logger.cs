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
        /// <param name="message">The message to be logged.</param>
        public void Information(string message)
        {
            WriteMessage(LogTypeEnum.Information, message);
        }

        /// <summary>
        /// Send a Warning message and log the message.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        public void Warning(string message)
        {
            //WriteMessage (LoggerTypeEnum.Warning, message);
            Warning(message, null);
        }

        /// <summary>
        /// Send a Warning message and a System.Exception to be logged.
        /// The following System.Exception properties will be added to the message: Message
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        /// <param name="exception">A exception derived from System.Exception</param>
        public void Warning(string message, Exception exception)
        {
            var sb = new StringBuilder();

            if (exception != null)
            {
                sb.AppendLine();
                sb.AppendLine("\tException Message:");
                sb.Append("\t\t");
                sb.Append(exception.Message);
            }

            WriteMessage(LogTypeEnum.Warning, string.Format("{0}{1}", message, sb.ToString()));
        }

        /// <summary>
        /// Send an Error message and log the message.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        public void Error(string message)
        {
            Error(message, null);
        }

        /// <summary>
        /// Send an Error message and a System.Exception to be logged.
        /// The following System.Exception properties will be added to the message: Source and Message
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        /// <param name="exception">A exception derived from System.Exception</param>
        public void Error(string message, Exception exception)
        {
            var sb = new StringBuilder();

            if (exception != null)
            {
                sb.AppendLine();
                sb.Append("\tSource: ");
                sb.AppendLine(exception.Source);
                sb.AppendLine("\tException Message:");
                sb.Append("\t\t");
                sb.Append(exception.Message);
            }

            WriteMessage(LogTypeEnum.Error, string.Format("{0}{1}", message, sb.ToString()));
        }

        /// <summary>
        /// Send a DEBUG message and log the message.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        public void Debug(string message)
        {
            Debug(message, null);
        }

        /// <summary>
        /// Send a DEBUG message and a System.Exception to be logged.
        /// The following System.Exception properties will be added to the message: Source, Message and StackTrace
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        /// <param name="exception">A exception derived from System.Exception</param>
        public void Debug(string message, Exception exception)
        {
            var sb = new StringBuilder();

            if (exception != null)
            {
                sb.AppendLine();
                sb.Append("\tSource: ");
                sb.AppendLine(exception.Source);
                sb.AppendLine("\tException Message:");
                sb.Append("\t\t");
                sb.AppendLine(exception.Message);
                sb.AppendLine();
                sb.AppendLine("\tStack Trace:");
                sb.Append("\t\t");
                sb.Append(exception.StackTrace);
            }

			WriteMessage (LogTypeEnum.DEBUG, string.Format("{0}{1}", message, sb.ToString()));
		}

        internal abstract void WriteMessage(LogTypeEnum type, string message);
    }
}
