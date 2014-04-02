﻿using NHibernateLibrary.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateLibrary.Entities
{
    public class PrevEduGroup : BaseEntity<Int64>
    {
        public virtual int UserID { get; set; }
        public virtual String PreviousEducation { get; set; }
    }
}