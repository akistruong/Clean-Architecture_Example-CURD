﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Iventory
    {
        public string ID { get; set; }
           public string ProductID {  get; set; }   
           public int Qty { get; set; }
           public Product? Product { get; set; }
    }
}
