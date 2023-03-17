using AppLayer.DrawingComponents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.Command
{
    internal class CloneCommand : Command
    {
        private Point cloneSpot { get; set; }
        private Element clone;
        public CloneCommand(params object[] commandParameters) 
        { 
            if (commandParameters.Length > 0)
            {
                cloneSpot = (Point) commandParameters[0];
            }
        }
        public override bool Execute()
        {
            clone = TargetDrawing.GetSelected().Clone().Clone();
            if (clone == null) return false;
            clone.MoveToPoint(cloneSpot);
            TargetDrawing.Add(clone);

            return true;

        }

        internal override void Redo()
        {
            TargetDrawing.Add(clone);
        }

        internal override void Undo()
        {
            TargetDrawing.DeleteElement(clone);
        }
    }
}
