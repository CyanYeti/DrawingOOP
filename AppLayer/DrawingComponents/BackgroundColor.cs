using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;

namespace AppLayer.DrawingComponents
{
    internal class BackgroundColor : Background
    {
        public Color color { get; set; }

        public T GetBackground<T>()
        {
            return color;
        }

        
    }
}
