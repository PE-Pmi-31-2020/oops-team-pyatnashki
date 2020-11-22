using System;
using System.Collections.Generic;
using System.Text;

namespace ResultsDbContext.Models
{
    public class Result
    {
        public int ResultID { get; set; }
        public string PlayerName { get; set; }
        public long GameTime { get; set; }
        public int MovesCount { get; set; }
    }
}
