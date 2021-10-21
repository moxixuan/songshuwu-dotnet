using System;
using System.Collections.Generic;
using System.Text;

namespace songshuwu.client
{
    public class BaseInput
    {
        public string app_key { get; set; }
        public string sign { get; set; }
        public long timestamp { get; set; }
        public int version { get; set; }
        public string @params { get; set; }
    }
}
