using System;
using System.Collections.Generic;

namespace WebApplication1
{
    // We will pass this to ChatGPT, list of transcripts and the user Emotion with that
    public class WorkingSet
    {
        public List<Transcript> transcript { get; set; }
        public Instance sentiment { get; set; }
        public Emotion emotions { get; set; }
    }
}
