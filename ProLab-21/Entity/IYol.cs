using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab_21.Entity
{
    class IYol
    {
        public static int id = 1;
        public int[] yol = new int[10];
        public IYol ileri;
        public IYol(int[] yol)
        {
            this.yol = yol;
            id = id + 1;
        }

    }
}
