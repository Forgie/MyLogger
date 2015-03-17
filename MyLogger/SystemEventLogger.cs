using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security;
using System.ComponentModel;

namespace MyLogger
{
    /// <summary>
    /// A utility for logging messages to the system event logs.
    /// </summary>
    public class SystemEventLogger : Logger
    {
        private string _source;

        /// <summary>
        /// Initializes a new instance of the MyLogger.SystemEventLogger class. Verifies a source is valid and checks if a log exists and creates one if not.
        /// </summary>
        /// <param name="source">The source name by which the application is registered on the local computer.</param>
        /// <param name="log">The name of the log the source's entries are written to. Possible values include Application, System, or a custom event log. Default is Application.</param>
        /// <exception cref="System.Security.SecurityException"/>
        /// <exception cref="System.ArgumentException"/>
        /// <exception cref="System.InvalidOperationException"/>
        public SystemEventLogger(string source, string log)
        {
            _source = source; 

            if (!EventLog.SourceExists(_source))
            {
                string logName = String.IsNullOrEmpty(log) ? "Application" : log;

                EventLog.CreateEventSource(_source, logName);
            }
        }
        
        internal override void WriteMessage(string type, string message)
        {
            switch (type)
            {
                case "DEBUG":
                    EventLog.WriteEntry(_source, string.Format("{0} -- {1}", type, message), EventLogEntryType.Information);
                    break;
                case "Information":
                    EventLog.WriteEntry(_source, message, EventLogEntryType.Information);
                    break;
                case "Warning":
                    EventLog.WriteEntry(_source, message, EventLogEntryType.Warning);
                    break;
                case "Error":
                    EventLog.WriteEntry(_source, message, EventLogEntryType.Error);
                    break;
                default:
                    throw new ArgumentException(string.Format("Encountered an unexpected message type of {0}.",type));
            }
        }
    }
}
