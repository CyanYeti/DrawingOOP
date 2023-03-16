using AppLayer.DrawingComponents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.Command
{
    internal class SetBackgroundCommand : Command
    {
        private Background background;

        internal SetBackgroundCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
            {
                Bitmap tempbmp = commandParameters[0] as Bitmap;
                background = new Background();
                background.map = tempbmp;
            }
        }

        public override bool Execute()
        {
            TargetDrawing.SetBackground(background);
            return true;
        }

        internal override void Redo()
        {
            Execute();
        }

        internal override void Undo()
        {
            TargetDrawing.RemoveLastBackground(); //When we are called we are the last background
        }
    }
}
