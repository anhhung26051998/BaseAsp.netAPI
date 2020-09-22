using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseProject.Models
{
    public class JsonResultModel
    {
        public int status { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }
}