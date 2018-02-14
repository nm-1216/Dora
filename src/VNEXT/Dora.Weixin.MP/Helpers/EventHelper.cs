
using System;
using System.Xml.Linq;

namespace Dora.Weixin.MP.Helpers
{
    /// <summary>
    /// 事件帮助类
    /// </summary>
    public class EventHelper
    {
        public static Event GetEventType(XDocument doc)
        {
            return GetEventType(doc.Root.Element("Event").Value);
        }

        public static Event GetEventType(string str)
        {
            return (Event)Enum.Parse(typeof(Event), str, true);
        }
    }
}
