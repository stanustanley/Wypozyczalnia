using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication19.model
{
    public class Edycja_Stan
    {

        public int id { get; set; }

        public int stan { get; set; }

        public Edycja_Stan(int id, int stan)
        {
            this.id = id;
            this.stan = stan;
        }
    }
}