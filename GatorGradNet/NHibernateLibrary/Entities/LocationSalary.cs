﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateLibrary.Entities
{
    public class LocationSalary
    {
        public virtual int CompanyID { get; set; }
        public virtual int DesignationID { get; set; }
        public virtual String Location { get; set; }
    }
}