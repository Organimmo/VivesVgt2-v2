﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organimmo.DAL
{
    public class Root
    {
        public string Id { get; set; }
        public string ApplicationName { get; set; }
        public string ApplicationVersion { get; set; }
        public string Customer { get; set; }
        public string Username { get; set; }
        public string Language { get; set; }
        public List<Window> Window { get; set; }
    }
}
