using System;
using System.Collections.Generic;

namespace BerrasBio
{
    public partial class Session
    {
        public int Id { get; set; }
        public int Movie { get; set; }
        public DateTime StartTime { get; set; }
        public int SeatsTaken { get; set; }

        public Movies MovieNavigation { get; set; }
    }
}
