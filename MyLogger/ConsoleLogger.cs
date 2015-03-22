using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger
{
    /// <summary>
    /// A utility for logging messages to the Console. 
    /// </summary>
    public class ConsoleLogger : Logger
    {
        internal override void WriteMessage(LogTypeEnum type, string message)
        {
            Console.WriteLine(string.Format("{0} {1} {2}", DateTime.Now.ToLongTimeString() , type.ToString(), message));
        }
    }
}
