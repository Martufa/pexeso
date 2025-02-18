using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pexeso
{
    public class Symbol
    {
        public int id;
        // private Tuple<int>[]? occurance;
        public int occurance;
        public Symbol(int id)
        {
            this.id = id;
            // occurance = new Tuple<int>[2]; // row-col1, row-col2
            occurance = 0;
        }
    }
}