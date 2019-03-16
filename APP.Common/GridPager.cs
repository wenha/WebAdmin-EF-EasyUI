using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Common
{
    public class GridPager
    {
        public int rows { get; set; }

        public int page { get; set; }

        public string order { get; set; }

        public string sort { get; set; }

        public int totalRows { get; set; }

        public int totalPage
        {
            get
            {
                return (int)Math.Ceiling((float)totalRows / (float)rows);
            }
        }
    }

}
