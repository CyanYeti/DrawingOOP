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
        private Point moveFrom { get; set; }
        private Element selected;
        internal MoveCommand(params object[] commandParameters)
        {
            //if (commandParameters.Length > 0)
            //{
            //    selected = commandParameters[0] as Element;
            //}
            if (commandParameters.Length > 0)
            {
                moveTo = (Point) commandParameters[0];
            }
        }
        public override bool Execute()
        {
            selected = TargetDrawing.GetSelected();
            if (selected == null) return false;
            moveFrom = selected.getLocation();
            TargetDrawing.DeleteElement(selected);

            //previousElement = previousElement;

            selected.MoveToPoint(moveTo);
            TargetDrawing.Add(selected);

            //previousElement.IsSelected = false;
            return true;
        }

        internal override void Redo()
        {
            Console.WriteLine("REDO");
            TargetDrawing.DeleteElement(selected);
            selected.MoveToPoint(moveTo);
            TargetDrawing.Add(selected);
        }

        internal override void Undo()
        {
            Console.WriteLine("UNDO");
            TargetDrawing.DeleteElement(selected);
            selected.MoveToPoint(moveFrom);
            TargetDrawing.Add(selected);

        }
    }
}
