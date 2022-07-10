using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationAPI
{
    public class Tuto
    {
        public string Title { get; set; }

        public int Price { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return Title + " | " + Price;
        }

    }
}
