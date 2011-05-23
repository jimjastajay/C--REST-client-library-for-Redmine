﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Redmine {
    [XmlRoot]
    [XmlType("users")]
    public class Users {
        private static string szFormat = "{0,12} : {1}";

        [XmlAttribute]
        public int total_count;
        [XmlAttribute]
        public string type;
        [XmlAttribute]
        public int limit;
        [XmlAttribute]
        public int offset;
        [XmlElement(ElementName = "user")]
        public List<User> list = new List<User>();

        public void dump(string label) {
            Console.WriteLine((label + " start").PadLeft(40, '-') + ("").PadRight(40, '-'));
            foreach (User o in list) {
                o.dump();
            }
            Console.WriteLine((label + " stats").PadLeft(40, '-') + ("").PadRight(40, '-'));
            Console.WriteLine(szFormat, "total_count", total_count);
            Console.WriteLine(szFormat, "type", type);
            Console.WriteLine(szFormat, "limit", limit);
            Console.WriteLine(szFormat, "offset", offset);
            Console.WriteLine((label + " end").PadLeft(40, '-') + ("").PadRight(40, '-'));
        }

        public User getUserByLogin(string login) {
            User user = null;
            foreach (User o in list) {
                if (System.String.Compare(o.login, login, true) == 0) {
                    user = o;
                    break;
                }
            }
            return user;
        }

        public int Count {
            get { return list.Count; }
        }
    }
}
// <users total_count="38" type="array" limit="25" offset="0">