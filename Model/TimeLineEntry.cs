﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.Model
{
    public class TimeLineEntry : TreeBase<TimeLineEntry>
    {
        public DateTime Start { get; set; }
        public TimeSpan LengthOfTime { get; set; }
    }
}
