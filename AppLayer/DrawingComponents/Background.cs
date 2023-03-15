using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.DrawingComponents
{
    public abstract class Background
    {
        public abstract T GetBackground<T>();
    }
}
