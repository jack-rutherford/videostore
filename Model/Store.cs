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
            if (obj == null || this.GetType() != obj.GetType()) return false;

            Store a2 = obj as Store;
            if (this.StreetAddress.Equals(a2.StreetAddress) && this.ZipCode.Equals(a2.ZipCode)) return true;
            return false;
        }

        public virtual void AddVideo(Video video1)
        {
            this.Videos.Add(video1);
        }

        public virtual void RemoveManager(Employee employee1)
        {
            
        }
        public virtual void AddManager(Employee employee1)
        {
            
        }

        public virtual void RemoveVideo(Video video)
        {
            this.Videos.Remove(video);
        }
    }
}
