using System;
using System.Collections.Generic;

namespace WebApplication1
{
    // We will pass this to ChatGPT
    public class WorkingSet
    {
        public List<Transcript> transcript { get; set; }
        public Instance sentiment { get; set; }
        public Emotion emotions { get; set; }
    }
}
