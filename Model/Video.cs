using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Utilities;

namespace Model
{
    public class Video
    {
        public virtual int Id { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual DateTime PurchaseDate { get; set; }
        public virtual bool NewArrival { get; set; }
        public virtual Store Store { get; set; }

        public Video() 
        { 
            PurchaseDate = DateFactory.CurrentDate;
            Id = 0;
            NewArrival = true;
            Movie = new Movie();
            Store = new Store();
        }
        public override int GetHashCode()
        {
            return Id;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null || this.GetType() != obj.GetType()) return false;
            Video other = obj as Video;
            return this.Id.Equals(other.Id);
        }
    }
}
