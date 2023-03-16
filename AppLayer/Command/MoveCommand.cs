using AppLayer.DrawingComponents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.Command
{
    internal class MoveCommand : Command
    {
        private Point moveTo { get; set; }
        private Element previousElement { get; set; }
        private Element selected;
        internal MoveCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
            {
                selected = commandParameters[0] as Element;
            }
            if (commandParameters.Length > 1)
            {
                moveTo = (Point) commandParameters[1];
            }
        }
        public override bool Execute()
        {
            previousElement = TargetDrawing.
            TargetDrawing.MoveSelected(selected, location);
            return true;
        }

        internal override void Redo()
        {
            throw new NotImplementedException();
        }

        internal override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
