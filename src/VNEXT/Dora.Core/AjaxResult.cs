using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dora.Core
{

    public class AjaxResult : AjaxResult<string>
    {
        public AjaxResult(string msg) : base(msg)
        {
        }


    }

    public class AjaxResult<T>
    {
        public AjaxResult(string msg)
        {
            this.msg = msg;
        }

        public string method { get; set; }

        public T data { get; set; }

        public int result { get; set; } = 0;

        public string msg { get; set; }
    }
}
