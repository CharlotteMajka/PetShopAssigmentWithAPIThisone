using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Filters
{
    public class FilteredList<T>
    {

        public Filter FilterUsed { get; set; }

        public int TotalCount { get; set; }
        public int ShowingCount { get; set; }

        public List<T> List { get; set; }

    }
}
