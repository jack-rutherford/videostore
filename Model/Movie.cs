﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Movie
    {
        public virtual int Id { get;  set; }
        public virtual string Title { get;  set; }
        public virtual IList<Reservation> Reservations { get;  set; }
        public virtual int Year { get; set; }
        public virtual string OriginalTitle { get; set; }
        public virtual string Director { get; set; }
        public virtual int RunningTimeInMinutes { get; set; }
        public virtual string Rating { get; set; }
        public virtual float IMDBRating { get; set; }
        public virtual int NumberOfRatings { get; set; }
        public virtual Genre PrimaryGenre { get; set; }
        public Movie () 
        { 
            Reservations = new List<Reservation> ();
        }
        public override int GetHashCode()
        {
            return Id;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null || obj is Movie) return false;

            Movie a2 = obj as Movie;
            if (this.Title.Equals(a2.Title) && this.Year == a2.Year) return true;
            return false;
        }

        public virtual Reservation AddReservation(Customer customer2)
        {
            return null;
        }
    }
}
