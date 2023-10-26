﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Area
    {
        public virtual HashSet<ZipCode> ZipCodes { get; protected internal set; }
        public virtual string Name { get;  set; }
        public virtual int Id { get; set; }
        public Area() { }
        public int GetHashCode()
        {
            return Id;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null || this.GetType() != obj.GetType()) return false;

            Area a2 = obj as Area;
            if (this.Name.Equals(a2.Name)) return true;
            return false;
        }
    }
}
