using System;
using System.Collections.Generic;

namespace BerrasBio
{
    public partial class Movies
    {
        public Movies()
        {
            Session = new HashSet<Session>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }

        public ICollection<Session> Session { get; set; }
    }
}
