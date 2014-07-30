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

    public class CMSHomeViewModel
    {
        public List<News> NewsItems { get; set; }
    }

    public class PerformancesViewModel
    {
        public List<Performance> AllPerformances { get; set; }

        public Performance NewPerformance { get; set; }
    }

    public class RepertoireViewModel
    {
        public List<Repertoire> AllRep { get; set; }

        public Repertoire NewRep { get; set; }
    }
}