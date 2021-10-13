using System;
using System.Collections.Generic;
using System.Text;

namespace songshuwu.client
{
    public class BaseOutput<T>
    {
        public int code { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }
}
