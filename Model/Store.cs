using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Store
    {
        public virtual string StreetAddress { get;  set; }
        public virtual ZipCode ZipCode { get;  set; }
        public virtual IList<Employee> Managers { get; protected internal set; }
        public virtual IList<Video> Videos { get; protected internal set; }
        public virtual int Id { get;  set; }
        public virtual string PhoneNumber { get; set; }
        public Store() 
        { 
            Managers = new List<Employee>();
            Videos = new List<Video>();
        }
        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(Object obj)
        {
            if (obj is Store)
            {
                Store other = (Store)obj;
                return other.StreetAddress.Equals(this.StreetAddress) && other.ZipCode.Equals(this.ZipCode);
            }
            return false;
        }

        public virtual void AddVideo(Video video1)
        {
            //Adds a new Video to the list of videos owned by the store
            // Can there be duplicate videos in a store?
            if (Videos.Contains(video1)) throw new ArgumentException("Video already exists in this store");
            Videos.Add(video1);
            video1.Store = this; // I don't think this is necessary
        }

        public virtual void RemoveManager(Employee employee1)
        {
            
        }
        public virtual void AddManager(Employee employee1)
        {
            
        }

        public virtual void RemoveVideo(Video video)
        {
            //Removes the given Video from the list of videos owned by the Store.
            //Throws ArgumentException if the given Video is not owned by the Store
            if (!(this.Videos.Contains(video))) throw new ArgumentException("Video does not exist in this store");
            if (video.Store != this) throw new ArgumentException("Video is not owned by this store");
            Videos.Remove(video);
        }
    }
}
