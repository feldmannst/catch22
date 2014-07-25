using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Catch22.Models
{
    public class HomeViewModel
    {
        public string MainBlurb { get; set; }

        public List<Performance> Performances { get; set; }

        public List<MemberBio> MemberBios { get; set; }

        public List<Repertoire> Repertoire { get; set; }

    }
}