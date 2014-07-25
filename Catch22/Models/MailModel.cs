using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Catch22.Models
{
    public class MailModel
    {
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public string ContactName { get; set; }

        public string ReturnEmail { get; set; }
    }
}