using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrator.Models
{
    public class Stadium
    {
        public Tribunal[] tribunals { get; set; }

        public class Tribunal
        {
            public Portal[] portals { get; set; }
        }

        public class Portal
        {

        }


    }
}