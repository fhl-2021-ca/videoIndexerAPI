using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public class WorkingSet
    {
        public List<Keyword> transcript { get; set; }
        public Instance sentiment { get; set; }
        public List<Emotion> emotions { get; set; }
    }
}
