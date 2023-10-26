﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CommunicationMethod
    {
        public object Name { get; protected internal set; }
        public int Id { get; protected internal set; }
        public ISet<Customer> Customers { get; protected internal set; }
    }
}