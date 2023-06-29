using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MCSLogger
{
    public class Log
    {
        public LogLevel Type { get; }
        public readonly string Source = "Service";
        public string Content { get; }
        public Dictionary<string, object> MetaData { get; set; }
        public string SourceID { get; set; }

        public Log(LogLevel type, string sourceID, string content, Dictionary<string, object>? metaData = null)
        {
            Type = type;
            Content = content;
            SourceID = sourceID;
            MetaData = metaData ?? new Dictionary<string, object>();
        }
    }

    public enum LogLevel
    {
        Info,
        Warning,
        Error,
        Debug
    }
}
