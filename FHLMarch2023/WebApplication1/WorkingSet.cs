using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public class WorkingSet
    {
        public Keyword transcript { get; set; }
        public Sentiment sentiments { get; set; }
        public List<AudioEffect> emotions { get; set; }
    }
}
