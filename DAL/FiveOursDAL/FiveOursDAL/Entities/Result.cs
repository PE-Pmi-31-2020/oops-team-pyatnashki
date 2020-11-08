using System;
using System.Collections.Generic;
using System.Text;

namespace FiveOursDAL.Entities
{
    public class Result : IEntity
    {
        public int ResultId { get; set; }

        public string Name { get; set; }

        public int Time { get; set; }

        public int NumberOfMoves { get; set; }
    }
}
