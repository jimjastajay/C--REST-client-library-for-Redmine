﻿/*
   Copyright 2011 Bobby Sawhney bobbysawhney@gmail.com

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
 */
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Redmine {
    [XmlRoot]
    [XmlType("issues")]
    public class Issues {
        private static string szFormat = "{0,12} : {1}";

        [XmlAttribute]
        public int total_count;
        [XmlAttribute]
        public string type;
        [XmlAttribute]
        public int limit;
        [XmlAttribute]
        public int offset;
        [XmlElement(ElementName = "issue")]
        public List<Issue> list = new List<Issue>();

        public void dump(string label) {
            Console.WriteLine(( label + " start").PadLeft(40, '-') + ("").PadRight(40, '-'));
            foreach (Issue o in list) {
                o.dump();
            }
            Console.WriteLine((label + " stats").PadLeft(40, '-') + ("").PadRight(40, '-'));
            Console.WriteLine(szFormat, "total_count", total_count);
            Console.WriteLine(szFormat, "type", type);
            Console.WriteLine(szFormat, "limit", limit);
            Console.WriteLine(szFormat, "offset", offset);
            Console.WriteLine((label + " end").PadLeft(40, '-') + ("").PadRight(40, '-'));
        }
    }
}
// <issues total_count="17" type="array" limit="1" offset="0">