using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Movie
    {
        public virtual int Id { get;  set; }
        public virtual string Title { get;  set; }
        public IList<Reservation> Reservations { get;  set; }
        public int Year { get; set; }
        public string OriginalTitle { get; set; }
        public string Director { get; set; }
        public int RunningTimeInMinutes { get; set; }
        public string Rating { get; set; }
        public float IMDBRating { get; set; }
        public int NumberOfRatings { get; set; }
        public Genre PrimaryGenre { get; set; }

    }
}
